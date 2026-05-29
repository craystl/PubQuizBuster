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
// export const createBoard = (pairs) => {  ← deleted: parameter renamed, pairs format no longer used
export const createBoard = (data) => {
  const cards = data.cards.map((card) => ({
    id: card.id,
    value: card.label,
    group: card.matchingName,
    isFlipped: false,
    isMatched: false,
  }));
  return {
    cards: shuffleCards(cards),
    flippedIds: [],
    matchedGroups: [],
    moves: 0,
    isSolved: false,
    // isSolved: false,v  ← deleted: typo "v" was a syntax error
  };
  //const cards = pairs.flatMap((pair, index) => [
  //{ id: `q-${index}`, value: pair.question, group: index, side: "question" },
  //{ id: `a-${index}`, value: pair.answer, group: index, side: "answer" },
  //]);
  //return {
  //cards: shuffleCards(cards).map((card) => ({
  //...card,
  //isFlipped: false,
  //isMatched: false,
  //})),
  //flippedIds: [],
  //matchedGroups: [],
  //moves: 0,
  //isSolved: false,
};

// Flips a card face up
export const flipCard = (board, cardId) => {
  // if (board.flippedIds.length >= 2) return board;  ← deleted: need to allow 3 flipped cards for 3-card match
  if (board.flippedIds.length >= 3) return board;
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
  //if (board.flippedIds.length !== 2) return { board, isMatch: false };  ← deleted: updated for 3-card match
  if (board.flippedIds.length !== 3) return { board, isMatch: false };
  // const [firstId, secondId] = board.flippedIds;  ← deleted: need to destructure all 3
  const [firstId, secondId, thirdId] = board.flippedIds;
  const first = board.cards.find((c) => c.id === firstId);
  const second = board.cards.find((c) => c.id === secondId);
  const third = board.cards.find((c) => c.id === thirdId);
  // const isMatch = checkIfCardsMatch(first, second);  ← deleted: only checked 2 cards, need all 3 to share group
  const isMatch = first.group === second.group && second.group === third.group;
  // const updatedCards = board.cards.map((card) => {
  //   if (card.id !== firstId && card.id !== secondId) return card;  ← deleted: missing thirdId
  const updatedCards = board.cards.map((card) => {
    if (card.id !== firstId && card.id !== secondId && card.id !== thirdId) return card;
    return { ...card, isFlipped: isMatch, isMatched: isMatch ? true : card.isMatched };
  });
  const matchedGroups = isMatch ? [...board.matchedGroups, first.group] : board.matchedGroups;
  // const isSolved = checkGameComplete(matchedGroups, board.cards.filter(c => c.side === "question"));  ← deleted: cards no longer have "side" field
  const uniqueGroups = [...new Set(board.cards.map((c) => c.group))];
  const isSolved = matchedGroups.length === uniqueGroups.length;
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