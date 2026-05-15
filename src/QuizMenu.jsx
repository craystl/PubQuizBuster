function QuizMenu() {
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
        width: "100%",
        boxSizing: "border-box",
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
        Pick a category below to practice!
      </h1>

      <div
        style={{
          display: "grid",
          gridTemplateColumns: "repeat(4, 1fr)",
          gap: "40px",
          width: "80%",
          marginTop: "20px",
        }}
      >
        {/* Music & Arts */}
        <div
          style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            gap: "20px",
          }}
        >
          <span
            style={{
              fontSize: "1.5rem",
            }}
          >
            Music & Arts
          </span>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page1.html")}
          >
            Memory Flip
          </button>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page2.html")}
          >
            Multiple Choice
          </button>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page3.html")}
          >
            Odd One Out
          </button>
        </div>

        {/* History */}
        <div
          style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            gap: "20px",
          }}
        >
          <span
            style={{
              fontSize: "1.5rem",
            }}
          >
            History
          </span>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page1.html")}
          >
            Memory Flip
          </button>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page2.html")}
          >
            Multiple Choice
          </button>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page3.html")}
          >
            Odd One Out
          </button>
        </div>

        {/* Geography */}
        <div
          style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            gap: "20px",
          }}
        >
          <span
            style={{
              fontSize: "1.5rem",
            }}
          >
            Geography
          </span>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page1.html")}
          >
            Memory Flip
          </button>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page2.html")}
          >
            Multiple Choice
          </button>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page3.html")}
          >
            Odd One Out
          </button>
        </div>

        {/* Science & Nature */}
        <div
          style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            gap: "20px",
          }}
        >
          <span
            style={{
              fontSize: "1.5rem",
            }}
          >
            Science & Nature
          </span>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page1.html")}
          >
            Memory Flip
          </button>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page2.html")}
          >
            Multiple Choice
          </button>

          <button
            style={buttonStyle}
            onClick={() => (window.location.href = "quiz-page3.html")}
          >
            Odd One Out
          </button>
        </div>
      </div>
    </div>
  );
}

const buttonStyle = {
  padding: "12px 30px",
  fontSize: "1.1rem",
  border: "none",
  borderRadius: "8px",
  cursor: "pointer",
  background: "#111",
  color: "white",
};

export default QuizMenu;
