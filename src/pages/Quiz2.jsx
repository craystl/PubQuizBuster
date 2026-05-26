import { useState, useEffect, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";

function MultiChoice() {
  const [timeRemaining, setTimeRemaining] = useState(60);
  const timerRef = useRef(null);

  useEffect(() => {
    timerRef.current = createTimer(
      60,
      (t) => setTimeRemaining(t),
      () => alert("Time's up!"),
      (t) => console.log("Warning!", t)
    );
    return () => stopTimer(timerRef.current);
  }, []);

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
        Score: 0
      </p>

      <br />
      <br />
      <br />

      <h1
        style={{
          textAlign: "center",
          fontSize: "30px",
        }}
      >
        Multi-Choice
      </h1>

      <br />

      <h2
        style={{
          textAlign: "center",
          fontSize: "17px",
        }}
      >
        Question
      </h2>

      <div
        style={{
          textAlign: "center",
          fontSize: "30px",
        }}
      >
        <p>
          <input type="radio" name="answer" /> Cat
        </p>

        <p>
          <input type="radio" name="answer" /> Dog
        </p>

        <p>
          <input type="radio" name="answer" /> Bird
        </p>

        <br />

        <button
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