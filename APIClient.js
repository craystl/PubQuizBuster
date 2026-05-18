import defaultQuestions from "./questions.json";

// Gets questions based on filter params from the default questions.json
export const fetchQuestions = (params) => {
  const { topic, gameType, questionCount } = params; 

  // Check that the topic exists
  if (!defaultQuestions[topic]) {
    throw new Error(`Topic "${topic}" not found in questions data`);
  }

  // Check the game type exists for that topic
  if (!defaultQuestions[topic][gameType]) {
    throw new Error(`Game type "${gameType}" not found for topic "${topic}"`);
  }

  // Grab the questions for our working pool
  const pool = defaultQuestions[topic][gameType];

  // If there are no questions in our pool
  if (pool.length === 0) {
    throw new Error(`No questions found for ${topic} - ${gameType}`);
  }

  // Shallow copy the pool so we don't affect the actual data
  return [...pool]
    // Sort them
    .sort(() => Math.random() - 0.5)
    // Take as many questions as requested 
    .slice(0, Math.min(questionCount, pool.length));
};

// Get available options
export const getAvailableOptions = () => {
  const available = {};

  // Returns an object containing of only topics and games that have questions in them
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