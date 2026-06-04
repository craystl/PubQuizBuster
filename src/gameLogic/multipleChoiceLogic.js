export const getCorrectAnswers = (answers) => {
  return answers.filter(a => a.IsCorrect).map(a => a.Text);
};

export const checkMultipleChoiceAnswer = (selectedAnswers, correctAnswers) => {
  if (selectedAnswers.length !== correctAnswers.length) return false;
  const sortedSelected = [...selectedAnswers].sort();
  const sortedCorrect = [...correctAnswers].sort();
  return sortedSelected.every((ans, i) => ans === sortedCorrect[i]);
};

export const calculateNewScore = (currentScore, isCorrect) => {
  return isCorrect ? currentScore + 100 : currentScore;
};

export const shuffleAnswers = (answers) => {
  return [...answers].sort(() => Math.random() - 0.5);
};

export const hasNextQuestion = (currentIndex, totalQuestions) => {
  return currentIndex + 1 < totalQuestions;
};

export const getNextQuestionIndex = (currentIndex, totalQuestions) => {
  if (!hasNextQuestion(currentIndex, totalQuestions)) return currentIndex;
  return currentIndex + 1;
};

export const getAnswerMessage = (isCorrect) => {
  return isCorrect ? "Correct! Well done!" : "Incorrect! Better luck next time!";
};