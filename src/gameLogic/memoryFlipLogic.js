// memory flip logic 

// Builds the memory game board from API question/answer pairs
export const createBoard = (pairs) => {

  // Turn each pair into two separate cards (Q + A)
  const cards = pairs.flatMap((pair, index) => [
    {
      id: `q-${index}`,
      value: pair.question,
      group: index,      // used to check matches
      side: "question",
    },
    {
      id: `a-${index}`,
      value: pair.answer,
      group: index,
      side: "answer",
    },
  ]);

  return {
    // Shuffle cards and set initial state
    cards: shuffle(cards).map((card) => ({
      ...card,
      isFlipped: false,   // card is face down at start
      isMatched: false,   // not yet solved
    })),

    flippedIds: [],       // stores currently flipped cards (max 2)
    matchedGroups: [],    // tracks completed pairs
    moves: 0,             // number of attempts
    isSolved: false,      // game completed flag
  };
};


// Flips a card face-up
export const flipCard = (board, cardId) => {

  // Block flipping if already 2 cards are being checked
  if (board.flippedIds.length >= 2) return board;

  const card = board.cards.find((c) => c.id === cardId);

  // Ignore invalid or already revealed/matched cards
  if (!card || card.isMatched || card.isFlipped) return board;

  // Flip selected card
  const updatedCards = board.cards.map((c) =>
    c.id === cardId ? { ...c, isFlipped: true } : c
  );

  return {
    ...board,
    cards: updatedCards,
    flippedIds: [...board.flippedIds, cardId],
  };
};


// Checks whether the two flipped cards match
export const evaluateFlip = (board) => {

  // Only evaluate when 2 cards are flipped
  if (board.flippedIds.length !== 2) {
    return { board, isMatch: false };
  }

  const [firstId, secondId] = board.flippedIds;

  const first = board.cards.find((c) => c.id === firstId);
  const second = board.cards.find((c) => c.id === secondId);

  // Match if they belong to the same pair
  const isMatch = first.group === second.group;

  const updatedCards = board.cards.map((card) => {

    // Only update the two selected cards
    if (card.id !== firstId && card.id !== secondId) return card;

    return {
      ...card,

      // If match → stay face-up, otherwise flip back down
      isFlipped: isMatch ? true : false,

      // Mark permanently matched only if correct pair
      isMatched: isMatch ? true : card.isMatched,
    };
  });

  // Add to matched groups if correct
  const matchedGroups = isMatch
    ? [...board.matchedGroups, first.group]
    : board.matchedGroups;

  // Check if all pairs are completed
  const isSolved =
    matchedGroups.length === board.cards.length / 2;

  return {
    isMatch,
    board: {
      ...board,
      cards: updatedCards,
      flippedIds: [],           // reset selection for next turn
      matchedGroups,
      moves: board.moves + 1,
      isSolved,
    },
  };
};


// Resets current turn (keeps matched cards)
export const resetBoard = (board) => ({
  ...board,

  cards: board.cards.map((card) => ({
    ...card,

    // Only matched cards stay visible
    isFlipped: card.isMatched,
  })),

  flippedIds: [],
});


// Returns summary for results screen
export const getBoardSummary = (board) => ({
  totalPairs: board.cards.length / 2,
  matchedPairs: board.matchedGroups.length,
  moves: board.moves,
  isSolved: board.isSolved,

  // Efficiency score (higher = better performance)
  efficiency:
    board.moves > 0
      ? Math.round(
          (board.matchedGroups.length / board.moves) * 100
        )
      : 0,
});


// Fisher–Yates shuffle algorithm
// Randomises card order each game
const shuffle = (array) => {
  const arr = [...array];

  for (let i = arr.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));

    [arr[i], arr[j]] = [arr[j], arr[i]];
  }
   
  return arr;
};