import { useState } from "react";

const categories = [
  { icon: "🌍", label: "Geography", game: "multiple-choice", gameLabel: "Multiple Choice" },
  { icon: "🎬", label: "Movies", game: "odd-one-out", gameLabel: "Odd One Out" },
  { icon: "🎵", label: "Music", game: "memory-flip", gameLabel: "Memory Flip" },
];

function QuizMenu({ onSelectGame }) {
  const [hovered, setHovered] = useState(null);

  return (
    <div style={{
      width: "100%",
      height: "100vh",
      background: "linear-gradient(135deg, #0f0c29 0%, #302b63 50%, #24243e 100%)",
      display: "flex",
      flexDirection: "column",
      justifyContent: "center",
      alignItems: "center",
      overflow: "hidden",
      position: "relative",
      boxSizing: "border-box",
      fontFamily: "'Nunito', sans-serif",
    }}>
      <style>{`
        @import url('https://fonts.googleapis.com/css2?family=Fredoka+One&family=Nunito:wght@400;700;900&display=swap');
        @keyframes blobPulse {
          0%, 100% { border-radius: 60% 40% 30% 70% / 60% 30% 70% 40%; }
          50%       { border-radius: 30% 60% 70% 40% / 50% 60% 30% 60%; }
        }
        @keyframes slideUp {
          0%   { opacity: 0; transform: translateY(30px); }
          100% { opacity: 1; transform: translateY(0); }
        }
        @keyframes shimmer {
          0%   { background-position: -200% center; }
          100% { background-position: 200% center; }
        }
        .qm-blob {
          position: absolute;
          animation: blobPulse 8s ease-in-out infinite;
          pointer-events: none;
          filter: blur(80px);
          opacity: 0.25;
        }
        .qm-title {        
          font-family: 'Fredoka One', cursive;
          font-size: clamp(2.5rem, 5vw, 4rem);
          background: linear-gradient(90deg, #fbbf24, #f87171, #a78bfa, #34d399, #fbbf24);
          background-size: 300% auto;
          -webkit-background-clip: text;
          -webkit-text-fill-color: transparent;
          background-clip: text;
          animation: slideUp 0.6s cubic-bezier(0.22,1,0.36,1) 0.1s both,
          shimmer 5s linear 0.8s infinite;
          line-height: 1.2;
          margin: 0 0 16px 0;
          letter-spacing: 2px;
        }
        .qm-subtitle {
          font-family: 'Nunito', sans-serif;
          color: #c4b5fd;
          font-weight: 700;
          letter-spacing: 2px;
          font-size: clamp(0.9rem, 1.5vw, 1.1rem);
          margin: 0 0 48px 0;
          animation: slideUp 0.6s cubic-bezier(0.22,1,0.36,1) 0.2s both;
        }
        .qm-card {
          background: rgba(255,255,255,0.07);
          border: 1px solid rgba(255,255,255,0.15);
          border-radius: 20px;
          padding: 36px 28px;
          display: flex;
          flex-direction: column;
          align-items: center;
          gap: 16px;
          transition: transform 0.2s cubic-bezier(0.34,1.56,0.64,1), background 0.2s;
          cursor: default;
        }
        .qm-card:hover {
          transform: translateY(-6px) scale(1.03);
          background: rgba(255,255,255,0.12);
        }
        .qm-card-icon {
          font-size: 2.8rem;
          line-height: 1;
        }
        .qm-card-label {
          font-family: 'Fredoka One', cursive;
          font-size: 1.4rem;
          color: white;
          letter-spacing: 1px;
        }
        .qm-btn {
          font-family: 'Fredoka One', cursive;
          font-size: 1rem;
          padding: 12px 28px;
          border: none;
          border-radius: 100px;
          background: linear-gradient(135deg, #f59e0b, #ef4444);
          color: white;
          cursor: pointer;
          letter-spacing: 2px;
          transition: transform 0.15s cubic-bezier(0.34,1.56,0.64,1), box-shadow 0.2s;
          box-shadow: 0 0 20px #f59e0b55;
        }
        .qm-btn:hover {
          transform: scale(1.08) translateY(-2px);
          box-shadow: 0 0 35px #f59e0b88;
        }
        .qm-btn:active { transform: scale(0.95); }
        .qm-badge {
          font-family: 'Nunito', sans-serif;
          font-size: 0.75rem;
          color: #a5f3fc;
          font-weight: 800;
          letter-spacing: 3px;
          text-transform: uppercase;
          background: rgba(255,255,255,0.07);
          border: 1px solid rgba(255,255,255,0.15);
          border-radius: 100px;
          padding: 7px 22px;
          margin-bottom: 16px;
          display: inline-block;
          animation: slideUp 0.6s cubic-bezier(0.22,1,0.36,1) 0s both;
        }
      `}</style>

      <div className="qm-blob" style={{ width: "45vw", height: "45vw", maxWidth: 600, background: "#7c3aed", top: "-15%", left: "-10%", animationDelay: "0s" }} />
      <div className="qm-blob" style={{ width: "40vw", height: "40vw", maxWidth: 500, background: "#f59e0b", bottom: "-10%", right: "-8%", animationDelay: "3s" }} />
      <div className="qm-blob" style={{ width: "25vw", height: "25vw", maxWidth: 350, background: "#06b6d4", top: "30%", right: "3%", animationDelay: "1.5s" }} />

      <div style={{ position: "relative", zIndex: 10, textAlign: "center", padding: "0 24px", width: "100%", boxSizing: "border-box" }}>
        <div className="qm-badge">✨ Available categories</div>
        <h1 className="qm-title">Pick a category!</h1>
        <p className="qm-subtitle">Select a game to begin</p>

        <div style={{
          display: "grid",
          gridTemplateColumns: "repeat(auto-fit, minmax(200px, 1fr))",
          gap: "24px",
          maxWidth: "800px",
          margin: "0 auto",
          animation: "slideUp 0.6s cubic-bezier(0.22,1,0.36,1) 0.3s both",
        }}>
          {categories.map(({ icon, label, game, gameLabel }) => (
            <div key={label} className="qm-card">
              <div className="qm-card-icon">{icon}</div>
              <div className="qm-card-label">{label}</div>
              <button className="qm-btn" onClick={() => onSelectGame(game)}>
                {gameLabel}
              </button>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}

export default QuizMenu;
