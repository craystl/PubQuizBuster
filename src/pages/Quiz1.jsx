import { useState, useEffect, useRef } from "react";
import { createTimer, stopTimer } from "../gameLogic/timerLogic";
import { createBoard, flipCard, evaluateFlip, resetBoard, calculateNewScore } from "../gameLogic/memoryFlipLogic";

function MemoryFlip({ onExit }) {
  const [gameData, setGameData] = useState(null);
  const [board, setBoard] = useState(null);
  const [score, setScore] = useState(0);
  const [timeRemaining, setTimeRemaining] = useState(60);
  const timerRef = useRef(null);

  useEffect(() => {
    fetch("/data/memory-flip/music_memory_flip.json")
      .then(res => res.json())
      .then(data => setGameData(data));
  }, []);

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

  function handleExit() {
    if (confirm("Are you sure you want to exit the quiz?")) {
      onExit();
    }
  }

  if (!board) return <div>Loading...</div>;

return (
  <>
    <style>{`
@import url('https://fonts.googleapis.com/css2?family=Fredoka+One&family=Nunito:wght@400;700;900&display=swap');

@keyframes shimmer {
  0% { background-position: -200% center; }
  100% { background-position: 200% center; }
}

.memory-title {
  font-family: 'Fredoka One', cursive;
  font-size: clamp(2.5rem, 5vw, 4rem);
  background: linear-gradient(
    90deg,
    #fbbf24,
    #f87171,
    #a78bfa,
    #34d399,
    #fbbf24
  );
  background-size: 300% auto;
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  animation: shimmer 6s linear infinite;
  margin-bottom: 10px;
  line-height: 1.2;
}

.memory-text {
  font-family: 'Nunito', sans-serif;
  color: #d8d4ff;
  font-size: 1.1rem;
  max-width: 600px;
  line-height: 1.6;
}

.memory-panel {
  background: rgba(255,255,255,0.08);
  backdrop-filter: blur(12px);
  border: 1px solid rgba(255,255,255,0.15);
  border-radius: 20px;
  padding: 12px 24px;
  color: white;
  font-family: 'Nunito', sans-serif;
  font-weight: 800;
  box-shadow: 0 10px 30px rgba(0,0,0,0.25);
}

.memory-card {
  width: 150px;
  height: 200px;
  border-radius: 20px;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  text-align: center;
  padding: 14px;
  font-family: 'Nunito', sans-serif;
  font-weight: 800;
  transition: all 0.25s ease;
  user-select: none;
}

.memory-card:hover {
  transform: translateY(-6px) scale(1.03);
}

.memory-card-back {
  background: linear-gradient(
    135deg,
    rgba(124,58,237,0.9),
    rgba(59,130,246,0.8)
  );
  color: white;
  border: 2px solid rgba(255,255,255,0.15);
  box-shadow: 0 10px 25px rgba(124,58,237,0.4);
}

.memory-card-front {
  background: rgba(255,255,255,0.12);
  backdrop-filter: blur(14px);
  border: 1px solid rgba(255,255,255,0.2);
  color: white;
}

.memory-card-matched {
  background: linear-gradient(
    135deg,
    #10b981,
    #34d399
  );
  color: white;
  box-shadow: 0 0 25px rgba(52,211,153,0.6);
}
`}</style>
  
    <div
    style={{
      minHeight: "100vh",
      width: "100%",
      background:
        "linear-gradient(135deg, #0f0c29 0%, #302b63 50%, #24243e 100%)",
      display: "flex",
      flexDirection: "column",
      alignItems: "center",
      padding: "40px 20px",
      position: "relative",
      overflow: "hidden",
      boxSizing: "border-box",
    }}
  >
    {/* Background blobs */}
    <div
      style={{
        position: "absolute",
        width: "500px",
        height: "500px",
        background: "#7c3aed",
        borderRadius: "50%",
        filter: "blur(120px)",
        opacity: 0.25,
        top: "-150px",
        left: "-100px",
      }}
    />

    <div
      style={{
        position: "absolute",
        width: "400px",
        height: "400px",
        background: "#f59e0b",
        borderRadius: "50%",
        filter: "blur(120px)",
        opacity: 0.15,
        bottom: "-120px",
        right: "-80px",
      }}
    />

    {/* Timer */}
    <div
      className="memory-panel"
      style={{
        position: "fixed",
        left: "30px",
        top: "30px",
        zIndex: 20,
      }}
    >
      ⏳ Time:{" "}
      <span
        style={{
          color: timeRemaining <= 5 ? "#ff6b6b" : "#fff",
        }}
      >
        {timeRemaining}
      </span>
    </div>

    {/* Score */}
    <div
      className="memory-panel"
      style={{
        position: "fixed",
        right: "30px",
        top: "30px",
        zIndex: 20,
      }}
    >
      🏆 Score: {score}
    </div>

    <div
      style={{
        position: "relative",
        zIndex: 10,
        textAlign: "center",
        width: "100%",
        maxWidth: "1200px",
        margin: "0 auto",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <h1 className="memory-title">Memory Flip</h1>

      <p className="memory-text">
        Match the correct cards and build your score before the timer runs out.
      </p>

      <div
        style={{
          display: "flex",
          gap: "20px",
          flexWrap: "wrap",
          justifyContent: "center",
          marginTop: "50px",
          maxWidth: "1000px",
        }}
      >
        {board.cards.map((card) => {
          let className = "memory-card memory-card-back";

          if (card.isFlipped) {
            className = "memory-card memory-card-front";
          }

          if (card.isMatched) {
            className = "memory-card memory-card-matched";
          }

          return (
            <div
              key={card.id}
              className={className}
              onClick={() => handleCardClick(card.id)}
            >
              {card.isFlipped || card.isMatched
                ? card.value
                : "❓"}
            </div>
          );
        })}
      </div>
    </div>

    {/* Exit button — matches Quiz3 style */}
    <button
      onClick={handleExit}
      style={{
        position: "fixed",
        bottom: "30px",
        left: "30px",
        background: "rgba(239,68,68,0.15)",
        border: "1px solid rgba(239,68,68,0.4)",
        color: "#ef4444",
        borderRadius: "20px",
        padding: "10px 24px",
        fontSize: "15px",
        cursor: "pointer",
        fontWeight: "600",
        zIndex: 20,
      }}
    >
      ✕ Exit
    </button>
  </div>
  </>
);
}

export default MemoryFlip;
