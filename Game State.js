// Creates a new game for a new session
export const createGameState = (questions, topic, gameType, timePerQuestion = 30) => 
({
  topic,
  gameType,
  questions,
  timePerQuestion,       
  timeRemaining: timePerQuestion,
  // Which question we're on
  currentIndex: 0,       
  score: 0,   
  // Consecutive correct answers        
  streak: 0,               
  lives: 3,          
  totalTimeUsed: 0,       
  answers: [],            
  isOver: false,         
  isPaused: false,
  startedAt: new Date().toISOString(),
});

// Restarts the game state back to the original settings, used when the player clicks "Play Again"
export const resetGameState = (state) =>
  createGameState(state.questions, state.topic, state.gameType, state.timePerQuestion);