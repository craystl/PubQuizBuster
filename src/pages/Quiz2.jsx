import { useState, useEffect, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import {
  checkMultipleChoiceAnswer,
  calculateNewScore,
  getCorrectAnswers,
} from "../gameLogic/multipleChoiceLogic";

function MultiChoice() {
  const [gameData, setGameData] = useState(null);
  const [currentIndex, setCurrentIndex] = useState(0);
  const [timeRemaining, setTimeRemaining] = useState(60);
  const [score, setScore] = useState(0);
  const [selectedAnswers, setSelectedAnswers] = useState([]); // now an array
  const timerRef = useRef(null);

  useEffect(() => {
    fetch("/data/multiple-choice/test_geography_multiple_choice.json")
      .then(res => res.json())
      .then(data => setGameData(data));
  }, []);

  const questions = gameData?.Questions || gameData?.questions || [];
  const currentQuestion = questions[currentIndex];

  // Support both new format (Prompt, Answers[].Text) and old format
  const questionText = currentQuestion?.Prompt || currentQuestion?.text || currentQuestion?.question || "";
  const options = currentQuestion?.Answers || currentQuestion?.options || currentQuestion?.choices || [];
  const correctAnswers = getCorrectAnswers(options.length && options[0]?.IsCorrect !== undefined
    ? options
    : options.map(opt => ({ Text: opt, IsCorrect: opt === currentQuestion?.correctAnswer }))
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
  }, [currentIndex, gameData]);

  const toggleAnswer = (text) => {
    setSelectedAnswers(prev =>
      prev.includes(text) ? prev.filter(a => a !== text) : [...prev, text]
    );
  };

  const handleSubmit = () => {
    if (selectedAnswers.length === 0) return;
    const isCorrect = checkMultipleChoiceAnswer(selectedAnswers, correctAnswers);
    setScore(calculateNewScore(score, isCorrect));
    alert(isCorrect ? "Correct!" : "Wrong!");
    stopTimer(timerRef.current);
    if (currentIndex + 1 < questions.length) {
      setCurrentIndex(currentIndex + 1);
      setSelectedAnswers([]);
    } else {
      alert(`Game Over! Score: ${score + (isCorrect ? 100 : 0)}`);
    }
  };

  const getOptionText = (opt) => opt?.Text ?? opt;

  if (!gameData) return <div>Loading...</div>;

  return (
    <div style={{ fontFamily: "Arial, sans-serif", padding: "40px" }}>
      <p style={{ float: "left", fontSize: "24px" }}>
        Time: <span style={{ color: timeRemaining <= 5 ? "red" : "inherit" }}>{timeRemaining}</span>
      </p>
      <p style={{ float: "right", fontSize: "24px" }}>Score: {score}</p>
      <br /><br /><br />
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
              /> {text}
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
    </div>
  );
}

export default MultiChoice;