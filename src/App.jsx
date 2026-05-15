import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';

function GameMenu() {
  return <h1>Game Menu</h1>;
}

function Home() {
  return (
    <div>
      <h1>Pub Quiz Buster</h1>

      <p>A quick quiz game to test your general knowledge.</p>
      <p>Answer questions, track your score, and challenge your friends.</p>
      <p>Play Pub Quiz Buster to test your general knowledge!</p>

      <Link to="/game-menu">
        <button
          style={{
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
        <Route path="/game-menu" element={<GameMenu />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
