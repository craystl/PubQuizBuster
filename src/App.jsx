import { useState } from "react";
import Home from "./pages/Home";
import QuizMenu from "./pages/QuizMenu";
import OddOneOut from "./pages/Quiz3";
import MultiChoice from "./pages/Quiz2";
import MemoryFlip from "./pages/Quiz1";
import ScorePage from "./pages/Scoreboard";
import UploadPage from "./pages/UploadPage";

function App() {
  const [page, setPage] = useState("home");
  const [finalScore, setFinalScore] = useState({ score: 0, maxScore: 0 });
  const [quizData, setQuizData] = useState(null);
  const [selectedGame, setSelectedGame] = useState(null);
  const [quizKey, setQuizKey] = useState(0);

  function goToScore(score, maxScore) {
    setFinalScore({ score, maxScore });
    setPage("score");
  }

  if (page === "home") {
    return <Home onPlay={() => setPage("quiz-menu")} />;
  }

  if (page === "quiz-menu") {
    return (
      <QuizMenu
        onSelectGame={(game) => {
          setSelectedGame(game);
          setQuizData(null);
          setPage("upload-page");
        }}
      />
    );
  }

  if (page === "upload-page") {
    return (
      <UploadPage
        onExit={() => setPage("quiz-menu")}
        onUpload={(data) => {
          setQuizData(data);
          setQuizKey((oldKey) => oldKey + 1);
          setPage(selectedGame);
        }}
      />
    );
  }

  if (page === "odd-one-out") {
    return (
      <OddOneOut
        key={quizKey}
        quizData={quizData}
        onExit={() => setPage("quiz-menu")}
        onFinish={(score) => goToScore(score, 1000)}
      />
    );
  }

  if (page === "multiple-choice") {
    return (
      <MultiChoice
        key={quizKey}
        quizData={quizData}
        onExit={() => setPage("quiz-menu")}
        onFinish={(score) => goToScore(score, 1000)}
      />
    );
  }

  if (page === "memory-flip") {
    return (
      <MemoryFlip
        key={quizKey}
        quizData={quizData}
        onExit={() => setPage("quiz-menu")}
        onFinish={(score) => goToScore(score, 1000)}
      />
    );
  }

  if (page === "score") {
    return (
      <ScorePage
        score={finalScore.score}
        maxScore={finalScore.maxScore}
        onExit={() => setPage("quiz-menu")}
        onHome={() => setPage("home")}
      />
    );
  }

  return <Home onPlay={() => setPage("quiz-menu")} />;
}

export default App;
