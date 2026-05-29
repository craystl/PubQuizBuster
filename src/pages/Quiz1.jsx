import { useState, useEffect, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import { createBoard, flipCard, evaluateFlip, resetBoard, calculateNewScore } from "../gameLogic/memoryFlipLogic";

// function MemoryFlip({ gameData }) {  ← deleted: now fetches own data like OddOneOut
function MemoryFlip() {
  const [gameData, setGameData] = useState(null);
  const [board, setBoard] = useState(null);
  const [score, setScore] = useState(0);
  const [timeRemaining, setTimeRemaining] = useState(60);
  const timerRef = useRef(null);

  useEffect(() => {
    fetch("/data/memory-flip/test_music_memory_flip.json")
      .then(res => res.json())
      .then(data => setGameData(data));
  }, []);

  // const data = gameData;  ← deleted: no longer needed
  // useEffect(() => {
  //   if (data?.cards?.length) setBoard(createBoard(data));
  // }, [data]);
  useEffect(() => {
    if (gameData?.cards?.length) setBoard(createBoard(gameData));
  }, [gameData]);

  useEffect(() => {
    if (!board || board.isSolved) return;
    timerRef.current = createTimer(60, (t) => setTimeRemaining(t), () => alert("Time's up!"));
    return () => stopTimer(timerRef.current);
  }, [board?.isSolved]);

  const handleCardClick = (cardId) => {
    if (!board || board.isSolved) return;
    let newBoard = flipCard(board, cardId);
    if (newBoard.flippedIds.length === 3) {
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
      <h1 style={{ fontSize: "2rem", marginBottom: "30px", color: "#111" }}>
        Memory Flip
      </h1>
      <p style={{ maxWidth: "500px", fontSize: "1.1rem", color: "#444", margin: "0 auto 25px auto", lineHeight: "1.5" }}>
        *Question*
      </p>
      <div style={{ position: "fixed", top: "30px", right: "30px", fontSize: "1.5rem", color: "#111" }}>
        {/* Score: <span id="score">0</span>  ← deleted: was hardcoded static */}
        Score: <span>{score}</span>
      </div>
      {/* deleted: 5 hardcoded static divs with no onClick or state connection */}
      {/* <div style={{ width: "150px", height: "200px", background: "#9ad5de" ... }}></div> × 5 */}
      <div style={{ display: "flex", gap: "20px", marginTop: "40px", flexWrap: "wrap", justifyContent: "center" }}>
        {board.cards.map((card) => (
          <div
            key={card.id}
            onClick={() => handleCardClick(card.id)}
            style={{
              width: "150px",
              height: "200px",
              borderRadius: "8px",
              cursor: "pointer",
              background: card.isMatched ? "#a8e6a3" : card.isFlipped ? "#fff" : "#9ad5de",
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
              fontSize: "1rem",
              padding: "10px",
              textAlign: "center",
              border: "2px solid #ccc",
            }}
          >
            {(card.isFlipped || card.isMatched) ? card.value : "?"}
          </div>
        ))}
      </div>
      <div style={{ position: "fixed", top: "30px", left: "30px", fontSize: "1.5rem" }}>
        {/* Time: <span id="timer">60</span>  ← deleted: was hardcoded static */}
        Time: <span style={{ color: timeRemaining <= 5 ? "red" : "inherit" }}>{timeRemaining}</span>
      </div>
    </div>
  );
}

export default MemoryFlip;