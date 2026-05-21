// Runs the web server that hosts the website AND serves the JSON files when the website asks for them

// Require is how javascript imports
const express = require("express");
const path = require("path");
const fs = require("fs").promises;

const app = express(); // Creating the server "app"
const PORT = 3000; // The "door number" the server 

// Folders to be organized for each URL
app.use(express.static(path.join(__dirname, "public")));
app.use("/data", express.static(path.join(__dirname, "data")));

// List all the available activities for a gametype and take the variables gameType as a parameter
app.get("/api/activities/:gameType", async (req, res) => {
  const { gameType } = req.params;
  // Build the path for the folder for this game type (one game type at a time for when a player picks a game)
  const dirPath = path.join(__dirname, "data", gameType);

  try {
    // Read the list of all files inside of that folder that we just made
    const files = await fs.readdir(dirPath);
    // Keep only JSON files in the folder
    const activityNames = files
      .filter((f) => f.endsWith(".json"))
      .map((f) => f.replace(".json", ""));
    // Send the clean list back to API and frontend
    res.json(activityNames);
    // If there are any errors
  } catch (error) {
    if (error.code === "ENOENT") {
      res.status(404).json({ error: `No activities found for game type: ${gameType}` });
    } else {
      res.status(500).json({ error: "Failed to list activities" });
    }
  }
});

// Fetch a single activity file within the server itself and take the variables gameType and fileName as parameters
app.get("/api/activity/:gameType/:fileName", async (req, res) => {
  const { gameType, fileName } = req.params;

  const filePath = path.join(__dirname, "data", gameType, `${fileName}.json`);

  try {
    // Read the file contents
    const rawData = await fs.readFile(filePath, "utf8");
    const activity = JSON.parse(rawData);
    // Send the object back to whoever asked (API and frontend)
    res.json(activity);
    // If there are any errors
  } catch (error) {
    if (error.code === "ENOENT") {
      res.status(404).json({ error: `Activity file not found: ${gameType}/${fileName}` });
    } else {
      res.status(500).json({ error: "Failed to load activity file" });
    }
  }
});

// Starting the server
app.listen(PORT, () => {
  console.log(`Pub Quiz Buster server running at http://localhost:${PORT}`);
});