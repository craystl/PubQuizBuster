import { useEffect } from "react";

const floaters = ["🎬", "🎵", "🌍", "🎤", "🏆", "🎯", "🧠", "⭐", "🎲", "🎸"];

function FloatingEmoji({ emoji, style }) {
  return (
    <span style={{
      position: "absolute",
      fontSize: "2rem",
      animation: `floatUp ${style.duration}s ease-in-out infinite`,
      animationDelay: `${style.delay}s`,
      left: `${style.left}%`,
      bottom: "-10%",
      opacity: 0,
      userSelect: "none",
      pointerEvents: "none",
    }}>
      {emoji}
    </span>
  );
}

function Home({ onPlay }) {
  const floaterData = floaters.map((emoji, i) => ({
    emoji,
    style: { duration: 5 + (i % 4), delay: i * 0.6, left: 3 + i * 9.5 },
  }));

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
    }}>
      <style>{`
        @import url('https://fonts.googleapis.com/css2?family=Fredoka+One&family=Nunito:wght@400;700;900&display=swap');

        @keyframes floatUp {
          0%   { transform: translateY(0) rotate(0deg) scale(0.8); opacity: 0; }
          10%  { opacity: 0.8; }
          80%  { opacity: 0.6; }
          100% { transform: translateY(-110vh) rotate(360deg) scale(1.2); opacity: 0; }
        }
        @keyframes blobPulse {
          0%, 100% { border-radius: 60% 40% 30% 70% / 60% 30% 70% 40%; }
          50%       { border-radius: 30% 60% 70% 40% / 50% 60% 30% 60%; }
        }
        @keyframes slideUp {
          0%   { opacity: 0; transform: translateY(50px); }
          100% { opacity: 1; transform: translateY(0); }
        }
        @keyframes shimmer {
          0%   { background-position: -200% center; }
          100% { background-position: 200% center; }
        }
        @keyframes wiggle {
          0%, 100% { transform: rotate(-1.5deg); }
          50%       { transform: rotate(1.5deg); }
        }
        @keyframes glow {
          0%, 100% { box-shadow: 0 0 40px #f59e0baa, 0 0 80px #f59e0b44, 0 12px 40px rgba(0,0,0,0.5); }
          50%       { box-shadow: 0 0 70px #fbbf24dd, 0 0 120px #f59e0b66, 0 12px 40px rgba(0,0,0,0.5); }
        }
        @keyframes fadeIn {
          from { opacity: 0; }
          to   { opacity: 1; }
        }

        .pqb-blob {
          position: absolute;
          animation: blobPulse 8s ease-in-out infinite;
          pointer-events: none;
          filter: blur(80px);
          opacity: 0.3;
        }
        .pqb-title {
          font-family: 'Fredoka One', cursive;
          font-size: clamp(4rem, 9vw, 8rem);
          background: linear-gradient(90deg, #fbbf24, #f87171, #a78bfa, #34d399, #fbbf24);
          background-size: 300% auto;
          -webkit-background-clip: text;
          -webkit-text-fill-color: transparent;
          background-clip: text;
          animation: slideUp 0.7s cubic-bezier(0.22,1,0.36,1) 0.1s both,
                     shimmer 5s linear 0.8s infinite,
                     wiggle 6s ease-in-out 1s infinite;
          line-height: 1.05;
          letter-spacing: 3px;
          margin: 0 0 16px 0;
        }
        .pqb-subtitle {
          font-family: 'Nunito', sans-serif;
          font-size: clamp(1.1rem, 2.2vw, 1.5rem);
          color: #c4b5fd;
          font-weight: 700;
          letter-spacing: 2px;
          margin: 0 0 48px 0;
          animation: slideUp 0.7s cubic-bezier(0.22,1,0.36,1) 0.25s both;
        }
        .pqb-badge {
          font-family: 'Nunito', sans-serif;
          font-size: clamp(0.7rem, 1.2vw, 0.85rem);
          color: #a5f3fc;
          font-weight: 800;
          letter-spacing: 3px;
          text-transform: uppercase;
          background: rgba(255,255,255,0.07);
          border: 1px solid rgba(255,255,255,0.15);
          border-radius: 100px;
          padding: 7px 22px;
          margin-bottom: 20px;
          display: inline-block;
          animation: slideUp 0.7s cubic-bezier(0.22,1,0.36,1) 0s both;
        }
        .pqb-btn {
          font-family: 'Fredoka One', cursive;
          font-size: clamp(1.3rem, 2.5vw, 1.8rem);
          padding: clamp(16px, 2vw, 22px) clamp(48px, 6vw, 80px);
          border: none;
          border-radius: 100px;
          background: linear-gradient(135deg, #f59e0b, #ef4444);
          color: white;
          cursor: pointer;
          letter-spacing: 3px;
          transition: transform 0.15s cubic-bezier(0.34,1.56,0.64,1);
          animation: slideUp 0.7s cubic-bezier(0.22,1,0.36,1) 0.4s both,
                     glow 2.5s ease-in-out 1.1s infinite;
          position: relative;
          overflow: hidden;
        }
        .pqb-btn:hover  { transform: scale(1.06) translateY(-4px); }
        .pqb-btn:active { transform: scale(0.95); }
        .pqb-btn::after {
          content: '';
          position: absolute;
          inset: 0;
          background: linear-gradient(135deg, rgba(255,255,255,0.2), transparent 55%);
          border-radius: inherit;
          pointer-events: none;
        }
        .pqb-pills {
          display: flex;
          gap: 12px;
          flex-wrap: wrap;
          justify-content: center;
          margin-top: 36px;
          animation: slideUp 0.7s cubic-bezier(0.22,1,0.36,1) 0.55s both;
        }
        .pqb-pill {
          background: rgba(255,255,255,0.06);
          border: 1px solid rgba(255,255,255,0.14);
          border-radius: 100px;
          padding: 9px 22px;
          font-family: 'Nunito', sans-serif;
          font-size: clamp(0.85rem, 1.4vw, 1rem);
          font-weight: 800;
          color: rgba(255,255,255,0.85);
          cursor: pointer;
          transition: transform 0.2s, background 0.2s, border-color 0.2s;
        }
        .pqb-pill:hover {
          transform: scale(1.07) translateY(-2px);
          background: rgba(255,255,255,0.13);
          border-color: rgba(255,255,255,0.3);
        }
      `}</style>

      {/* Background blobs */}
      <div className="pqb-blob" style={{ width: "50vw", height: "50vw", maxWidth: 700, maxHeight: 700, background: "#7c3aed", top: "-20%", left: "-10%", animationDelay: "0s" }} />
      <div className="pqb-blob" style={{ width: "45vw", height: "45vw", maxWidth: 600, maxHeight: 600, background: "#f59e0b", bottom: "-15%", right: "-8%", animationDelay: "3s" }} />
      <div className="pqb-blob" style={{ width: "30vw", height: "30vw", maxWidth: 400, maxHeight: 400, background: "#ef4444", top: "20%", right: "5%", animationDelay: "1.5s" }} />
      <div className="pqb-blob" style={{ width: "25vw", height: "25vw", maxWidth: 350, maxHeight: 350, background: "#06b6d4", bottom: "10%", left: "5%", animationDelay: "4s" }} />

      {/* Floating emojis */}
      {floaterData.map((f, i) => (
        <FloatingEmoji key={i} emoji={f.emoji} style={f.style} />
      ))}

      {/* Content */}
      <div style={{ position: "relative", zIndex: 10, textAlign: "center", padding: "0 24px" }}>
        <div className="pqb-badge">✨ Trivia Night Edition</div>
        <h1 className="pqb-title">Pub Quiz Buster</h1>
        <p className="pqb-subtitle">🎬 Movies &nbsp;·&nbsp; 🎵 Music &nbsp;·&nbsp; 🌍 Geography</p>
        <button className="pqb-btn" onClick={onPlay}>🎯 Play Now</button>
        <div className="pqb-pills">
          {[["🎬","Movies"],["🎵","Music"],["🌍","Geography"],["🏆","High Scores"]].map(([icon, label]) => (
            <div key={label} className="pqb-pill">{icon} {label}</div>
          ))}
        </div>
      </div>
    </div>
  );
}

export default Home;
