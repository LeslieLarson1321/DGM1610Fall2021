using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;

    public int curScore;

    public bool gamePaused;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        // Toggles the pause menu.
        GameUI.instance.TogglePauseMenu(gamePaused);
    }

    public void AddScore(int score)
    {
        curScore += score;

        // Updates score text.
        GameUI.instance.UpdateScoreText(curScore);

        // If it does have enough points to run, then-
        if(curScore >= scoreToWin)
            WinGame();
    }

    void WinGame()
    {       // Show win screen.
        GameUI.instance.SetEndgameScreen(true, curScore);
    }
}
