using UnityEngine;
using System.Collections;

public enum Player { Left, Right };

public class GameManager : MonoBehaviour {

    // GameObjects
    public GameObject _playerLeft;
    public GameObject _playerRight;
    public GameObject _ball;

    // Rule Parameters
    public int _maxScore;

    private Player _lastWinner;
    private int _scoreL;
    private int _scoreR;


    // Initial Position
    private Vector3 _playerLeftPos;
    private Vector3 _playerRightPos;
    private Vector3 _ballLeftPos = new Vector3(0, 0, 0);    // TODO: Set initial ball positions
    private Vector3 _ballRightPos = new Vector3(0, 0, 0);

    void Start()
    {
        _playerLeftPos = _playerLeft.transform.position;    // Get Initial Position
        _playerRightPos = _playerRight.transform.position;

        Initialize();
    }

    // When a player scores
    public void Score(Player winner)
    { 
        _lastWinner = winner;                       // Update last winner

        if (winner == Player.Left) _scoreL += 1;    // Update score
        else _scoreR += 1;

        // UI: Update ScoreUI

        if (_scoreL == _maxScore || _scoreR == _maxScore) EndGm();  // If reached maxscore, end game
        else EndRnd();                                              // else end round
    }

    // Reset the whole game
    private void Initialize()
    {
        // PHYSICS: Disable Input
        
        // UI: Black Screen

        _scoreL = 0;                    // Set all scores to zero
        _scoreR = 0;

        // UI: Update UI by int

        _lastWinner = Player.Left;      // Set first player to LeftPlayer

        ResetPos();                     // Reset Position

        // PHYSICS: Pin Ball

        StartCoroutine(I_GameStart());    // Start Animation
    }

    // Start Round
    private void StartRnd()
    {
        // PHYSICS: Enable Input

        // PHYSICS: Unpin Ball
    }

    // End Round
    private void EndRnd()
    {
        // PHYSICS: Disable Input

        // PHYSICS: Decrease time speed (player/time) (/w Animation)

        StartCoroutine(I_FadeIn());
    }

    // End Game
    private void EndGm()
    {
        // PHYSICS: Disable Input

        // PHYSICS: Fix state of ball to max

        // PHYSICS: Win/Defeat Animation (Coroutine / Input: Player(_lastWinner))

        StartCoroutine(I_GameOver());
    }

    // Reset Player&Ball Positions
    private void ResetPos()
    {
        _playerLeft.transform.position = _playerLeftPos;                            // Reset Player Position
        _playerRight.transform.position = _playerRightPos;

        if (_lastWinner == Player.Left) _ball.transform.position = _ballLeftPos;    // Reset Ball Position by Winner
        else _ball.transform.position = _ballRightPos;
    }

    // Coroutines (for Animations)
    IEnumerator I_GameStart()
    {
        // UI: Fade In (Coroutine, yield)

        // UI: Animate GameStartUI (Coroutine, yield)

        StartRnd();

        yield return null;  // TODO: Delete this line after implementing 'yield return StartCoroutine()'
    }
    IEnumerator I_FadeOut()
    {
        // UI: Fade Out (Coroutine, yield)

        ResetPos();

        // PHYSICS: Pin Ball

        // PHYSICS: Restore time speed

        StartCoroutine(I_FadeIn());

        yield return null;  // TODO: Delete this line after implementing 'yield return StartCoroutine()'
    }
    IEnumerator I_FadeIn()
    {
        // UI: Fade In (Coroutine, yield)

        // UI: Control ReadyUI (Coroutine, yield)

        StartRnd();

        yield return null;  // TODO: Delete this line after implementing 'yield return StartCoroutine()'
    }
    IEnumerator I_GameOver()
    {
        // UI: Control GameSetUI (Coroutine, yield)

        // TODO: Return to MainMenu

        yield return null;  // TODO: Delete this line after implementing 'yield return StartCoroutine()'
    }
}
