const HIGH_SCORE_KEY = "pubQuizHighScores";
 
// Calculates how many points a correct answer is worth. 25 points for every streak.
export const calculatePoints = (isCorrect, timeRemaining, streak = 0) => {
  if (!isCorrect) return 0;
  // 100 points for every corret answer
  const base = 100;
  // Faster answers = more points
  // const timeBonus = timeRemaining * 3;   
  const streakBonus = streak * 25;       
  return base + timeBonus + streakBonus;
};
 
// Reads all saved high scores from localStorage 
export const getHighScores = () => 
{
  try 
  {
    // Gets it from localStorage and stores it into JSON format if it exists
    const stored = localStorage.getItem(HIGH_SCORE_KEY);
    return stored ? JSON.parse(stored) : {};
  } 
  catch 
  {
    return {};
  }
};
 
// Saves a score if it beats the existing high score for that topic/gameType.
export const saveHighScore = (topic, gameType, score) => 
{
  const scores = getHighScores();
  const key = `${topic}_${gameType}`;
  // If no scores exists yet for that topic and game, or if the current score exeeds the high score
  if (!scores[key] || score > scores[key]) 
  {
    // Make it the new high score
    scores[key] = score;
    // Add it to local storage
    localStorage.setItem(HIGH_SCORE_KEY, JSON.stringify(scores));
    // New high score
    return true; 
  }
  return false;
};
 
// Gets the previous high score for a given topic and game type.
export const getPrevHighScore = (topic, gameType) => 
{
  const scores = getHighScores();
  // ?? operator means if no score exists
  return scores[`${topic}_${gameType}`] ?? 0;
};