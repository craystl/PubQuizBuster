import { useEffect, useState, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import { hasNextQuestion, getNextQuestionIndex } from "../gameLogic/oddOneOutLogic";
import { calculatePoints } from "../gameLogic/scoring";

const styles = {
  page: {
    minHeight: "100vh",
    width: "100%",
    background: "linear-gradient(135deg, #0f0c29 0%, #302b63 50%, #24243e 100%)",
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    justifyContent: "center",
    padding: "40px 20px",
    boxSizing: "border-box",
    fontFamily: "'Nunito', sans-serif",
    position: "relative",
  },
  timerBadge: {
    position: "fixed",
    left: "30px",
    top: "30px",
    background: "rgba(255,255,255,0.08)",
    backdropFilter: "blur(12px)",
    border: "1px solid rgba(255,255,255,0.15)",
    borderRadius: "20px",
    padding: "12px 24px",
    color: "white",
    fontWeight: "800",
    zIndex: 20,
  },
  scoreBadge: {
    position: "fixed",
    right: "30px",
    top: "30px",
    background: "rgba(255,255,255,0.08)",
    backdropFilter: "blur(12px)",
    border: "1px solid rgba(255,255,255,0.15)",
    borderRadius: "20px",
    padding: "12px 24px",
    color: "white",
    fontWeight: "800",
    zIndex: 20,
  },
 title: {
  fontFamily: "'Fredoka One', cursive",
  fontSize: "clamp(1.5rem, 3vw, 2.2rem)",  // ← smaller
  background: "linear-gradient(90deg, #fbbf24, #f87171, #a78bfa, #34d399, #fbbf24)",
  backgroundSize: "300% auto",
  WebkitBackgroundClip: "text",
  WebkitTextFillColor: "transparent",
  marginBottom: "8px",
  paddingTop: "16px",       // ← stops top clipping
  paddingBottom: "8px",     // ← stops bottom clipping
  lineHeight: "1.3",        // ← gives letters room to breathe
  textAlign: "center",
},
  subtitle: {
    color: "#d8d4ff",
    fontSize: "1.2rem",
    textAlign: "center",
    maxWidth: "600px",
    marginBottom: "8px",
  },
  questionCount: {
    color: "rgba(255,255,255,0.4)",
    fontSize: "14px",
    marginBottom: "32px",
  },
  answersGrid: {
    display: "grid",
    gridTemplateColumns: "repeat(2, 1fr)",
    gap: "16px",
    maxWidth: "600px",
    width: "100%",
    marginBottom: "24px",
  },
  answerCard: {
    background: "rgba(255,255,255,0.08)",
    border: "1px solid rgba(255,255,255,0.15)",
    borderRadius: "16px",
    padding: "20px",
    color: "white",
    fontSize: "1rem",
    fontWeight: "700",
    cursor: "pointer",
    transition: "all 0.2s ease",
    fontFamily: "'Nunito', sans-serif",
  },
  resultBadge: {
    border: "1px solid",
    borderRadius: "16px",
    padding: "16px 32px",
    fontSize: "18px",
    fontWeight: "800",
    marginBottom: "24px",
    textAlign: "center",
  },
  nextButton: {
    background: "linear-gradient(135deg, #f59e0b, #ef4444)",
    border: "none",
    borderRadius: "100px",
    padding: "14px 40px",
    color: "white",
    fontSize: "1rem",
    fontWeight: "700",
    cursor: "pointer",
    marginBottom: "16px",
    fontFamily: "'Fredoka One', cursive",
    letterSpacing: "2px",
  },
  exitButton: {
    background: "rgba(239,68,68,0.15)",
    border: "1px solid rgba(239,68,68,0.4)",
    color: "#ef4444",
    borderRadius: "20px",
    padding: "10px 24px",
    fontSize: "15px",
    cursor: "pointer",
    fontWeight: "600",
  },
};

function Quiz3({ onExit, onFinish, quizData }) {
  const [questions, setQuestions] = useState(null);
  const [title, setTitle] = useState("");
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [score, setScore] = useState(0);
  const scoreRef = useRef(0);
  const [result, setResult] = useState("");
  const [isCorrect, setIsCorrect] = useState(null);
  const [timeRemaining, setTimeRemaining] = useState(60);
  const [isFinished, setIsFinished] = useState(false);
  const timerRef = useRef(null);

  useEffect(() => {
    if (quizData) {
      setTitle(quizData.title || "Odd One Out Quiz");
      const loadedQuestions = quizData.questions || quizData.activities || [];  // ← fixed fallback
      setQuestions(Array.isArray(loadedQuestions) ? loadedQuestions : []);
    }
  }, [quizData]);

  useEffect(() => {
    timerRef.current = createTimer(
      60,
      (t) => setTimeRemaining(t),
      () => alert("Time's up!"),
      (t) => console.log("Warning!", t)
    );
    return () => stopTimer(timerRef.current);
  }, []);

  function handleAnswerClick(answer) {
    const correct = answer.isCorrectOddOneOut === true || answer.isOddOneOut === true;
    const points = calculatePoints(correct, timeRemaining, 0);
    setIsCorrect(correct);
    setResult(correct ? "Correct!" : "Wrong!");
    const newScore = score + points;
    setScore(newScore);
    scoreRef.current = newScore;
    if (!hasNextQuestion(currentQuestionIndex, questions.length)) {
      setIsFinished(true);
    }
  }

  function handleNextQuestion() {
    if (isFinished) {
      stopTimer(timerRef.current);
      onFinish(scoreRef.current);
      return;
    }
    setResult("");
    setIsCorrect(null);
    setCurrentQuestionIndex(getNextQuestionIndex(currentQuestionIndex, questions.length));
  }

  function handleExit() {
    if (confirm("Are you sure you want to exit the quiz?")) {
      onExit();
    }
  }

  if (!questions || questions.length === 0) {
    return (
      <div style={styles.page}>
        <h1 style={{ color: "#fff" }}>No quiz loaded...</h1>
      </div>
    );
  }

  const currentQuestion = questions[currentQuestionIndex];
  const answers = currentQuestion.answers || currentQuestion.items || [];

  return (
    <div style={styles.page}>
      <style>{`@import url('https://fonts.googleapis.com/css2?family=Fredoka+One&family=Nunito:wght@400;700;900&display=swap');`}</style>

      <div style={styles.timerBadge}>⏳ Time: {timeRemaining}</div>
      <div style={styles.scoreBadge}>🏆 Score: {score}</div>

      <h1 style={styles.title}>{title}</h1>
      <p style={styles.subtitle}>{currentQuestion.prompt || currentQuestion.question}</p>
      <p style={styles.questionCount}>Question {currentQuestionIndex + 1} of {questions.length}</p>

      <div style={styles.answersGrid}>
        {answers.map((answer, index) => (
          <button
            key={index}
            onClick={() => handleAnswerClick(answer)}
            style={styles.answerCard}
          >
            {answer.name}
          </button>
        ))}
      </div>

      {result && (
        <div style={{
          ...styles.resultBadge,
          background: result === "Correct!" ? "rgba(34,197,94,0.2)" : "rgba(239,68,68,0.2)",
          borderColor: result === "Correct!" ? "#22c55e" : "#ef4444",
          color: result === "Correct!" ? "#22c55e" : "#ef4444",
        }}>
          {result === "Correct!" ? "✅ Correct!" : "❌ Wrong!"}
          {isFinished && (
            <div style={{ marginTop: "8px", fontSize: "16px" }}>
              🎉 Quiz Finished! Click Next to see your score.
            </div>
          )}
        </div>
      )}

      <button onClick={handleNextQuestion} style={styles.nextButton}>
        {isFinished ? "See Score →" : "Next Question →"}
      </button>
      <button onClick={handleExit} style={styles.exitButton}>
        ✕ Exit
      </button>
    </div>
  );
}

export default Quiz3;
