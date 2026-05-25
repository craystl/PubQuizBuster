// oddOneOutLogic.js

// Checks if the selected item is the odd one out
export const checkOddOneOutAnswer = (item) => {
  return item.isOdd === true;
};

// Updates score based on whether answer was correct
export const calculateNewScore = (currentScore, isCorrect) => {
  return isCorrect ? currentScore + 100 : currentScore;
};

// Checks if there is another question after the current one
export const hasNextQuestion = (currentQuestionIndex, totalQuestions) => {
  return currentQuestionIndex + 1 < totalQuestions;
};

// Returns the index of the next question
export const getNextQuestionIndex = (currentQuestionIndex, totalQuestions) => {
  if (!hasNextQuestion(currentQuestionIndex, totalQuestions)) return currentQuestionIndex;
  return currentQuestionIndex + 1;
};

// Returns a correct or incorrect message
export const getAnswerMessage = (isCorrect) => {
  return isCorrect ? "Correct! Well done!" : "Incorrect! Better luck next time!";
};

// Returns the correct odd item from a list
export const getOddItem = (items) => items.find((item) => item.isOdd);

// Shuffles items in random order for display
export const shuffleItems = (items) =>
  [...items].sort(() => Math.random() - 0.5);

// Builds an Odd One Out question from raw API data
export const formatOddOneOutQuestion = (rawQuestion) => {
  const allItems = [
    { id: "odd", label: rawQuestion.oddItem, isOdd: true },
    ...rawQuestion.groupItems.map((label, i) => ({
      id: `group_${i}`,
      label,
      isOdd: false,
    })),
  ];
  return {
    items: shuffleItems(allItems),
    category: rawQuestion.category,
    explanation: rawQuestion.explanation,
    correctAnswer: "odd",
  };
};