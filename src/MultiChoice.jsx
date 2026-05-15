import { useNavigate } from 'react-router-dom';
import ScorePage from './ScorePage';

function MultiChoice() {
  const navigate = useNavigate();
  
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
        Multi-Choice
      </h1>

      <br />

      <h2
        style={{
          textAlign: "center",
          fontSize: "17px",
        }}
      >
        Question
      </h2>

      <div
        style={{
          textAlign: "center",
          fontSize: "30px",
        }}
      >
        <p>
          <input type="radio" name="answer" /> Cat
        </p>

        <p>
          <input type="radio" name="answer" /> Dog
        </p>

        <p>
          <input type="radio" name="answer" /> Bird
        </p>

        <br />

        <button style={{
          background: "black",
          color: "white",
          padding: "10px 25px",
          fontSize: "25px",
        }} 
          onClick={() => navigate('/score-page')}>
        Submit
      </button>
      </div>
    </div>
  );
}

export default MultiChoice;
