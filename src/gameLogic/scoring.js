const HIGH_SCORE_KEY = "pubQuizHighScores";
 
export const calculatePoints = (isCorrect, timeRemaining, streak = 0) => {
  if (!isCorrect) return 0;
  const base = 100;
  const streakBonus = streak * 2;       
  return base + streakBonus;
};
 
export const getHighScores = () => 
{
  try 
  {
    const stored = localStorage.getItem(HIGH_SCORE_KEY);
    return stored ? JSON.parse(stored) : {};
  } 
  catch 
  {
    return {};
  }
};
 
export const saveHighScore = (topic, gameType, score) => 
{
  const scores = getHighScores();
  const key = `${topic}_${gameType}`;
  if (!scores[key] || score > scores[key]) 
  {
    scores[key] = score;
    localStorage.setItem(HIGH_SCORE_KEY, JSON.stringify(scores));
    return true; 
  }
  return false;
};
 
export const getPrevHighScore = (topic, gameType) => 
{
  const scores = getHighScores();
  return scores[`${topic}_${gameType}`] ?? 0;
};