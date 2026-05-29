import { useEffect, useState, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";

import { checkOddOneOutAnswer, getAnswerMessage, hasNextQuestion, getNextQuestionIndex } from "../gameLogic/oddOneOutLogic";
import { calculatePoints, saveHighScore } from "../gameLogic/scoring";

function OddOneOut() {
  const [activities, setActivities] = useState(null);
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [score, setScore] = useState(0);
  const [result, setResult] = useState("");
  const [timeRemaining, setTimeRemaining] = useState(60);
  const timerRef = useRef(null);

  useEffect(() => {
    fetch("/data/odd-one-out/test_movie_odd_one_out.json")
      .then((response) => response.json())
      .then((data) => setActivities(data));
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

  //function handleAnswerClick(item) {
    //if (item.isOddOneOut) {
      //setResult("Correct!");
      //setScore(score + 1);
    //} else {
      //setResult("Incorrect, try again.");
    //}
  //}
  function handleAnswerClick(item) 
  {
  const isCorrect = checkOddOneOutAnswer({ isOdd: item.isOddOneOut });
  const points = calculatePoints(isCorrect, timeRemaining, 0);
  setResult(getAnswerMessage(isCorrect));
  setScore(score + points);
  }

  //function handleNextQuestion() {
    //setResult("");

    //if (currentQuestionIndex < activities.length - 1) {
      //setCurrentQuestionIndex(currentQuestionIndex + 1);
    //} else {
      setResult("Quiz Finished!");
    //}
  //}
  function handleNextQuestion() 
  {
  setResult("");
  if (!hasNextQuestion(currentQuestionIndex, activities.length)) {
    setResult("Quiz Finished!");
    return;
  }
  setCurrentQuestionIndex(getNextQuestionIndex(currentQuestionIndex, activities.length));
  }

  if (!activities) {
    return <h1>Loading...</h1>;
  }

  const currentActivity = activities[currentQuestionIndex];

  return (
    <div
      style={{
        fontFamily: "Arial, sans-serif",
        padding: "40px",
      }}
    >
      <p 
        style={{ float: "left", fontSize: "24px", color: timeRemaining <= 5 ? "red" : "#111" }}> 
        Time: {timeRemaining} 
      </p>

      <p
        style={{
          float: "right",
          fontSize: "24px",
        }}
      >
        Score: {score}
      </p>

      <br />
      <br />
      <br />

      <h1
        style={{
          textAlign: "center",
          fontSize: "30px",
          color: "#111",
        }}
      >
        {currentActivity.title}
      </h1>

      <h2
        style={{
          textAlign: "center",
          fontSize: "20px",
          color: "#222",
        }}
      >
        {currentActivity.question}
      </h2>

      <p style={{ textAlign: "center" }}>
        Question {currentQuestionIndex + 1} of {activities.length}
      </p>

      <br />

      <div style={{ textAlign: "center" }}>
        {currentActivity.items.map((item, index) => (
          <button
            key={index}
            onClick={() => handleAnswerClick(item)}
            style={{
              width: "200px",
              height: "120px",
              fontSize: "25px",
              margin: "15px",
            }}
          >
            {item.name}
          </button>
        ))}
      </div>

      {result && (
        <h2
          style={{
            textAlign: "center",
            color: (result === "Correct!" || result === "Quiz Finished!") ? "green" : "red"
          }}
        >
          {result}
        </h2>
      )}

      <div style={{ textAlign: "center" }}>
        <button
          onClick={handleNextQuestion}
          style={{
            padding: "12px 30px",
            fontSize: "18px",
            marginTop: "20px",
            cursor: "pointer",
          }}
        >
          Next Question
        </button>
      </div>
    </div>
  );
}

export default OddOneOut;