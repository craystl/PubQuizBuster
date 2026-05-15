function MemoryFlip() {
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
