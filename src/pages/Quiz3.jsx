import { useEffect, useState, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import { checkOddOneOutAnswer, getAnswerMessage, hasNextQuestion, getNextQuestionIndex } from "../gameLogic/oddOneOutLogic";
import { calculatePoints, saveHighScore } from "../gameLogic/scoring";
import { useNavigate } from "react-router-dom";

function Quiz3() {
  const [questions, setQuestions] = useState(null);
  const [title, setTitle] = useState("");
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [score, setScore] = useState(0);
  const [result, setResult] = useState("");
  const [timeRemaining, setTimeRemaining] = useState(60);
  const timerRef = useRef(null);
  const navigate = useNavigate();

  useEffect(() => {
    fetch("/data/odd-one-out/movie_odd_one_out.json")
      .then((response) => response.json())
      .then((data) => {
        setTitle(data.title);
        setQuestions(data.questions);
      });
  }, []);

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
    const isCorrect = checkOddOneOutAnswer({ isOdd: answer.isCorrectOddOneOut });
    const points = calculatePoints(isCorrect, timeRemaining, 0);
    setResult(getAnswerMessage(isCorrect));
    setScore(score + points);
  }

  function handleNextQuestion() {
    setResult("");
    if (!hasNextQuestion(currentQuestionIndex, questions.length)) {
      setResult("Quiz Finished!");
      return;
    }
    setCurrentQuestionIndex(getNextQuestionIndex(currentQuestionIndex, questions.length));
  }

  function handleExit() {
    if (confirm("Are you sure you want to exit the quiz?")) {
      navigate("/");
    }
  }

  if (!questions) {
    return (
      <div style={styles.page}>
        <h1 style={{ color: "#fff", fontFamily: "sans-serif" }}>Loading...</h1>
      </div>
    );
  }

  const currentQuestion = questions[currentQuestionIndex];

  return (
    <div style={styles.page}>
      {/* Top bar */}
      <div style={styles.topBar}>
        <div style={styles.statBox}>
          <span style={styles.statLabel}>⏱ Time</span>
          <span style={{ ...styles.statValue, color: timeRemaining <= 5 ? "#ff4d4d" : "#f97316" }}>
            {timeRemaining}s
          </span>
        </div>

        <button onClick={handleExit} style={styles.exitButton}>
          ✕ Exit
        </button>

        <div style={styles.statBox}>
          <span style={styles.statLabel}>⭐ Score</span>
          <span style={styles.statValue}>{score}</span>
        </div>
      </div>

      {/* Title */}
      <h1 style={styles.title}>{title}</h1>

      {/* Prompt */}
      <div style={styles.promptCard}>
        <h2 style={styles.prompt}>{currentQuestion.prompt}</h2>
        <p style={styles.questionCount}>
          Question {currentQuestionIndex + 1} of {questions.length}
        </p>
      </div>

      {/* Answer buttons */}
      <div style={styles.answersGrid}>
        {currentQuestion.answers.map((answer, index) => (
          <button
            key={index}
            onClick={() => handleAnswerClick(answer)}
            style={styles.answerButton}
            onMouseEnter={(e) => {
              e.currentTarget.style.background = "rgba(249,115,22,0.25)";
              e.currentTarget.style.borderColor = "#f97316";
              e.currentTarget.style.transform = "scale(1.04)";
            }}
            onMouseLeave={(e) => {
              e.currentTarget.style.background = "rgba(255,255,255,0.07)";
              e.currentTarget.style.borderColor = "rgba(255,255,255,0.15)";
              e.currentTarget.style.transform = "scale(1)";
            }}
          >
            {answer.name}
          </button>
        ))}
      </div>

      {/* Result */}
      {result && (
        <div style={{
          ...styles.resultBadge,
          background: (result === "Correct!" || result === "Quiz Finished!")
            ? "rgba(34,197,94,0.2)"
            : "rgba(239,68,68,0.2)",
          borderColor: (result === "Correct!" || result === "Quiz Finished!")
            ? "#22c55e"
            : "#ef4444",
          color: (result === "Correct!" || result === "Quiz Finished!")
            ? "#22c55e"
            : "#ef4444",
        }}>
          {result}
        </div>
      )}

      {/* Next button */}
      <button
        onClick={handleNextQuestion}
        style={styles.nextButton}
        onMouseEnter={(e) => e.currentTarget.style.opacity = "0.85"}
        onMouseLeave={(e) => e.currentTarget.style.opacity = "1"}
      >
        Next Question →
      </button>
    </div>
  );
}

const styles = {
  page: {
    minHeight: "100vh",
    background: "linear-gradient(135deg, #1a1040 0%, #2d1b69 40%, #1e3a5f 100%)",
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    padding: "30px 20px",
    fontFamily: "'Segoe UI', sans-serif",
    boxSizing: "border-box",
  },
  topBar: {
    width: "100%",
    maxWidth: "800px",
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
    marginBottom: "30px",
  },
  statBox: {
    background: "rgba(255,255,255,0.08)",
    border: "1px solid rgba(255,255,255,0.15)",
    borderRadius: "16px",
    padding: "10px 24px",
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    gap: "2px",
  },
  statLabel: {
    color: "rgba(255,255,255,0.5)",
    fontSize: "12px",
    textTransform: "uppercase",
    letterSpacing: "1px",
  },
  statValue: {
    color: "#f97316",
    fontSize: "26px",
    fontWeight: "700",
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
  title: {
    fontSize: "clamp(22px, 4vw, 36px)",
    fontWeight: "800",
    background: "linear-gradient(90deg, #f97316, #ec4899)",
    WebkitBackgroundClip: "text",
    WebkitTextFillColor: "transparent",
    textAlign: "center",
    marginBottom: "20px",
  },
  promptCard: {
    background: "rgba(255,255,255,0.07)",
    border: "1px solid rgba(255,255,255,0.12)",
    borderRadius: "20px",
    padding: "24px 36px",
    textAlign: "center",
    maxWidth: "700px",
    width: "100%",
    marginBottom: "32px",
  },
  prompt: {
    color: "#fff",
    fontSize: "clamp(16px, 2.5vw, 22px)",
    fontWeight: "600",
    margin: "0 0 10px 0",
  },
  questionCount: {
    color: "rgba(255,255,255,0.45)",
    fontSize: "14px",
    margin: 0,
  },
  answersGrid: {
    display: "grid",
    gridTemplateColumns: "repeat(2, 1fr)",
    gap: "16px",
    maxWidth: "700px",
    width: "100%",
    marginBottom: "28px",
  },
  answerButton: {
    background: "rgba(255,255,255,0.07)",
    border: "1px solid rgba(255,255,255,0.15)",
    borderRadius: "16px",
    color: "#fff",
    fontSize: "clamp(14px, 2vw, 18px)",
    fontWeight: "600",
    padding: "28px 16px",
    cursor: "pointer",
    transition: "all 0.2s ease",
  },
  resultBadge: {
    border: "1px solid",
    borderRadius: "16px",
    padding: "14px 40px",
    fontSize: "20px",
    fontWeight: "700",
    marginBottom: "20px",
  },
  nextButton: {
    background: "linear-gradient(90deg, #f97316, #ec4899)",
    border: "none",
    borderRadius: "50px",
    color: "#fff",
    fontSize: "18px",
    fontWeight: "700",
    padding: "16px 48px",
    cursor: "pointer",
    transition: "opacity 0.2s",
  },
};

export default Quiz3;
