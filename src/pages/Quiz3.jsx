import { useEffect, useState, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import {
  hasNextQuestion,
  getNextQuestionIndex,
} from "../gameLogic/oddOneOutLogic";
import { calculatePoints } from "../gameLogic/scoring";

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
      console.log("Quiz data received:", quizData);

      setTitle(quizData.title || "Odd One Out Quiz");

      const loadedQuestions =
        quizData.questions ||
        quizData.activities ||
        quizData;

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
    const correct =
      answer.isCorrectOddOneOut === true || answer.isOddOneOut === true;

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

    setCurrentQuestionIndex(
      getNextQuestionIndex(currentQuestionIndex, questions.length)
    );
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
      <div style={styles.timerBadge}>⏳ Time: {timeRemaining}</div>
      <div style={styles.scoreBadge}>🏆 Score: {score}</div>

      <h1 style={styles.title}>{title}</h1>

      <p style={styles.subtitle}>
        {currentQuestion.prompt || currentQuestion.question}
      </p>

      <p style={styles.questionCount}>
        Question {currentQuestionIndex + 1} of {questions.length}
      </p>

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
        <div
          style={{
            ...styles.resultBadge,
            background:
              result === "Correct!"
                ? "rgba(34,197,94,0.2)"
                : "rgba(239,68,68,0.2)",
            borderColor: result === "Correct!" ? "#22c55e" : "#ef4444",
            color: result === "Correct!" ? "#22c55e" : "#ef4444",
          }}
        >
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
