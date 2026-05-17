import defaultQuestions from "./questions.json";

// Gets questions based on filter params from the default questions.json
export const fetchQuestions = (params) => {
  const { topic, gameType, questionCount = 10 } = params;

  // Check that the topic exists
  if (!defaultQuestions[topic]) {
    throw new Error(`Topic "${topic}" not found in questions data`);
  }

  // Check the game type exists for that topic
  if (!defaultQuestions[topic][gameType]) {
    throw new Error(`Game type "${gameType}" not found for topic "${topic}"`);
  }

  const pool = defaultQuestions[topic][gameType];

  if (pool.length === 0) {
    throw new Error(`No questions found for ${topic} - ${gameType}`);
  }

  return [...pool]
    .sort(() => Math.random() - 0.5)
    .slice(0, Math.min(questionCount, pool.length));
};

export const getAvailableOptions = () => {
  const available = {};

  for (const topic of Object.keys(defaultQuestions)) {
    const gameTypes = Object.keys(defaultQuestions[topic]).filter(
      (gt) => defaultQuestions[topic][gt]?.length > 0
    );
    if (gameTypes.length > 0) {
      available[topic] = gameTypes;
    }
  }

  return available;
};