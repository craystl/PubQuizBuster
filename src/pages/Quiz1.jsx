import { useState, useEffect, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import { createBoard, flipCard, evaluateFlip, resetBoard, calculateNewScore } from "../gameLogic/memoryFlipLogic";

function MemoryFlip({ gameData }) {
  const [board, setBoard] = useState(null);
  const [score, setScore] = useState(0);
  const [timeRemaining, setTimeRemaining] = useState(60);
  const timerRef = useRef(null);

  const pairs = gameData?.pairs || gameData || [];

  useEffect(() => {
    if (pairs.length) setBoard(createBoard(pairs));
  }, [pairs]);

  useEffect(() => {
    if (!board || board.isSolved) return;
    timerRef.current = createTimer(60, (t) => setTimeRemaining(t), () => alert("Time's up!"));
    return () => stopTimer(timerRef.current);
  }, [board?.isSolved]);

  const handleCardClick = (cardId) => {
    if (!board || board.isSolved) return;
    
    let newBoard = flipCard(board, cardId);
    
    if (newBoard.flippedIds.length === 3) { // Match 3 cards (1 + 2)
      const { board: evaluatedBoard, isMatch } = evaluateFlip(newBoard);
      newBoard = evaluatedBoard;
      if (isMatch) setScore(calculateNewScore(score, true));
      
      setTimeout(() => setBoard(resetBoard(newBoard)), isMatch ? 0 : 1000);
      return;
    }
    
    setBoard(newBoard);
  };

  if (!board) return <div>Loading...</div>;

  return (
    <div
      style={{
        margin: 0,
        fontFamily: "Arial, sans-serif",
        background: "white",
        display: "flex",
        flexDirection: "column",
        justifyContent: "flex-start",
        alignItems: "center",
        minHeight: "100vh",
        paddingTop: "40px",
        textAlign: "center",
      }}
    >
      <h1
        style={{
          fontSize: "2rem",
          marginBottom: "30px",
          color: "#111",
        }}
      >
        Memory Flip
      </h1>

      <p
        style={{
          maxWidth: "500px",
          fontSize: "1.1rem",
          color: "#444",
          margin: "0 auto 25px auto",
          lineHeight: "1.5",
        }}
      >
        *Question*
      </p>

      <div
        style={{
          position: "fixed",
          top: "30px",
          right: "30px",
          fontSize: "1.5rem",
          color: "#111",
        }}
      >
        Score: <span id="score">0</span>
      </div>

      <div
        style={{
          display: "flex",
          gap: "20px",
          marginTop: "40px",
        }}
      >
        <div
          style={{
            width: "150px",
            height: "200px",
            background: "#9ad5de",
            borderRadius: "8px",
            cursor: "pointer",
          }}
        ></div>

        <div
          style={{
            width: "150px",
            height: "200px",
            background: "#9ad5de",
            borderRadius: "8px",
            cursor: "pointer",
          }}
        ></div>

        <div
          style={{
            width: "150px",
            height: "200px",
            background: "#9ad5de",
            borderRadius: "8px",
            cursor: "pointer",
          }}
        ></div>

        <div
          style={{
            width: "150px",
            height: "200px",
            background: "#9ad5de",
            borderRadius: "8px",
            cursor: "pointer",
          }}
        ></div>

        <div
          style={{
            width: "150px",
            height: "200px",
            background: "#9ad5de",
            borderRadius: "8px",
            cursor: "pointer",
          }}
        ></div>
      </div>

      <div
        style={{
          position: "fixed",
          top: "30px",
          left: "30px",
          fontSize: "1.5rem",
        }}
      >
        Time: <span id="timer">60</span>
      </div>
    </div>
  );
}

export default MemoryFlip;
