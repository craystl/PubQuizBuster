import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import QuizMenu from './QuizMenu';


function Home() {
  return (
    <div>
      <h1>Pub Quiz Buster</h1>

      <p>A quick quiz game to test your general knowledge.</p>
      <p>Answer questions, track your score, and challenge your friends.</p>
      <p>Play Pub Quiz Buster to test your general knowledge!</p>

      <Link to="/quiz-menu">
        <button
          style={{
            marginTop: "20px",
            backgroundColor: "black",
            color: "white",
            fontSize: "20px",
            padding: "12px 30px",
          }}
        >
          Play
        </button>
      </Link>
    </div>
  );
}

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/quiz-menu" element={<QuizMenu />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
