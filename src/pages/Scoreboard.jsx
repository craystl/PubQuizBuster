function ScorePage({ score = 200, maxScore = 600, onExit, onHome }) {
  return (
    <>
      <style>{`
        @import url('https://fonts.googleapis.com/css2?family=Fredoka+One&family=Nunito:wght@400;700;900&display=swap');

        @keyframes shimmer {
          0% { background-position: -200% center; }
          100% { background-position: 200% center; }
        }

        @keyframes fadeUp {
          from { opacity: 0; transform: translateY(30px); }
          to { opacity: 1; transform: translateY(0); }
        }

        @keyframes pulse-glow {
          0%, 100% { box-shadow: 0 0 30px rgba(167,139,250,0.4); }
          50% { box-shadow: 0 0 60px rgba(167,139,250,0.8); }
        }

        .score-title {
          font-family: 'Fredoka One', cursive;
          font-size: clamp(2.5rem, 5vw, 4rem);
          background: linear-gradient(90deg, #f472b6, #a78bfa, #67e8f9, #f472b6);
          background-size: 300% auto;
          -webkit-background-clip: text;
          -webkit-text-fill-color: transparent;
          animation: shimmer 6s linear infinite;
          margin: 0 0 8px 0;
          line-height: 1.2;
        }

        .score-card {
          animation: fadeUp 0.6s ease forwards, pulse-glow 3s ease-in-out infinite;
        }

        .score-btn:hover {
          opacity: 0.85;
          transform: translateY(-2px);
        }
      `}</style>

      <div style={{
        minHeight: "100vh",
        width: "100%",
        background: "linear-gradient(135deg, #1a1a2e 0%, #16213e 50%, #0f3460 100%)",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        padding: "40px 20px",
        boxSizing: "border-box",
        position: "relative",
        overflow: "hidden",
        fontFamily: "'Nunito', sans-serif",
      }}>

        {/* Background blobs */}
        <div style={{
          position: "absolute", width: "500px", height: "500px",
          background: "#7c3aed", borderRadius: "50%",
          filter: "blur(120px)", opacity: 0.2, top: "-150px", left: "-100px",
        }} />
        <div style={{
          position: "absolute", width: "400px", height: "400px",
          background: "#f472b6", borderRadius: "50%",
          filter: "blur(120px)", opacity: 0.15, bottom: "-120px", right: "-80px",
        }} />

        {/* Content */}
        <div style={{ position: "relative", zIndex: 10, textAlign: "center", width: "100%", maxWidth: "600px" }}>

          <p style={{ color: "rgba(255,255,255,0.5)", fontSize: "16px", letterSpacing: "3px", textTransform: "uppercase", marginBottom: "8px" }}>
            Game Over
          </p>
          <h1 className="score-title">Your Score</h1>

          {/* Score card */}
          <div className="score-card" style={{
            background: "rgba(255,255,255,0.06)",
            backdropFilter: "blur(16px)",
            border: "1px solid rgba(255,255,255,0.12)",
            borderRadius: "24px",
            padding: "48px 40px",
            margin: "32px auto",
          }}>
            {/* Big score number */}
            <div style={{
              fontSize: "clamp(60px, 12vw, 100px)",
              fontWeight: "900",
              background: "linear-gradient(90deg, #f472b6, #a78bfa)",
              WebkitBackgroundClip: "text",
              WebkitTextFillColor: "transparent",
              lineHeight: 1,
              marginBottom: "12px",
            }}>
              {score}
            </div>

            <div style={{ color: "rgba(255,255,255,0.4)", fontSize: "18px", marginBottom: "28px" }}>
              out of {maxScore} points
            </div>

            {/* Progress bar */}
            <div style={{
              background: "rgba(255,255,255,0.1)",
              borderRadius: "50px",
              height: "12px",
              width: "100%",
              overflow: "hidden",
            }}>
              <div style={{
                height: "100%",
                width: `${Math.round((score / maxScore) * 100)}%`,
                background: "linear-gradient(90deg, #f472b6, #a78bfa)",
                borderRadius: "50px",
                transition: "width 1s ease",
              }} />
            </div>

            <p style={{ color: "rgba(255,255,255,0.5)", fontSize: "14px", marginTop: "12px" }}>
              {Math.round((score / maxScore) * 100)}% accuracy
            </p>
          </div>

          {/* Buttons */}
          <div style={{ display: "flex", gap: "16px", justifyContent: "center", flexWrap: "wrap" }}>
            <button
              className="score-btn"
              onClick={onExit}
              style={{
                background: "rgba(239,68,68,0.15)",
                border: "1px solid rgba(239,68,68,0.4)",
                color: "#ef4444",
                borderRadius: "20px",
                padding: "12px 32px",
                fontSize: "16px",
                cursor: "pointer",
                fontWeight: "700",
                transition: "all 0.2s ease",
              }}
            >
              ✕ Exit
            </button>

            <button
              className="score-btn"
              onClick={onHome}
              style={{
                background: "linear-gradient(90deg, #f472b6, #a78bfa)",
                border: "none",
                color: "#fff",
                borderRadius: "20px",
                padding: "12px 32px",
                fontSize: "16px",
                cursor: "pointer",
                fontWeight: "700",
                transition: "all 0.2s ease",
                boxShadow: "0 4px 20px rgba(167,139,250,0.4)",
              }}
            >
              🏠 Back to Home
            </button>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScorePage;
