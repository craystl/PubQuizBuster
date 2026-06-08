import { useState, useEffect, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import {
  checkMultipleChoiceAnswer,
  calculateNewScore,
  getCorrectAnswers,
} from "../gameLogic/multipleChoiceLogic";

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

    alert(
      isCorrect
        ? "Correct!"
        : "Wrong! Either wrong answer selected, or not all correct answers selected."
    );
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
    <div style={{ fontFamily: "Arial, sans-serif", padding: "40px" }}>
      <p style={{ float: "left", fontSize: "24px" }}>
        Time:{" "}
        <span style={{ color: timeRemaining <= 5 ? "red" : "inherit" }}>
          {timeRemaining}
        </span>
      </p>
      <p style={{ float: "right", fontSize: "24px" }}>Score: {score}</p>
      <br />
      <br />
      <br />
      <h1 style={{ textAlign: "center", fontSize: "30px" }}>Multi-Choice</h1>
      <br />
      <h2 style={{ textAlign: "center", fontSize: "17px" }}>{questionText}</h2>
      <div style={{ textAlign: "center", fontSize: "30px" }}>
        {options.map((opt, i) => {
          const text = getOptionText(opt);
          return (
            <p key={i}>
              <input
                type="checkbox"
                name="answer"
                value={text}
                checked={selectedAnswers.includes(text)}
                onChange={() => toggleAnswer(text)}
              />{" "}
              {text}
            </p>
          );
        })}
        <br />
        <button
          onClick={handleSubmit}
          style={{
            background: "black",
            color: "white",
            padding: "10px 25px",
            fontSize: "25px",
          }}
        >
          Submit
        </button>
      </div>
      <button
        onClick={handleExit}
        style={{
          marginTop: "20px",
          background: "rgba(239,68,68,0.15)",
          border: "1px solid rgba(239,68,68,0.4)",
          color: "#ef4444",
          borderRadius: "20px",
          padding: "10px 24px",
          fontSize: "15px",
          cursor: "pointer",
          fontWeight: "600",
        }}
      >
        ✕ Exit
      </button>
    </div>
  );
}

export default MultiChoice;
