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

  function goToScore(score, maxScore) {
    setFinalScore({ score, maxScore });
    setTimeout(() => setPage("score"), 0);
  }

  if (page === "quiz-menu") {
    return (
      <QuizMenu
        onSelectGame={(game) => {
          setSelectedGame(game);
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
          setPage(selectedGame);
        }}
      />
    );
  }

  if (page === "odd-one-out") {
    return (
      <OddOneOut
        quizData={quizData}
        onExit={() => setPage("quiz-menu")}
        onFinish={(score) => goToScore(score, 1000)}
      />
    );
  }

