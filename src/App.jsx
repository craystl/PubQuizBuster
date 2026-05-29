import { useState } from "react";
import Home from "./pages/Home";
import QuizMenu from "./pages/QuizMenu";
import OddOneOut from "./pages/Quiz3";
import MemoryFlip from "./pages/Quiz2";
import MultiChoice from "./pages/Quiz1";

function App() {
  const [page, setPage] = useState("home");

  if (page === "quiz-menu") return <QuizMenu onSelectGame={setPage} />;
  if (page === "odd-one-out") return <OddOneOut />;
  if (page === "memory-flip") return <MemoryFlip />;
  if (page === "multiple-choice") return <MultiChoice />;

  return <Home onPlay={() => setPage("quiz-menu")} />;
}

export default App;