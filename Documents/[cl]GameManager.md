## Game Manager
- 게임의 전반적인 흐름을 관리한다.

### Functions
- Initialize
	- [**Physics**] Disable Input
	- [**UI**] Change blackscreen transparent by float (0~100)
	- Sets all scores to zero
	- [**UI**] Update UI by int (score)
	- Set *_lastWinner* parameter to Player.Left
	- Call *ResetPos* function
	- Call *I_GameStart* coroutine
- Score (Input : *Player*(enum))
	- Set *_lastWinner* parameter
	- Add parameters by *_lastWinner* parameter
	- [**UI**] Update UI by int (score)
	- Call *EndRnd* function
- EndRnd
	- [**Physics**] Disable Input
	- [**Physics/Animation**] Slowdown time (player/ball)
	- Call *I_FadeOut* coroutine
- ResetPos
	- Differs by the *_lastWinner* parameter
	- Reset players/ball position
	- [**Physics**] Pin ball
	- [**Physics/Animation**] Default time (player/ball)
- StartRnd
	- [**Physics**] Enable Input
	- [**Physics**] Unpin ball
- EndGm
	- [**Physics**] Disable Input
	- [**Physics**] Fix state of ball
	- [**Physics/Animation**] Win/Defeat Animation
	- Call *I_GameOver* coroutine

### Coroutines
- I_GameStart
	- [**UI**] Change blackscreen transparent by float (0~100)
	- [**UI**] Transform GameStartUI
	- Call *StartRnd* function
- I_FadeOut
	- [**UI**] Change blackscreen transparent by float (0~100)
	- Call *ResetPos* function
	- Call *I_FadeIn* coroutine
- I_FadeIn
	- [**UI**] Change blackscreen transparent by float (0~100)
	- [**UI**] Set/Unset ReadyUI
	- Call *StartRnd* function
- I_GameOver
	- [**UI**] Transform GameSetUI
	- [**Scene**] Return to MainMenu

### Enum
- Player
	- Left
	- Right