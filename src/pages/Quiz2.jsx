import { useState, useEffect, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import { checkMultipleChoiceAnswer, calculateNewScore } from "../gameLogic/multipleChoiceLogic";

function MultiChoice({ gameData }) {
  const [currentIndex, setCurrentIndex] = useState(0);
  const [timeRemaining, setTimeRemaining] = useState(60);
  const [score, setScore] = useState(0);
  const [selectedAnswer, setSelectedAnswer] = useState("");

  const timerRef = useRef(null);

  const questions = gameData?.questions || gameData || [];
  const currentQuestion = questions[currentIndex];
  const questionText = currentQuestion?.text || currentQuestion?.question || currentQuestion?.title || "";
  const options = currentQuestion?.options || currentQuestion?.choices || currentQuestion?.answers || [];
  const correctAnswer = currentQuestion?.correctAnswer || currentQuestion?.correct || currentQuestion?.answer || "";

  useEffect(() => {
    if (!currentQuestion) return;
    timerRef.current = createTimer(
      60,
      (t) => setTimeRemaining(t),
      () => alert("Time's up!"),
      (t) => console.log("Warning!", t)
    );
    return () => stopTimer(timerRef.current);
  }, [currentIndex]);

  const handleSubmit = () => {
    if (!selectedAnswer) return;
    const isCorrect = checkMultipleChoiceAnswer(selectedAnswer, correctAnswer);
    setScore(calculateNewScore(score, isCorrect));
    alert(isCorrect ? "Correct!" : "Wrong!");
    stopTimer(timerRef.current);
    if (currentIndex + 1 < questions.length) {
      setCurrentIndex(currentIndex + 1);
      setSelectedAnswer("");
    } else {
      alert(`Game Over! Score: ${score + (isCorrect ? 100 : 0)}`);
    }
  };

  return (
    <div style={{ fontFamily: "Arial, sans-serif", padding: "40px" }}>
      <p style={{ float: "left", fontSize: "24px" }}>
        {/* Time: 60  ← deleted: was hardcoded static */}
        Time: <span style={{ color: timeRemaining <= 5 ? "red" : "inherit" }}>{timeRemaining}</span>
      </p>

      <p style={{ float: "right", fontSize: "24px" }}>
        {/* Score: 0  ← deleted: was hardcoded static */}
        Score: {score}
      </p>

      <br /><br /><br />

      <h1 style={{ textAlign: "center", fontSize: "30px" }}>Multi-Choice</h1>
      <br />

      <h2 style={{ textAlign: "center", fontSize: "17px" }}>
        {/* Question  ← deleted: was hardcoded static */}
        {questionText}
      </h2>

      <div style={{ textAlign: "center", fontSize: "30px" }}>
        {/* deleted: hardcoded static radio inputs for Cat, Dog, Bird */}
        {/* <p><input type="radio" name="answer" /> Cat</p> */}
        {/* <p><input type="radio" name="answer" /> Dog</p> */}
        {/* <p><input type="radio" name="answer" /> Bird</p> */}
        {options.map((opt, i) => (
          <p key={i}>
            <input
              type="radio"
              name="answer"
              value={opt}
              checked={selectedAnswer === opt}
              onChange={() => setSelectedAnswer(opt)}
            /> {opt}
          </p>
        ))}

        <br />
        {/* <button style={...}>Submit</button>  ← deleted: had no onClick */}
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