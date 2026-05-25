import { calculatePoints } from "./scoring.js";

// Gets the current question object from state
export const getCurrentQuestion = (state) =>
  state.questions[state.currentIndex];

// Returns the progress as a percentage (for a progress bar)
export const getProgress = (state) =>
  Math.round((state.currentIndex / state.questions.length) * 100);

// Calculates points, records the answer, advances to the next question.
export const submitAnswer = (state, chosenAnswer, timeRemaining) => {
  const question = getCurrentQuestion(state);
  //.correctAnswer from API
  const isCorrect = chosenAnswer === question.correctAnswer;

  const newStreak = isCorrect ? state.streak + 1 : 0;
  const points = calculatePoints(isCorrect, timeRemaining, newStreak);
  const newLives = isCorrect ? state.lives : state.lives - 1;
  const nextIndex = state.currentIndex + 1;
  const gameOver = nextIndex >= state.questions.length || newLives <= 0;

  // Build a record for this answer for a summary at the end
  const answerRecord = 
  {
    questionText: question.text,
    chosen: chosenAnswer,
    correctAnswer: question.correctAnswer,
    wasCorrect: isCorrect,
    pointsEarned: points,
    timeRemaining,
  };

  // Return a new state object for the next question
  return {
    ...state,
    score: state.score + points,
    streak: newStreak,
    lives: newLives,
    answers: [...state.answers, answerRecord],
    currentIndex: nextIndex,
    isOver: gameOver,
    // Reset timer for next question
    timeRemaining: state.timePerQuestion, 
    totalTimeUsed: state.totalTimeUsed + (state.timePerQuestion - timeRemaining),
  };
};

// Skips the current question (no points, streak resets)
export const skipQuestion = (state) => {
  const question = getCurrentQuestion(state);
  const nextIndex = state.currentIndex + 1;

  // Return a new state object for the next question
  return {
    ...state,
    streak: 0,
    answers: [
      ...state.answers,
      { questionText: question.text, chosen: null, correctAnswer: question.correctAnswer, wasCorrect: false, pointsEarned: 0, skipped: true },
    ],
    currentIndex: nextIndex,
    isOver: nextIndex >= state.questions.length,
    timeRemaining: state.timePerQuestion,
  };
};

// Called when the timer expires on a question (same as a wrong answer with 0 time).
export const timeExpired = (state) => submitAnswer(state, null, 0);

// Summary of results at the end of the game
export const getResults = (state) => {
  const correct = state.answers.filter((a) => a.wasCorrect).length;
  const skipped = state.answers.filter((a) => a.skipped).length;
  return {
    score: state.score,
    total: state.questions.length,
    correct,
    incorrect: state.questions.length - correct - skipped,
    skipped,
    accuracy: Math.round((correct / state.questions.length) * 100),
    totalTimeUsed: state.totalTimeUsed,
    answers: state.answers,
    topic: state.topic,
    gameType: state.gameType,
  };
};          	