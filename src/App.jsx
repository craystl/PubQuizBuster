import { useState } from "react";
import Home from "./pages/Home";
import QuizMenu from "./pages/QuizMenu";
import OddOneOut from "./pages/Quiz3";

function App() {
  const [page, setPage] = useState("home");

  if (page === "quiz-menu") {
    return <QuizMenu onSelectGame={setPage} />;
  }

  if (page === "odd-one-out") {
    return <OddOneOut />;
  }

  return <Home onPlay={() => setPage("quiz-menu")} />;
}

export default App;