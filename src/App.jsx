import { useState } from "react";
import Home from "./pages/Home";
import QuizMenu from "./pages/QuizMenu";
import OddOneOut from "./pages/Quiz3";
import MultiChoice from "./pages/Quiz2";
import MemoryFlip from "./pages/Quiz1";
import ScorePage from "./pages/Scoreboard";

function App() {
  const [page, setPage] = useState("home");
  const [finalScore, setFinalScore] = useState({ score: 0, maxScore: 0 });

  function goToScore(score, maxScore) {
    console.log("goToScore called:", score, maxScore);
    setFinalScore({ score, maxScore });
    setTimeout(() => setPage("score"), 0);
  }

  if (page === "quiz-menu") return <QuizMenu onSelectGame={setPage} />;
  if (page === "odd-one-out") return <OddOneOut onExit={() => setPage("quiz-menu")} onFinish={(score) => goToScore(score, 1000)} />;
  if (page === "memory-flip") return <MemoryFlip onExit={() => setPage("quiz-menu")} onFinish={(score) => goToScore(score, 600)} />;
  if (page === "multiple-choice") return <MultiChoice onExit={() => setPage("quiz-menu")} onFinish={(score) => goToScore(score, 800)} />;
  if (page === "score") return <ScorePage score={finalScore.score} maxScore={finalScore.maxScore} onExit={() => setPage("quiz-menu")} onHome={() => setPage("home")} />;
  return <Home onPlay={() => setPage("quiz-menu")} />;
}

export default App;
