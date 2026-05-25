import { initializeApp } from "firebase/app";

import {
  getFirestore,
  doc,
  setDoc,
  getDoc,
  collection,
  query,
  where,
  orderBy,
  limit,
  getDocs,
  serverTimestamp,
} from "firebase/firestore";


// Firebase project configuration
const firebaseConfig = {
  apiKey: "YOUR_API_KEY",
  authDomain: "YOUR_PROJECT.firebaseapp.com",
  projectId: "YOUR_PROJECT_ID",
  storageBucket: "YOUR_PROJECT.appspot.com",
  messagingSenderId: "YOUR_SENDER_ID",
  appId: "YOUR_APP_ID",
};


// Initialise Firebase + Firestore
const app = initializeApp(firebaseConfig);
const db = getFirestore(app);


// Firestore collection names
const SESSIONS_COLLECTION = "quizSessions";
const LEADERBOARD_COLLECTION = "leaderboard";


// Generates IDs e.g. PUB-A4EXDW
export const generateSessionId = () => {
  const chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

  const random = Array.from({ length: 6 }, () =>
    chars[Math.floor(Math.random() * chars.length)]
  ).join("");

  return `PUB-${random}`;
};


// Saves a completed quiz session
export const saveQuizSession = async (
  state,
  playerName = "Anonymous"
) => {

  const sessionId = generateSessionId();

  // Data stored in Firestore
  const sessionDoc = {
    sessionId,
    playerName,
    topic: state.topic,
    gameType: state.gameType,

    // Save full quiz data so it can be replayed later
    questions: state.questions,
    answers: state.answers,

    score: state.score,
    accuracy: calcAccuracy(state),

    timePerQuestion: state.timePerQuestion,
    totalTimeUsed: state.totalTimeUsed,

    // Firebase adds the current server time
    createdAt: serverTimestamp(),
  };

  try {

    // Save session using session ID as document ID
    await setDoc(
      doc(db, SESSIONS_COLLECTION, sessionId),
      sessionDoc
    );

    // Also save to leaderboard
    await saveToLeaderboard(
      sessionId,
      playerName,
      state
    );

    return sessionId;

  } catch (error) {

    console.error("Failed to save quiz session:", error);
    throw error;
  }
};


// Loads a quiz session using its share code
export const loadQuizSession = async (sessionId) => {

  // Clean up user input
  const normalisedId = sessionId.trim().toUpperCase();

  try {

    const docRef = doc(
      db,
      SESSIONS_COLLECTION,
      normalisedId
    );

    const docSnap = await getDoc(docRef);

    // Return null if session doesn't exist
    if (!docSnap.exists()) {
      return null;
    }

    return docSnap.data();

  } catch (error) {

    console.error("Failed to load quiz session:", error);
    throw error;
  }
};


// Gets leaderboard scores for a topic
export const getLeaderboard = async (
  topic,
  limitCount = 10
) => {

  try {

    // Query leaderboard collection
    const q = query(
      collection(db, LEADERBOARD_COLLECTION),

      // Only this quiz topic
      where("topic", "==", topic),

      // Highest score first
      orderBy("score", "desc"),

      // Limit number of results
      limit(limitCount)
    );

    const snapshot = await getDocs(q);

    // Convert documents into plain objects
    return snapshot.docs.map((d, index) => ({
      rank: index + 1,
      ...d.data(),
    }));

  } catch (error) {

    console.error("Failed to fetch leaderboard:", error);
    throw error;
  }
};


// Internal helper function for leaderboard saving
const saveToLeaderboard = async (
  sessionId,
  playerName,
  state
) => {

  const entry = {
    sessionId,
    playerName,

    topic: state.topic,
    gameType: state.gameType,

    score: state.score,
    accuracy: calcAccuracy(state),

    createdAt: serverTimestamp(),
  };

  await setDoc(
    doc(db, LEADERBOARD_COLLECTION, sessionId),
    entry
  );
};


// Calculates quiz accuracy percentage
const calcAccuracy = (state) => {

  const totalQuestions = state.questions.length;

  // Count correct answers
  const correctAnswers = state.answers.filter(
    (a) => a.wasCorrect
  ).length;

  // Prevent division by zero
  return totalQuestions > 0
    ? Math.round((correctAnswers / totalQuestions) * 100)
    : 0;
};