import { useEffect, useState } from "react";

function OddOneOut() {
  const [activities, setActivities] = useState(null);
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [score, setScore] = useState(0);
  const [result, setResult] = useState("");

  useEffect(() => {
    fetch("/data/odd-one-out/test_movie_odd_one_out.json")
      .then((response) => response.json())
      .then((data) => setActivities(data));
  }, []);

  function handleAnswerClick(item) {
    if (item.isOddOneOut) {
      setResult("Correct!");
      setScore(score + 1);
    } else {
      setResult("Incorrect, try again.");
    }
  }

  function handleNextQuestion() {
    setResult("");

    if (currentQuestionIndex < activities.length - 1) {
      setCurrentQuestionIndex(currentQuestionIndex + 1);
    } else {
      setResult("Quiz finished!");
    }
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
        style={{
          float: "left",
          fontSize: "24px",
        }}
      >
        Time: 60
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
            color: result === "Correct!" ? "green" : "red"
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