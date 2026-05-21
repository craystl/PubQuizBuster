// Fetches the JSON files from the server and converts it to be readable for the Game Logic

const BASE_URL = "http://localhost:3000";

// Fetches the list of available activities for a game type
export const fetchActivityList = async (gameType) => {
  const response = await fetch(`${BASE_URL}/api/activities/${gameType}`);
  if (!response.ok) {
    throw new Error(`Failed to fetch activity list for: ${gameType}`);
  }
  return response.json();
};

// Fetches a specific activity JSON file from the server
export const fetchActivity = async (gameType, fileName) => {
  const response = await fetch(`${BASE_URL}/api/activity/${gameType}/${fileName}`);
  if (!response.ok) {
    throw new Error(`Failed to fetch activity: ${gameType}/${fileName}`);
  }
  return response.json();
};

// Converters: JSON format --> gameLogic.js format

// Converts a Memory Flip activity into pairs for memoryFlipLogic.js
export const convertMemoryFlip = (activity) => {
  const { cards } = activity;

  const groups = {};
  for (const card of cards) {
    if (!groups[card.matchingName]) groups[card.matchingName] = [];
    groups[card.matchingName].push(card);
  }
  
  const result = [];
  let groupId = 0;

  for (const [artistName, groupCards] of Object.entries(groups)) {
    const artistCard = groupCards.find((c) => c.cardType === "artist-photo");
    const albumCards = groupCards.filter((c) => c.cardType === "album-cover");

    result.push({
      id: `group_${groupId++}`,
      artistName,
      artistImage: artistCard
        ? `${BASE_URL}/data/memory-flip/images/${artistCard.img.split("/").pop()}`
        : null,
      albums: albumCards.map((album) => ({
        label: album.albumTitle ?? album.label,
        image: `${BASE_URL}/data/memory-flip/images/${album.img.split("/").pop()}`,
      })),
    });
  }

  return result;
};

//Converts a Multiple Choice activity into question objects for gameLogic.js
export const convertMultipleChoice = (activity) => {
  const { cards } = activity;

  return cards.map((card, i) => {
    const correctAnswer = card.correctAnswer ?? card.label;

    const wrongOptions = cards
      .filter((_, j) => j !== i)
      .map((c) => c.label)
      .sort(() => Math.random() - 0.5)
      .slice(0, 3);

    const options = [...wrongOptions, correctAnswer].sort(() => Math.random() - 0.5);

    return {
      text: card.questionText ?? `What is this?`,
      correctAnswer,
      options,
      image: card.img ? `${BASE_URL}/data/multiple-choice/images/${card.img.split("/").pop()}` : null,
    };
  });
};

//Converts an Odd One Out activity into question objects for oddOneOutLogic.js
export const convertOddOneOut = (activity) => {
  const { cards } = activity;

  const groupCount = {};
  for (const card of cards) {
    groupCount[card.matchingName] = (groupCount[card.matchingName] ?? 0) + 1;
  }

  const minCount = Math.min(...Object.values(groupCount));
  const oddCard = cards.find((c) => groupCount[c.matchingName] === minCount);
  const groupCards = cards.filter((c) => c.matchingName !== oddCard.matchingName);

  return [
    {
      text: "Which one doesn't belong?",
      oddItem: oddCard.label,
      groupItems: groupCards.map((c) => c.label),
      correctAnswer: oddCard.label,
      explanation: activity.explanation ?? `${oddCard.label} is the odd one out`,
      category: activity.title ?? activity.activityType,
    },
  ];
};

// Fetches and converts an activity into the format gameLogic.js expects
export const fetchAndConvertActivity = async (gameType, fileName) => {
  const activity = await fetchActivity(gameType, fileName);

  switch (gameType) {
    case "memory-flip":     return convertMemoryFlip(activity);
    case "multiple-choice": return convertMultipleChoice(activity);
    case "odd-one-out":     return convertOddOneOut(activity);
    default: throw new Error(`Unknown game type: ${gameType}`);
  }
};