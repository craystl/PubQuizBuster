import { useNavigate } from 'react-router-dom';

function ScorePage() {
  const navigate = useNavigate();
  
  return (
    <div
      style={{
        fontFamily: "Arial, sans-serif",
        padding: "40px",
        height: "90vh",
        position: "relative",
      }}
    >
      <h1
        style={{
          textAlign: "center",
          fontSize: "40px",
        }}
      >
        Score
      </h1>

      <div
        style={{
          background: "#ADD8E6",
          width: "500px",
          height: "300px",
          margin: "40px auto",
          borderRadius: "10px",
        }}
      ></div>

      <p
        style={{
          textAlign: "center",
          fontSize: "30px",
          marginTop: "20px",
        }}
      >
        Total Score: 200 / 600
      </p>

      <button
        style={{
          position: "absolute",
          bottom: "20px",
          left: "20px",
          background: "black",
          color: "white",
          padding: "12px 25px",
          fontSize: "20px",
          border: "none",
        }}
        onClick={() => navigate('/')}
      >
        Exit
      </button>

      <button
        style={{
          position: "absolute",
          bottom: "20px",
          right: "20px",
          background: "black",
          color: "white",
          padding: "12px 25px",
          fontSize: "20px",
          border: "none",
        }}
        onClick={() => navigate('/')}
      >
        Back to Home
      </button>
    </div>
  );
}

export default ScorePage;
