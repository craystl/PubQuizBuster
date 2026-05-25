function QuizMenu({ onSelectGame }) {
  return (
    <div style={pageStyle}>
      <h1 style={headingStyle}>Pick a category below to practice!</h1>

      <div style={gridStyle}>
        <div style={cardStyle}>
          <span style={categoryStyle}>Music</span>
          <button style={buttonStyle} onClick={() => onSelectGame("memory-flip")}>
            Memory Flip
          </button>
        </div>

        <div style={cardStyle}>
          <span style={categoryStyle}>Movies</span>
          <button style={buttonStyle} onClick={() => onSelectGame("odd-one-out")}>
            Odd One Out
          </button>
        </div>

        <div style={cardStyle}>
          <span style={categoryStyle}>Geography</span>
          <button style={buttonStyle} onClick={() => onSelectGame("multiple-choice")}>
            Multiple Choice
          </button>
        </div>
      </div>
    </div>
  );
}

const pageStyle = {
  margin: 0,
  fontFamily: "Arial, sans-serif",
  background: "white",
  display: "flex",
  flexDirection: "column",
  alignItems: "center",
  minHeight: "100vh",
  paddingTop: "40px",
  textAlign: "center",
};

const headingStyle = {
  fontSize: "2rem",
  marginBottom: "30px",
  color: "#111",
};

const gridStyle = {
  display: "grid",
  gridTemplateColumns: "repeat(3, 1fr)",
  gap: "40px",
  width: "80%",
  marginTop: "20px",
};

const cardStyle = {
  display: "flex",
  flexDirection: "column",
  alignItems: "center",
  gap: "20px",
};

const categoryStyle = {
  fontSize: "1.5rem",
};

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