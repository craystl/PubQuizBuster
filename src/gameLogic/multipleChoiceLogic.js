// multiple choice logic

export const checkMultipleChoiceAnswer = (selectedAnswer, correctAnswer) => {
  return selectedAnswer === correctAnswer;
};

export const calculateNewScore = (currentScore, isCorrect) => {
  return isCorrect ? currentScore + 100 : currentScore;
};

export const shuffleAnswers = (answers) => {
  return [...answers].sort(() => Math.random() - 0.5);
};

export const hasNextQuestion = (currentQuestionIndex, totalQuestions) => {
  return currentQuestionIndex + 1 < totalQuestions;
};

export const getNextQuestionIndex = (currentQuestionIndex, totalQuestions) => {
  if (!hasNextQuestion(currentQuestionIndex, totalQuestions)) return currentQuestionIndex;
  return currentQuestionIndex + 1;
};

export const getAnswerMessage = (isCorrect) => {
  return isCorrect ? "Correct! Well done!" : "Incorrect! Better luck next time!";
};