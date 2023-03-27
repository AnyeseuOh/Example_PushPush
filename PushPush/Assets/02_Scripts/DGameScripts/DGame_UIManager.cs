using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DGame_UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text hpText;
    public DGame_Ground ground;
    public DGame_PLMove pl;

    public GameObject GameOverPanel;
    public Text gameOverScoreText;

    void Start()
    {
        GameOverPanel.SetActive(false);
        ground = GameObject.Find("Ground").GetComponent<DGame_Ground>();
        pl = GameObject.Find("DGame_Player").GetComponent<DGame_PLMove>();
    }

    
    void Update()
    {
        scoreText.text = "SCORE : " + ground.score.ToString();
        hpText.text = "HP : " + pl.hp.ToString();

        if (pl.hp <= 0)
        {
            Time.timeScale = 0;
            //Debug.Log("GAME OVER!");
            GameOverPanel.SetActive(true);
            gameOverScoreText.text = scoreText.text;
            return;
        }
    }
}
