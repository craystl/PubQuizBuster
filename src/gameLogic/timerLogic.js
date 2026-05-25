// Time Logic 

// Timer settings
export const TIMER_CONFIG = {
  TICK_INTERVAL_MS: 1000,
  WARNING_THRESHOLD_SECONDS: 5,
};


// Creates and starts a new timer
export const createTimer = (
  duration,
  onTick,
  onExpire,
  onWarning = null
) => {

  // Make sure valid values were passed in
  if (typeof duration !== "number" || duration <= 0) {
    throw new Error("Duration must be a positive number");
  }

  if (typeof onTick !== "function") {
    throw new Error("onTick must be a function");
  }

  if (typeof onExpire !== "function") {
    throw new Error("onExpire must be a function");
  }

  // Internal timer values
  let timeRemaining = duration;
  let isPaused = false;
  let isStopped = false;
  let warningTriggered = false;
  let intervalId = null;

  // Runs every second
  const tick = () => {

    // Stop ticking if paused or stopped
    if (isPaused || isStopped) return;

    // Reduce time by 1 second
    timeRemaining--;

    // Trigger warning once when timer is low
    if (
      !warningTriggered &&
      onWarning &&
      timeRemaining <= TIMER_CONFIG.WARNING_THRESHOLD_SECONDS
    ) {
      warningTriggered = true;
      onWarning(timeRemaining);
    }

    // Update UI
    onTick(timeRemaining, duration);

    // Timer finished
    if (timeRemaining <= 0) {

      clearInterval(intervalId);
      intervalId = null;

      isStopped = true;

      // Tell game controller time is up
      onExpire();
    }
  };

  // Show starting time immediately
  onTick(timeRemaining, duration);

  // Start countdown
  intervalId = setInterval(
    tick,
    TIMER_CONFIG.TICK_INTERVAL_MS
  );

  // Return timer object
  return {

    // Read-only values
    get timeRemaining() {
      return timeRemaining;
    },

    get isPaused() {
      return isPaused;
    },

    get isStopped() {
      return isStopped;
    },

    get duration() {
      return duration;
    },

    // Internal helper methods
    _getIntervalId: () => intervalId,

    _setIntervalId: (id) => {
      intervalId = id;
    },

    _setIsPaused: (value) => {
      isPaused = value;
    },

    _setIsStopped: (value) => {
      isStopped = value;
    },

    _tick: tick,
  };
};


// Pause the timer
export const pauseTimer = (timerHandle) => {

  // Do nothing if invalid
  if (
    !timerHandle ||
    timerHandle.isPaused ||
    timerHandle.isStopped
  ) {
    return;
  }

  // Stop interval temporarily
  clearInterval(timerHandle._getIntervalId());

  timerHandle._setIntervalId(null);
  timerHandle._setIsPaused(true);
};


// Resume paused timer
export const resumeTimer = (timerHandle) => {

  // Only resume paused timers
  if (
    !timerHandle ||
    !timerHandle.isPaused ||
    timerHandle.isStopped
  ) {
    return;
  }

  // Continue timer
  timerHandle._setIsPaused(false);

  const newInterval = setInterval(
    timerHandle._tick,
    TIMER_CONFIG.TICK_INTERVAL_MS
  );

  timerHandle._setIntervalId(newInterval);
};


// Completely stop the timer
export const stopTimer = (timerHandle) => {

  // Do nothing if already stopped
  if (!timerHandle || timerHandle.isStopped) {
    return;
  }

  // Clear running interval
  if (timerHandle._getIntervalId() !== null) {

    clearInterval(timerHandle._getIntervalId());

    timerHandle._setIntervalId(null);
  }

  timerHandle._setIsStopped(true);
  timerHandle._setIsPaused(false);
};


// Returns progress as a decimal
// E.g. 0.5 = 50%
export const getTimerProgress = (timerHandle) => {

  if (!timerHandle || timerHandle.duration <= 0) {
    return 0;
  }

  return Math.max(
    0,
     timerHandle.timeRemaining / timerHandle.duration
  );
};
//