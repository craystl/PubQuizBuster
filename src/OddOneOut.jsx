function OddOneOut() {
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
        Odd One Out
      </h1>

      <br />

      <h2
        style={{
          textAlign: "center",
          fontSize: "20px",
        }}
      >
        Which is the odd one out?
      </h2>

      <br />
      <br />

      <div
        style={{
          textAlign: "center",
        }}
      >
        <button
          style={{
            width: "200px",
            height: "120px",
            fontSize: "25px",
            margin: "15px",
          }}
        >
          Pan
        </button>

        <button
          style={{
            width: "200px",
            height: "120px",
            fontSize: "25px",
            margin: "15px",
          }}
        >
          Bowl
        </button>

        <br />

        <button
          style={{
            width: "200px",
            height: "120px",
            fontSize: "25px",
            margin: "15px",
          }}
        >
          Plate
        </button>

        <button
          style={{
            width: "200px",
            height: "120px",
            fontSize: "25px",
            margin: "15px",
          }}
        >
          Cat
        </button>
      </div>
    </div>
  );
}

export default OddOneOut;