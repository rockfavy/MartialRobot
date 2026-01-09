# Martian Robots

A C# console application that simulates robots navigating on a rectangular grid on Mars, following instructions from Earth. Robots can move forward, turn left/right, and leave "scents" when they fall off the grid to prevent future robots from falling at the same location.

## Table of Contents

- [Problem Overview](#problem-overview)
- [Approach: Process-Activity-Use Case-Tasks Breakdown](#approach-process-activity-use-case-tasks-breakdown)
- [Architecture & Design](#architecture--design)
- [Technology Choices](#technology-choices)
- [Project Structure](#project-structure)
- [Running Instructions](#running-instructions)
- [Testing](#testing)
- [Sample Input/Output](#sample-inputoutput)

## Problem Overview

The surface of Mars is modeled by a rectangular grid. Robots receive instructions (L=Left, R=Right, F=Forward) and move accordingly. If a robot moves off the grid, it's lost forever but leaves a "scent" at its last position. Future robots attempting to move off from a scented position will have that move ignored.

**Input Format:**
- First line: Upper-right grid coordinates (lower-left is 0,0)
- Subsequent pairs: Robot position (x y orientation) followed by instruction string

**Output Format:**
- For each robot: Final position and orientation, with "LOST" appended if the robot fell off the grid

## Approach: Process-Activity-Use Case-Tasks Breakdown

The solution was developed using a structured breakdown following **Process → Activity → Use Case → Tasks** methodology, implemented with **vertical slicing** to deliver complete, working features incrementally.

### Process: Martian Robot Navigation System

#### Activity 1: Initialize the Grid
**Use Case 1.1: Set up world boundaries**
- **Task 1.1.1:** Parse upper-right coordinates from input
- **Task 1.1.2:** Create grid with boundaries

**Implementation:** `Features/GridBoundaries/` feature folder

---

#### Activity 2: Process Robot Instructions
**Use Case 2.1: Initialize a robot**
- **Task 2.1.1:** Parse initial position (x, y, orientation)
- **Task 2.1.2:** Create robot instance

**Use Case 2.2: Execute instruction sequence**
- **Task 2.2.1:** Parse instruction string (L, R, F)
- **Task 2.2.2:** Process each instruction sequentially
- **Task 2.2.3:** Track robot state

**Use Case 2.3: Handle robot movement**
- **Task 2.3.1:** Execute Left turn (rotate 90° counter-clockwise)
- **Task 2.3.2:** Execute Right turn (rotate 90° clockwise)
- **Task 2.3.3:** Execute Forward move (move one step in current direction)

**Use Case 2.4: Detect and handle boundary violations**
- **Task 2.4.1:** Check if move would go off-grid
- **Task 2.4.2:** Check if position has a "scent"
- **Task 2.4.3:** If scent exists, ignore the move
- **Task 2.4.4:** If no scent and move is off-grid, mark robot as LOST and leave scent

**Implementation:** 
- `Features/BasicRobotMovement/` - Core movement functionality
- `Features/GridBoundaries/` - Boundary checking (Task 2.4.1)
- `Features/ScentTracking/` - Scent management (Tasks 2.4.2-2.4.4)

---

#### Activity 3: Output Results
**Use Case 3.1: Report final robot state**
- **Task 3.1.1:** Format output (x y orientation)
- **Task 3.1.2:** Append "LOST" if robot fell off grid
- **Task 3.1.3:** Write to console

**Implementation:** `Features/MultipleRobots/` - Full input/output orchestration

---

## Architecture & Design

### Design Patterns Used

1. **Command Pattern** - Each instruction (L, R, F) is implemented as a command object implementing `ICommand`
   - Enables extensibility for future command types
   - Single Responsibility Principle - each command handles one type of movement

2. **Factory Pattern** - `CommandFactory` creates command instances from characters
   - Centralizes command creation logic
   - Simplifies adding new command types

3. **Strategy Pattern** - Different movement strategies based on orientation
   - Encapsulates direction-specific movement logic

### SOLID Principles

- **Single Responsibility:** Each class has one clear purpose
  - `Grid` - boundary management
  - `Robot` - position and orientation state
  - `ScentTracker` - scent management
  - Commands - individual instruction execution

- **Open/Closed:** New command types can be added without modifying existing code

- **Dependency Inversion:** Commands depend on abstractions (`ICommand`, `MarsGrid`, `ScentTracker`)

### Vertical Slicing Approach

The solution was built incrementally, with each "slice" delivering a complete, working feature:

1. **Slice 1: Basic Robot Movement** - Robots can move and turn (infinite grid)
2. **Slice 2: Grid Boundaries** - Robots detect and report when falling off grid
3. **Slice 3: Scent Tracking** - Scents prevent future robots from falling at same spot
4. **Slice 4: Multiple Robots** - Full input parsing and multiple robot processing

## Technology Choices

### C# .NET 8.0 Console Application
- **Why:** Simple, straightforward I/O for reading input and writing output
- **Why .NET 8.0:** Latest LTS version with modern C# features
- **Why Console App:** Perfect fit for command-line input/output requirements

### xUnit Testing Framework
- **Why:** Industry standard for .NET unit testing
- **Why:** Excellent integration with Visual Studio and CI/CD pipelines
- **Why:** Clean, readable test syntax

### Feature-Based Folder Structure
- **Why:** Organizes code by business capability rather than technical layer
- **Why:** Makes it easy to see what features are implemented
- **Why:** Supports vertical slicing - each feature folder contains complete functionality

### No External Dependencies
- **Why:** KISS principle - keeps the solution simple and easy to understand
- **Why:** No dependency management overhead
- **Why:** Faster build and execution times

## Project Structure

```
MartialRobot/
├── Features/
│   ├── BasicRobotMovement/      # Slice 1: Core movement functionality
│   │   ├── Commands/             # L, R, F command implementations
│   │   ├── Models/               # Robot, Orientation, CoordonatePoint
│   │   └── Parsers/              # Instruction and position parsing
│   ├── GridBoundaries/           # Slice 2: Boundary detection
│   │   ├── Models/               # MarsGrid
│   │   └── Parsers/              # Grid coordinate parsing
│   ├── ScentTracking/            # Slice 3: Scent management
│   │   └── ScentTracker.cs       # Scent tracking logic
│   └── MultipleRobots/            # Slice 4: Full orchestration
│       └── Parsers/              # Complete input parsing
├── Program.cs                    # Entry point
└── README.md                     # This file

MartialRobot.Tests/
└── Features/                     # Tests mirror feature structure
    ├── BasicRobotMovement/
    ├── GridBoundaries/
    ├── ScentTracking/
    └── MultipleRobots/
```

## Running Instructions

### Prerequisites
- .NET 8.0 SDK or later
- Windows, Linux, or macOS

### Build the Solution
```bash
cd MartialRobot
dotnet build
```

### Input Methods

The application supports **two input methods**:

#### Method 1: File Input via Command-Line Argument (Non-Interactive)
If you provide a filename as a command-line argument, the application reads directly from that file:

```bash
dotnet run -- sample-input.txt
```

#### Method 2: Interactive Mode
If no arguments are provided, the application will guide you through an interactive session:

```bash
dotnet run
```

The application will prompt you step-by-step:

1. **Select input method:**
   ```
   Select input method (1=File, 2=Manual, -1=Exit):
   ```
   - Type `-1` to exit immediately (you'll see a message explaining the exit)

2. **If you choose File (option 1):**
   - Enter the file path when prompted
   - Type `-1` to exit (you'll see a message explaining the exit)
   
   **Exit Messages:** When you type `-1` to exit, the application will display:
   - What action you chose (exit)
   - What happened (file input cancelled, no processing performed)
   - How to run the application again
   - A thank you message

3. **If you choose Manual (option 2):**
   - Enter grid size when prompted: `Grid size (maxX maxY):`
   - Type `-1` to exit (you'll see a message explaining the exit)
   - For each robot:
     - Enter robot position: `Robot position (x y orientation) or -1 to finish:`
       - Type `-1` to finish input collection and start processing
       - Type `-1` to exit (you'll see a message explaining the exit)
     - Enter instructions: `Instructions:`
       - Type `-1` to exit (you'll see a warning that instructions are required)
   
   **Exit Messages:** When you type `-1` to exit, the application will display:
   - What action you chose (exit)
   - What happened (input cancelled, no processing performed)
   - How to run the application again
   - A thank you message

### Create Sample Input File
Create a file named `sample-input.txt` in the project root:
```
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL
```

## Testing

### Run All Tests
```bash
cd MartialRobot
dotnet test
```

### Run Tests with Verbose Output
```bash
dotnet test --verbosity normal
```

### Run Specific Test Class
```bash
dotnet test --filter "FullyQualifiedName~IntegrationTests"
```

### Test Coverage

The solution includes comprehensive unit tests organized by feature:

- **130 tests total**
- **Unit Tests:** Test individual components in isolation
- **Integration Tests:** Test complete workflows with sample input

#### Test Structure
- `Features/BasicRobotMovement/` - Tests for orientation, commands, parsing
- `Features/GridBoundaries/` - Tests for boundary detection
- `Features/ScentTracking/` - Tests for scent management
- `Features/MultipleRobots/` - Integration tests with full input/output

#### Key Test Scenarios Covered
- ✅ Orientation rotations (left/right)
- ✅ Robot movement in all directions
- ✅ Boundary detection and "LOST" marking
- ✅ Scent tracking and prevention of falls
- ✅ Multiple robots processing
- ✅ Input parsing edge cases
- ✅ Complete integration with sample input

### Running Tests Step-by-Step

1. **Navigate to project directory:**
   ```bash
   cd MartialRobot
   ```

2. **Run all tests:**
   ```bash
   dotnet test
   ```

3. **Verify output shows all tests passing:**
   ```
   Passed!  - Failed:     0, Passed:   130, Skipped:     0, Total:   130
   ```

4. **Run specific test categories:**
   ```bash
   # Integration tests only
   dotnet test --filter "FullyQualifiedName~Integration"
   
   # Command tests only
   dotnet test --filter "FullyQualifiedName~Commands"
   ```

## Sample Input/Output

### Input
```
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL
```

### Expected Output
```
1 1 E
3 3 N LOST
2 3 S
```

### Explanation
1. **Robot 1:** Starts at (1,1) facing East. Executes RFRFRFRF (Right-Forward-Right-Forward...). Ends at (1,1) facing East - stays in place.
2. **Robot 2:** Starts at (3,2) facing North. Executes FRRFLLFFRRFLL. Moves forward to (3,3), then attempts to move North off the grid. Falls off and is marked LOST, leaving a scent at (3,3).
3. **Robot 3:** Starts at (0,3) facing West. Executes LLFFFLFLFL. Moves to (2,3) facing South. When attempting to move North from (3,3), the scent prevents it from falling off.

## Development Approach

This solution was developed using:
- **Test-Driven Development (TDD)** - Tests written before implementation
- **Vertical Slicing** - Complete features delivered incrementally
- **SOLID Principles** - Clean, maintainable code
- **Feature-Based Organization** - Code organized by business capability
- **Incremental Commits** - Each feature slice committed separately

## Future Enhancements

The architecture supports easy extension:
- New command types can be added by implementing `ICommand`
- Additional grid shapes could be supported
- Different planet surfaces could be modeled
- Visualization could be added

---

**Author:** Rock Favy Mbadinga D.  
**Date:** January 2026  
**Version:** 1.0

