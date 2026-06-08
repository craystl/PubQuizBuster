import { useState, useEffect, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import {
  checkMultipleChoiceAnswer,
  calculateNewScore,
  getCorrectAnswers,
} from "../gameLogic/multipleChoiceLogic";

const styles = {
  page: {
    minHeight: "100vh",
    width: "100%",
    background: "linear-gradient(135deg, #0f0c29 0%, #302b63 50%, #24243e 100%)",
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    justifyContent: "center",
    padding: "80px 20px 40px 20px",
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
    fontSize: "clamp(1.5rem, 3vw, 2.2rem)",
    background: "linear-gradient(90deg, #fbbf24, #f87171, #a78bfa, #34d399, #fbbf24)",
    backgroundSize: "300% auto",
    WebkitBackgroundClip: "text",
    WebkitTextFillColor: "transparent",
    paddingTop: "16px",
    paddingBottom: "8px",
    lineHeight: "1.3",
    textAlign: "center",
    marginBottom: "8px",
  },
  subtitle: {
    color: "#d8d4ff",
    fontSize: "1.2rem",
    textAlign: "center",
    maxWidth: "600px",
    marginBottom: "24px",
  },
  optionsGrid: {
    display: "grid",
    gridTemplateColumns: "repeat(2, 1fr)",
    gap: "16px",
    maxWidth: "600px",
    width: "100%",
    marginBottom: "24px",
  },
  optionLabel: {
    background: "rgba(255,255,255,0.08)",
    border: "1px solid rgba(255,255,255,0.15)",
    borderRadius: "16px",
    padding: "16px 20px",
    color: "white",
    fontSize: "1rem",
    fontWeight: "700",
    cursor: "pointer",
    display: "flex",
    alignItems: "center",
    gap: "12px",
    transition: "all 0.2s ease",
    fontFamily: "'Nunito', sans-serif",
  },
  optionLabelSelected: {
    background: "rgba(167,139,250,0.25)",
    border: "1px solid rgba(167,139,250,0.6)",
    borderRadius: "16px",
    padding: "16px 20px",
    color: "white",
    fontSize: "1rem",
    fontWeight: "700",
    cursor: "pointer",
    display: "flex",
    alignItems: "center",
    gap: "12px",
    transition: "all 0.2s ease",
    fontFamily: "'Nunito', sans-serif",
  },
  submitButton: {
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

function MultiChoice({ quizData, onExit, onFinish }) {
  const [currentIndex, setCurrentIndex] = useState(0);
  const [timeRemaining, setTimeRemaining] = useState(60);
  const [score, setScore] = useState(0);
  const scoreRef = useRef(0);
  const [selectedAnswers, setSelectedAnswers] = useState([]);
  const timerRef = useRef(null);

  const questions = quizData?.Questions || quizData?.questions || [];
  const currentQuestion = questions[currentIndex];

  const questionText =
    currentQuestion?.Prompt ||
    currentQuestion?.text ||
    currentQuestion?.question ||
    "";

  const options =
    currentQuestion?.Answers ||
    currentQuestion?.options ||
    currentQuestion?.choices ||
    [];

  const correctAnswers = getCorrectAnswers(
    options.length && options[0]?.IsCorrect !== undefined
      ? options
      : options.map((opt) => ({
          Text: opt,
          IsCorrect: opt === currentQuestion?.correctAnswer,
        }))
  );

  useEffect(() => {
    if (!currentQuestion) return;
    if (timerRef.current) stopTimer(timerRef.current);
    timerRef.current = createTimer(
      60,
      (t) => setTimeRemaining(t),
      () => alert("Time's up!"),
      (t) => console.log("Warning!", t)
    );
    return () => stopTimer(timerRef.current);
  }, [currentIndex, quizData]);

  const toggleAnswer = (text) => {
    setSelectedAnswers((prev) =>
      prev.includes(text) ? prev.filter((a) => a !== text) : [...prev, text]
    );
  };

  const handleSubmit = () => {
    if (selectedAnswers.length === 0) return;
    const isCorrect = checkMultipleChoiceAnswer(selectedAnswers, correctAnswers);
    const newScore = calculateNewScore(score, isCorrect);
    setScore(newScore);
    scoreRef.current = newScore;

    alert(isCorrect ? "✅ Correct!" : "❌ Wrong! Either wrong answer selected, or not all correct answers selected.");
    stopTimer(timerRef.current);

    if (currentIndex + 1 < questions.length) {
      setCurrentIndex(currentIndex + 1);
      setSelectedAnswers([]);
    } else {
      onFinish(scoreRef.current);
    }
  };

  function handleExit() {
    if (confirm("Are you sure you want to exit the quiz?")) {
      onExit();
    }
  }

  const getOptionText = (opt) => opt?.Text ?? opt;

  if (!quizData) return <div>Loading...</div>;

  return (
    <div style={styles.page}>
      <style>{`@import url('https://fonts.googleapis.com/css2?family=Fredoka+One&family=Nunito:wght@400;700;900&display=swap');`}</style>

      {/* Background blobs */}
      <div style={{ position: "absolute", width: "500px", height: "500px", background: "#7c3aed", borderRadius: "50%", filter: "blur(120px)", opacity: 0.25, top: "-150px", left: "-100px", pointerEvents: "none" }} />
      <div style={{ position: "absolute", width: "400px", height: "400px", background: "#f59e0b", borderRadius: "50%", filter: "blur(120px)", opacity: 0.15, bottom: "-120px", right: "-80px", pointerEvents: "none" }} />

      <div style={styles.timerBadge}>
        ⏳ Time: <span style={{ color: timeRemaining <= 5 ? "#ff6b6b" : "#fff" }}>{timeRemaining}</span>
      </div>
      <div style={styles.scoreBadge}>🏆 Score: {score}</div>

      <h1 style={styles.title}>Multi-Choice</h1>
      <p style={styles.subtitle}>{questionText}</p>

      <div style={styles.optionsGrid}>
        {options.map((opt, i) => {
          const text = getOptionText(opt);
          const selected = selectedAnswers.includes(text);
          return (
            <label
              key={i}
              style={selected ? styles.optionLabelSelected : styles.optionLabel}
            >
              <input
                type="checkbox"
                value={text}
                checked={selected}
                onChange={() => toggleAnswer(text)}
                style={{ accentColor: "#a78bfa", width: "18px", height: "18px" }}
              />
              {text}
            </label>
          );
        })}
      </div>

      <button onClick={handleSubmit} style={styles.submitButton}>
        Submit
      </button>
      <button onClick={handleExit} style={styles.exitButton}>
        ✕ Exit
      </button>
    </div>
  );
}

export default MultiChoice;
