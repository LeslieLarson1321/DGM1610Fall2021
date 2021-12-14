using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]

    public TextMeshProGui scoreText;

    public TextMeshProGui ammoText;

    public image healthBarFill;

    [Header("Pause Menu")]

    public GameObject endgameScreen;

    public TextMeshProGui endgameHeaderText;

    public TextMeshProGui endgameScoreText;

    // Instance / Singleton

    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateHealthBar (int curHp, int maxHp)
    {
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;
    }

    public void UpdateScoreText (int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateAmmoText (int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }

    public void TogglePauseMenu (bool paused)
    {
        pauseMenu.SetActive(paused);
    }

    public void SetEndgameScreen (bool won, int score)
    {
        endgameScreen.SetActive(true);
        endgameHeaderText.text = won == true ? "You've Won!" : "You've Lost!";
        endgameHeaderText.color = won == true ? Color.green : Color.red;
        endgameScoreText.text = "cb>Score</b>\n" + score;
    }

    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
