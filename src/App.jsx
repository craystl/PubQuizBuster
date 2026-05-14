function App() {
  return (
    <div>
      <h1>Pub Quiz Buster</h1>
        <p>A quick quiz game to test your general knowledge.</p>
        <p>Answer questions, track your score, and challenge your friends.</p>
        <p>Play Pub Quiz Buster to test your general knowledge!</p>
        
        <button 
        style = {{
          backgroundColor: "black", 
          color: "white",
          fontSize: "20px",
          padding: "12px 30px" }}
        onClick={() => (window.location = 'quiz-menu.html')}
      >
        Play
      </button>
        
    </div>
  );

}

export default App



