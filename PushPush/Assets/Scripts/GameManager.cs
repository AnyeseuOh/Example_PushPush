using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] buckets;
    public GameObject[] balls;
    public int curCnt = 0;
    public int maxCnt = 0;
    public int correctCnt;
    public int inCorrectCnt;
    public int curLv = 1;
    public int maxLv = 10;
    public MapGenerator mapGenerator;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stageNumText;

    public void SetBucketAndBalls()
    {
        StartCoroutine(FindBucketsAndBalls());
    }

    IEnumerator FindBucketsAndBalls()
    {
        yield return buckets = new GameObject[GameObject.FindGameObjectsWithTag("Bucket").Length];
        yield return balls = new GameObject[GameObject.FindGameObjectsWithTag("Ball").Length];

        buckets = GameObject.FindGameObjectsWithTag("Bucket");
        balls = GameObject.FindGameObjectsWithTag("Ball");

        curCnt = 0;
        maxCnt = balls.Length;

        scoreText.text = curCnt + " / " + maxCnt;
        stageNumText.text = curLv.ToString();
        Debug.Log("max cnt ::: " + maxCnt);
    }

    public void CheckBallPosition()
    {
        for (int i=0; i< buckets.Length; i++)
        {
            for (int j=0; j<balls.Length; j++)
            {
                if (buckets[i].transform.position == balls[j].transform.position)
                {
                    correctCnt++;
                    curCnt = correctCnt;
                }
            }
        }
        correctCnt = 0;
        scoreText.text = curCnt + " / " + maxCnt;

        if (curCnt == maxCnt)
        {
            Debug.Log("STAGE CLEAR!");
            curLv++;
            curCnt = 0;
            maxCnt = 0;
            if (curLv != maxLv)
            {
                mapGenerator.MapDestroy(curLv);
            }
            else
            {
                Debug.Log("ALL STAGE CLEAR!");
            }
        }
    }

    public void Retry()
    {
        Debug.Log("Àç½ÃÀÛ");
        mapGenerator.MapDestroy(curLv);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void MoveToStage()
    {
        SceneManager.LoadScene("Main");
    }

    public void MoveToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
