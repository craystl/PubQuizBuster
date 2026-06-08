import React, { useState } from "react";

function UploadPage({ onUpload, onExit }) {
  const [selectedData, setSelectedData] = useState(null);
  const [fileName, setFileName] = useState("");

  function handleFileChange(event) {
    const file = event.target.files[0];

    if (!file) return;

    setFileName(file.name);

    const reader = new FileReader();

    reader.onload = (e) => {
      try {
        const data = JSON.parse(e.target.result);
        console.log("Loaded JSON:", data);
        setSelectedData(data);
      } catch (error) {
        alert("Invalid JSON file. Please choose a valid .json file.");
        console.error("JSON parse error:", error);
        setSelectedData(null);
      }
    };

    reader.readAsText(file);
  }

  function handleSubmit(event) {
    event.preventDefault();

    if (!selectedData) {
      alert("Please choose a JSON file first");
      return;
    }

    onUpload(selectedData);
  }

  return (
    <div
      style={{
        width: "100%",
        height: "100vh",
        background:
          "linear-gradient(135deg, #0f0c29 0%, #302b63 50%, #24243e 100%)",
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
        overflow: "hidden",
        position: "relative",
        boxSizing: "border-box",
        fontFamily: "'Nunito', sans-serif",
      }}
    >
      <style>{`
        @import url('https://fonts.googleapis.com/css2?family=Fredoka+One&family=Nunito:wght@400;700;900&display=swap');

        .qm-title {        
          font-family: 'Fredoka One', cursive;
          font-size: clamp(2.5rem, 5vw, 4rem);
          background: linear-gradient(90deg, #fbbf24, #f87171, #a78bfa, #34d399, #fbbf24);
          background-size: 300% auto;
          -webkit-background-clip: text;
          -webkit-text-fill-color: transparent;
          background-clip: text;
          line-height: 1.2;
          margin: 0 0 16px 0;
          letter-spacing: 2px;
        }

        .qm-subtitle {
          color: #c4b5fd;
          font-weight: 700;
          letter-spacing: 2px;
          font-size: 1rem;
          margin: 0 0 32px 0;
        }

        .qm-card {
          background: rgba(255,255,255,0.07);
          border: 1px solid rgba(255,255,255,0.15);
          border-radius: 20px;
          padding: 36px 28px;
          display: flex;
          flex-direction: column;
          align-items: center;
          gap: 18px;
        }

        .qm-btn {
          font-family: 'Fredoka One', cursive;
          font-size: 1rem;
          padding: 12px 28px;
          border: none;
          border-radius: 100px;
          background: linear-gradient(135deg, #f59e0b, #ef4444);
          color: white;
          cursor: pointer;
          letter-spacing: 2px;
        }

        .qm-btn:hover {
          transform: scale(1.05);
        }

        .file-input {
          color: white;
        }

        .file-name {
          color: #a5f3fc;
          font-weight: 700;
        }
      `}</style>

      <h1 className="qm-title">Upload Quiz</h1>
      <p className="qm-subtitle">Choose your JSON quiz file</p>

      <form className="qm-card" onSubmit={handleSubmit}>
        <input
          className="file-input"
          type="file"
          accept=".json"
          onChange={handleFileChange}
        />

        {fileName && <p className="file-name">Selected: {fileName}</p>}

        <button className="qm-btn" type="submit">
          Submit
        </button>

        <button className="qm-btn" type="button" onClick={onExit}>
          Back
        </button>
      </form>
    </div>
  );
}

export default UploadPage;
