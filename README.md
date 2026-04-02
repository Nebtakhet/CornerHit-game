# 🎮 CornerHit

> A game inspired by the iconic DVD screensaver. Experience the thrill of breaking free from glass boxes by smashing the ball into the corners!

---

## 🎯 Overview

**CornerHit** is a unique arcade-style game that captures the nostalgia and anticipation of the classic DVD screensaver logo bouncing around the screen. But this time, *you're in control*.

### The Premise

You're trapped inside a series of shrinking glass boxes. A ball bounces endlessly around your arena. Your mission? **Hit the ball toward the corners to shatter the glass and escape!** Each corner hit breaks a section of your prison, and after enough hits, you'll finally be set free.

```
┌─────────────────────────────────────┐
│                                     │
│         ◆ (Ball)                   │
│      ↙  ↓  ↙                        │
│     ┃   ┃   ┃                       │
│     ┃ ███   ┃   ← Hit the ball!    │
│     ┃ ┃P┃   ┃                       │
│     ┃ ███   ┃                       │
│     ┃   ┃   ┃                       │
│     ╱   ┃   ╱                       │
│    ┌─────────────────────────────┐  │  ← Corner hit!
│    │ (P) Player                  │  │     🔨 CRACK! 💥
│    │ [Glass Box Breaks]          │  │
│    └─────────────────────────────┘  │
│                                     │
└─────────────────────────────────────┘
```

---

## 🎮 Gameplay Mechanics

### Core Features

| Feature | Description |
|---------|-------------|
| 🎯 **Player Control** | Move left and right to position yourself under the ball |
| 💫 **Ball Physics** | Realistic ball dynamics with bouncing and momentum |
| 🔨 **Hit System** | Time your hits perfectly to send the ball toward corners |
| 📦 **Arena Progression** | 5 stages of increasingly smaller boxes to break |
| 🎥 **Camera Effects** | Dynamic camera shake when boxes break |
| ⌚ **Pause System** | Press `ESC` to pause/unpause the game |
| 🔄 **Restart** | Press `R` to restart (when game over) |

### Win Condition

🏆 **Escape all 5 stages!** Break enough corners to escape your glass prison and achieve victory.

### Game Stages

```
Stage 1:  [████████████████]  ← Largest arena
Stage 2:  [█████████████]
Stage 3:  [██████████]
Stage 4:  [███████]
Stage 5:  [████]     ← Smallest arena
```

Each corner hit reduces the box size, creating an increasingly challenging experience!

---

## 🕹️ Controls

| Input | Action |
|-------|--------|
| `← / →` or `A / D` | Move player left/right |
| `LEFT MOUSE` | Hit the ball |
| `ESC` | Pause/Resume |
| `R` | Restart game (when game over) |

---

## 🛠️ Technical Details

### Project Setup

- **Engine**: Unity 6 (6000.3.10f1)
- **Render Pipeline**: Universal Render Pipeline (URP)
- **Physics**: 2D Physics Engine
- **Input System**: New Input System

### Core Systems

```
┌─────────────────────────────────────────┐
│          GameManager (Singleton)        │ ← Master game controller
├─────────────────────────────────────────┤
│   ├── ArenaManager                      │ ← Box/stage management
│   ├── BallController                    │ ← Ball physics & movement
│   ├── PlayerController                  │ ← Player input & movement
│   ├── PlayerHit                         │ ← Ball hitting logic
│   ├── CornerTrigger                     │ ← Corner detection & events
│   ├── CameraController                  │ ← Camera following
│   ├── CameraShake                       │ ← Feedback effects
│   ├── UIManager                         │ ← UI & HUD
│   └── RestartGame                       │ ← Game restart logic
└─────────────────────────────────────────┘
```

### Key Components

#### 🎯 ArenaManager
- Manages the glass box arena and its 5 progressive stages
- Controls wall shrinking and arena growth
- Detects corner collision triggers

#### ⚪ BallController
- Handles ball physics and bouncing behavior
- Manages velocity and collision responses
- Applies realistic physics simulation

#### 🧑 PlayerController
- Handles player movement and positioning
- Responds to input from the New Input System
- Keeps player within arena bounds

#### 💥 PlayerHit
- Manages the ball hitting mechanic
- Applies force to the ball when player connects
- Calculates hit direction and power

#### 🔷 CornerTrigger
- Detects when the ball hits a corner
- Triggers stage progression and box breaking
- Initiates camera shake feedback

---

## 📁 Project Structure

```
CornerHit/
├── Assets/
│   ├── Scripts/                    # Game logic
│   │   ├── GameManager.cs
│   │   ├── ArenaManager.cs
│   │   ├── BallController.cs
│   │   ├── PlayerController.cs
│   │   ├── PlayerHit.cs
│   │   ├── CornerTrigger.cs
│   │   ├── CameraController.cs
│   │   ├── CameraShake.cs
│   │   ├── UIManager.cs
│   │   └── RestartGame.cs
│   ├── Scenes/                     # Game scenes
│   │   └── MainScene.unity
│   ├── Materials/                  # Physics materials
│   ├── Settings/                   # Game settings
│   └── TextMesh Pro/              # Text assets
├── ProjectSettings/                # Unity project config
├── Packages/                       # Package dependencies
└── README.md                       # This file
```

---

## 🎮 How to Play

1. **Start the Game** - Launch the game in the MainScene
2. **Watch the Ball** - Observe the ball's movement pattern
3. **Position Yourself** - Move your player to intercept the ball
4. **Time Your Hit** - Hit the ball to send it toward a corner
5. **Aim for Corners** - Each corner hit breaks glass and shrinks the box
6. **Progress Through Stages** - Complete 5 stages to escape!
7. **Victory!** - You're free! 🎉

### Pro Tips 🎯

- 💡 **Predict Bounces** - Watch the ball's trajectory to anticipate corners
- ⚡ **Perfect Timing** - Hit the ball at the right angle for maximum edge hits
- 🎯 **Corner Priority** - Focus on hitting corners, not just bouncing the ball
- 👀 **Watch the Shake** - Camera effects indicate successful corner hits
- 🔄 **Learn the Pattern** - The arena gets smaller, so adapt your strategy!

---

## 🎨 Visual Design

- **Minimalist Aesthetic** - Clean, focused gameplay
- **Glass Box Theme** - Modern, sleek visual style
- **Dynamic Feedback** - Camera shake and visual effects on corner hits
- **Progress Visualization** - Easily see your arena shrinking as you progress

---

## 🚀 Getting Started

### Requirements

- Unity 6 (6000.3.10f1)
- Universal Render Pipeline (URP)

### Installation

1. Clone or download this repository
2. Open the project in Unity 6
3. Load the `Assets/Scenes/MainScene.unity`
4. Press Play in the Unity Editor

### Building

1. Go to `File` → `Build Settings`
2. Add `MainScene.unity` to the Scenes In Build list
3. Configure your target platform
4. Click `Build` and select your output directory

---

## 🎵 Inspiration

CornerHit is a heartfelt tribute to the **DVD screensaver** - that iconic logo bouncing around the screen while we waited in anticipation for it to hit the corner. Now, you can make it happen whenever you want!

The game explores themes of:
- 🎯 **Precision & Timing** - Master the art of perfect hits
- 🔨 **Breaking Free** - Progressively escape your constraints
- 🎮 **Arcade Nostalgia** - Simple controls, deep gameplay
- 💪 **Player Agency** - You decide when to break out!

---

## 📝 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## 🤝 Contributing

Have ideas to improve CornerHit? Feel free to:
- Report bugs 🐛
- Suggest features ✨
- Submit pull requests 📬

---

## 🎮 Game Feel

Experience:
- ✨ Smooth ball physics and physics materials for realistic bouncing
- 💫 Dynamic camera effects that react to your corner hits
- 🎯 Responsive player controls through the New Input System
- 🔊 Progressive difficulty as boxes shrink
- 🏆 Satisfying progression through 5 stages

---

## 📞 Support

For questions or issues, please open an issue in the repository.

---

**Made with ❤️ and inspired by nostalgia** 🎬

Good luck breaking free, player! 🚀

