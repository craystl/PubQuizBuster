// Checks whether the chosen item is the correct odd one out.
export const checkOddOneOut = (items, chosenId) => {
  const oddItem = items.find((item) => item.isOdd);
  // The ? operator helps to access a value that might be null or undefined without causing an error 
  return oddItem?.id === chosenId;
};
 
// Returns the correct odd item from a list.
export const getOddItem = (items) => items.find((item) => item.isOdd);
 
// Shuffles the items in a random order for display.
export const shuffleItems = (items) =>
  [...items].sort(() => Math.random() - 0.5);
 
// Builds an Odd One Out question object from raw API data.
export const formatOddOneOutQuestion = (rawQuestion) => 
{
  const allItems = 
  [
    { id: "odd", label: rawQuestion.oddItem, isOdd: true },
    ...rawQuestion.groupItems.map((label, i) => 
    ({
      id: `group_${i}`,
      label,
      isOdd: false,
    })),
  ];
 
  return {
    items: shuffleItems(allItems),
    category: rawQuestion.category,
    explanation: rawQuestion.explanation,
    // The id of the odd item
    correctAnswer: "odd", 
  };
};