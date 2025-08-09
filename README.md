# Test Game App

## Features Implemented

### **Assignment 1 – Grid Block Generation**
- Generates a **10x10 grid** of tiles at runtime.
- Each tile stores its `(x, y)` grid coordinates.
- Mouse hover displays the tile's coordinates in a UI element.

### **Assignment 2**
- Custom Unity **Editor Window** to toggle obstacles on/off for each grid cell.
- Obstacle data is stored in a **ScriptableObject**.
- At runtime, obstacles are visualized with red spheres placed on the corresponding tiles.

### **Assignment 3**
- Implemented a **Breadth-First Search (BFS)** algorithm for grid-based pathfinding.
- Player unit moves smoothly.
- Movement is blocked by obstacle tiles.

### **Assignment 4 – Enemy AI**
- Enemy unit implements an **IAI** interface.
- Enemy moves toward the player after the player finishes moving.
- Stops on one of the four adjacent tiles to the player.
- Uses the same pathfinding algorithm as the player.

---

## Controls
- **Left Click**: Move the player to the selected tile.
- **Hover Mouse**: Displays tile coordinates.
- Enemy automatically moves after the player finishes moving.

---


## How to Use the Obstacle Editor
1. Open the **Obstacle Editor** from `Tools → Obstacle Editor` in Unity.
2. Assign the `ObstacleData` asset (present in the root folder).
3. Toggle cells to place/remove obstacles.
4. Click **Save** to store changes.
5. Play the game to see obstacles appear.

--- 

## More Info
- Unity version used is 2022.3.20f1
- Render Pipeline is URP.
