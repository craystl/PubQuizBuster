import { useEffect, useState, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import { checkOddOneOutAnswer, getAnswerMessage, hasNextQuestion, getNextQuestionIndex } from "../gameLogic/oddOneOutLogic";
import { calculatePoints, saveHighScore } from "../gameLogic/scoring";

function Quiz3() {
  const [questions, setQuestions] = useState(null);
  const [title, setTitle] = useState("");
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [score, setScore] = useState(0);
  const [result, setResult] = useState("");
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

  if (!questions) {
    return <h1>Loading...</h1>;
  }

  const currentQuestion = questions[currentQuestionIndex];

  return (
    <div
      style={{
        fontFamily: "Arial, sans-serif",
        padding: "40px",
      }}
    >
      <p
        style={{ float: "left", fontSize: "24px", color: timeRemaining <= 5 ? "red" : "#111" }}
      >
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
        {title}
      </h1>

      <h2
        style={{
          textAlign: "center",
          fontSize: "20px",
          color: "#222",
        }}
      >
        {currentQuestion.prompt}
      </h2>

      <p style={{ textAlign: "center" }}>
        Question {currentQuestionIndex + 1} of {questions.length}
      </p>

      <br />

      <div style={{ textAlign: "center" }}>
        {currentQuestion.answers.map((answer, index) => (
          <button
            key={index}
            onClick={() => handleAnswerClick(answer)}
            style={{
              width: "200px",
              height: "120px",
              fontSize: "25px",
              margin: "15px",
            }}
          >
            {answer.name}
          </button>
        ))}
      </div>

      {result && (
        <h2
          style={{
            textAlign: "center",
            color: (result === "Correct!" || result === "Quiz Finished!") ? "green" : "red",
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

export default Quiz3;
