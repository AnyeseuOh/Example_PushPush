using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DGame_GameManager : MonoBehaviour
{
    public DGame_PLMove pl;

    void Start()
    {
        Time.timeScale = 1f;
        pl = GameObject.Find("DGame_Player").GetComponent<DGame_PLMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("DdongGame_V2");
    }

    public void MoveToIntro()
    {
        SceneManager.LoadScene("DdongGame_V2_Intro");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

}
