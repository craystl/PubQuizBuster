// memoryFlipLogic.js

// Randomises card order
export const shuffleCards = (cards) => {
  const arr = [...cards];
  for (let i = arr.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [arr[i], arr[j]] = [arr[j], arr[i]];
  }
  return arr;
};

// Checks if two flipped cards match
export const checkIfCardsMatch = (firstCard, secondCard) => {
  return firstCard.group === secondCard.group;
};

// Checks if a card can be flipped
export const canFlipCard = (card, flippedCards) => {
  if (card.isMatched || card.isFlipped) return false;
  if (flippedCards.length >= 2) return false;
  return true;
};

// Adds a card to the flipped list
export const addFlippedCard = (flippedCards, card) => {
  return [...flippedCards, card];
};

// Checks if enough cards are flipped to evaluate a match
export const isMatchComplete = (flippedCards, matchSize = 2) => {
  return flippedCards.length === matchSize;
};

// Updates score based on whether match was correct
export const calculateNewScore = (currentScore, isCorrect) => {
  return isCorrect ? currentScore + 100 : currentScore;
};

// Checks if the entire game is finished
export const checkGameComplete = (matchedCards, allCards) => {
  return matchedCards.length === allCards.length;
};

// Builds the memory game board from API pairs
export const createBoard = (pairs) => {
  const cards = pairs.flatMap((pair, index) => [
    { id: `q-${index}`, value: pair.question, group: index, side: "question" },
    { id: `a-${index}`, value: pair.answer, group: index, side: "answer" },
  ]);
  return {
    cards: shuffleCards(cards).map((card) => ({
      ...card,
      isFlipped: false,
      isMatched: false,
    })),
    flippedIds: [],
    matchedGroups: [],
    moves: 0,
    isSolved: false,
  };
};

// Flips a card face up
export const flipCard = (board, cardId) => {
  if (board.flippedIds.length >= 2) return board;
  const card = board.cards.find((c) => c.id === cardId);
  if (!card || card.isMatched || card.isFlipped) return board;
  const updatedCards = board.cards.map((c) =>
    c.id === cardId ? { ...c, isFlipped: true } : c
  );
  return {
    ...board,
    cards: updatedCards,
    flippedIds: [...board.flippedIds, cardId],
  };
};

// Evaluates whether the two flipped cards match
export const evaluateFlip = (board) => {
  //if (board.flippedIds.length !== 2) return { board, isMatch: false };
  if (board.flippedIds.length !== 3) return { board, isMatch: false };
  const [firstId, secondId] = board.flippedIds;
  const first = board.cards.find((c) => c.id === firstId);
  const second = board.cards.find((c) => c.id === secondId);
  const isMatch = checkIfCardsMatch(first, second);
  const updatedCards = board.cards.map((card) => {
    if (card.id !== firstId && card.id !== secondId) return card;
    return { ...card, isFlipped: isMatch, isMatched: isMatch ? true : card.isMatched };
  });
  const matchedGroups = isMatch ? [...board.matchedGroups, first.group] : board.matchedGroups;
  const isSolved = checkGameComplete(matchedGroups, board.cards.filter(c => c.side === "question"));
  return {
    isMatch,
    board: { ...board, cards: updatedCards, flippedIds: [], matchedGroups, moves: board.moves + 1, isSolved },
  };
};

// Resets current turn keeping matched cards visible
export const resetBoard = (board) => ({
  ...board,
  cards: board.cards.map((card) => ({ ...card, isFlipped: card.isMatched })),
  flippedIds: [],
});

// Returns summary for results screen
export const getBoardSummary = (board) => ({
  totalPairs: board.cards.length / 2,
  matchedPairs: board.matchedGroups.length,
  moves: board.moves,
  isSolved: board.isSolved,
  efficiency: board.moves > 0 ? Math.round((board.matchedGroups.length / board.moves) * 100) : 0,
});