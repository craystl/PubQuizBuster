
export const fetchQuestions = async (params) => {
  const { topic, gameType, questionCount } = params; 
  
  // Gets questions from the backend in C#
  const response = await fetch(`/api/questions?topic=${encodeURIComponent(topic)}&gameType=${encodeURIComponent(gameType)}&questionCount=${questionCount}`);
  
  // If failed to retrieve questions from the backend in C#
  if (!response.ok) {
    throw new Error(`Failed to fetch questions: ${response.statusText}`);
  }
  // Give questions back to code
  return await response.json();
};

// Get available options from DBPedia data
export const getAvailableOptions = async () => {
  const available = {};
  const response = await fetch('/api/available-options');
  
  if (!response.ok) {
    throw new Error('Failed to fetch available options');
  }
  // Returns all the questions
  return await response.json();
};