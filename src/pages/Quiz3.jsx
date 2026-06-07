import { useEffect, useState, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import { checkOddOneOutAnswer, getAnswerMessage, hasNextQuestion, getNextQuestionIndex } from "../gameLogic/oddOneOutLogic";
import { calculatePoints, saveHighScore } from "../gameLogic/scoring";

function Quiz3({ onExit, onFinish }) {
  const [questions, setQuestions] = useState(null);
  const [title, setTitle] = useState("");
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [score, setScore] = useState(0);
  const scoreRef = useRef(0);
  const [result, setResult] = useState("");
  const [isCorrect, setIsCorrect] = useState(null);
  const [timeRemaining, setTimeRemaining] = useState(60);
  const timerRef = useRef(null);

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
    const correct = answer.isCorrectOddOneOut === true;
    const points = calculatePoints(correct, timeRemaining, 0);
    setIsCorrect(correct);
    setResult(correct ? "Correct!" : "Wrong!");
    const newScore = score + points;
    setScore(newScore);
    scoreRef.current = newScore;
  }

  function handleNextQuestion() {
    setResult("");
    setIsCorrect(null);
    if (!hasNextQuestion(currentQuestionIndex, questions.length)) {
      stopTimer(timerRef.current);
      onFinish(scoreRef.current);
      return;
    }
    setCurrentQuestionIndex(getNextQuestionIndex(currentQuestionIndex, questions.length));
  }

  function handleExit() {
    if (confirm("Are you sure you want to exit the quiz?")) {
      onExit();
    }
  }

  if (!questions) {
    return (
      <div style={styles.page}>
        <h1 style={{ color: "#fff" }}>Loading...</h1>
      </div>
    );
  }

  const currentQuestion = questions[currentQuestionIndex];

  return (
    <div style={styles.page}>
      <div style={styles.timerBadge}>⏳ Time: {timeRemaining}</div>
      <div style={styles.scoreBadge}>🏆 Score: {score}</div>

      <h1 style={styles.title}>{title}</h1>
      <p style={styles.subtitle}>{currentQuestion.prompt}</p>
      <p style={styles.questionCount}>Question {currentQuestionIndex + 1} of {questions.length}</p>

      <div style={styles.answersGrid}>
        {currentQuestion.answers.map((answer, index) => (
          <button
            key={index}
            onClick={() => handleAnswerClick(answer)}
            style={styles.answerCard}
            onMouseEnter={(e) => {
              e.currentTarget.style.transform = "scale(1.05)";
              e.currentTarget.style.boxShadow = "0 8px 30px rgba(139,92,246,0.6)";
            }}
            onMouseLeave={(e) => {
              e.currentTarget.style.transform = "scale(1)";
              e.currentTarget.style.boxShadow = "0 4px 15px rgba(0,0,0,0.3)";
            }}
          >
            {answer.name}
          </button>
        ))}
      </div>

      {result && (
        <div style={{
          ...styles.resultBadge,
          background: (result === "Correct!" || result === "Quiz Finished!") ? "rgba(34,197,94,0.2)" : "rgba(239,68,68,0.2)",
          borderColor: (result === "Correct!" || result === "Quiz Finished!") ? "#22c55e" : "#ef4444",
          color: (result === "Correct!" || result === "Quiz Finished!") ? "#22c55e" : "#ef4444",
        }}>
          {result === "Correct!" ? "✅ Correct!" : result === "Quiz Finished!" ? "🎉 Quiz Finished!" : "❌ Wrong!"}
        </div>
      )}

      <button
        onClick={handleNextQuestion}
        style={styles.nextButton}
        onMouseEnter={(e) => e.currentTarget.style.opacity = "0.85"}
        onMouseLeave={(e) => e.currentTarget.style.opacity = "1"}
      >
        Next Question →
      </button>

      <button onClick={handleExit} style={styles.exitButton}>✕ Exit</button>
    </div>
  );
}

const styles = {
  page: {
    minHeight: "100vh",
    background: "linear-gradient(135deg, #1a1a2e 0%, #16213e 50%, #0f3460 100%)",
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    padding: "120px 20px 100px",
    fontFamily: "'Segoe UI', sans-serif",
    boxSizing: "border-box",
    position: "relative",
  },
  timerBadge: {
    position: "fixed",
    top: "20px",
    left: "20px",
    background: "rgba(30,30,50,0.85)",
    border: "1px solid rgba(255,255,255,0.1)",
    borderRadius: "50px",
    padding: "10px 20px",
    color: "#fff",
    fontSize: "16px",
    fontWeight: "700",
    zIndex: 10,
  },
  scoreBadge: {
    position: "fixed",
    top: "20px",
    right: "20px",
    background: "rgba(30,30,50,0.85)",
    border: "1px solid rgba(255,255,255,0.1)",
    borderRadius: "50px",
    padding: "10px 20px",
    color: "#fff",
    fontSize: "16px",
    fontWeight: "700",
    zIndex: 10,
  },
  title: {
    fontSize: "clamp(20px, 3.5vw, 34px)",
    fontWeight: "800",
    background: "linear-gradient(90deg, #f472b6, #a78bfa, #67e8f9)",
    WebkitBackgroundClip: "text",
    WebkitTextFillColor: "transparent",
    textAlign: "center",
    margin: "0 0 16px 0",
    lineHeight: "1.3",
    padding: "0 10px",
  },
  subtitle: {
    color: "rgba(255,255,255,0.75)",
    fontSize: "clamp(14px, 2vw, 18px)",
    textAlign: "center",
    margin: "0 0 8px 0",
    maxWidth: "600px",
  },
  questionCount: {
    color: "rgba(255,255,255,0.4)",
    fontSize: "14px",
    margin: "0 0 32px 0",
  },
  answersGrid: {
    display: "grid",
    gridTemplateColumns: "repeat(2, 1fr)",
    gap: "20px",
    maxWidth: "700px",
    width: "100%",
    marginBottom: "28px",
  },
  answerCard: {
    background: "linear-gradient(135deg, #6d28d9, #4f46e5)",
    border: "none",
    borderRadius: "16px",
    color: "#fff",
    fontSize: "clamp(14px, 2vw, 18px)",
    fontWeight: "700",
    padding: "40px 20px",
    cursor: "pointer",
    transition: "all 0.2s ease",
    boxShadow: "0 4px 15px rgba(0,0,0,0.3)",
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
    background: "linear-gradient(90deg, #f472b6, #a78bfa)",
    border: "none",
    borderRadius: "50px",
    color: "#fff",
    fontSize: "18px",
    fontWeight: "700",
    padding: "16px 48px",
    cursor: "pointer",
    transition: "opacity 0.2s",
    boxShadow: "0 4px 20px rgba(167,139,250,0.4)",
    marginBottom: "20px",
  },
  exitButton: {
    position: "fixed",
    bottom: "30px",
    left: "30px",
    background: "rgba(239,68,68,0.15)",
    border: "1px solid rgba(239,68,68,0.4)",
    color: "#ef4444",
    borderRadius: "20px",
    padding: "10px 24px",
    fontSize: "15px",
    cursor: "pointer",
    fontWeight: "600",
    zIndex: 10,
  },
};

export default Quiz3;
