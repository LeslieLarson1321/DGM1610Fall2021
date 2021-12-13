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

    public TextMeshPro ammoText;

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

    public void UpdateHealthBar(int curHp, int maxHp)
    {
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;
    }

    public void UpdateScoreText (int score)
    {
        scoreText.text;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
