using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] mapObjectPrefab;
    public string dataPath;
    public List<Dictionary<string, object>> data;
    public GameManager gameManager;

    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            LoadMapData(1);
            for (int j=0; j<12; j++)
            {
                GameObject ground = Instantiate(mapObjectPrefab[0]) as GameObject;
                ground.name = ground.tag + "(" + j + ", " + i + ")";
                ground.transform.parent = GameObject.Find("Ground12X12").transform;
                ground.transform.localPosition = new Vector3(j, 0, -i);
                
            }
        }
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        MakeMap();
    }

    public void LoadMapData(int stageNum)
    {
        dataPath = "MapData/Lv" +  stageNum;
        data = CSVReader.Read(dataPath);
        Debug.Log(data[0]["0"]);
    }

    public void MakeMap()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                int dataSet = (int)data[i][j.ToString()];
                
                if(dataSet != 0)
                    //1, 2 ,3 ,4
                {
                    GameObject mapObj = Instantiate(mapObjectPrefab[dataSet]);
                    switch (mapObj.tag)
                    {
                        case "Wall":
                            mapObj.name = mapObj.tag + "(" + j + ", " + i + ")";
                            mapObj.transform.parent = GameObject.Find("Map12X12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);
                            break;

                        case "Bucket":
                            mapObj.name = mapObj.tag + "(" + j + ", " + i + ")";
                            mapObj.transform.parent = GameObject.Find("Map12X12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);
                            break;

                        case "Ball":
                            mapObj.name = mapObj.tag + "(" + j + ", " + i + ")";
                            mapObj.transform.parent = GameObject.Find("Map12X12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);
                            break;

                        case "Player":
                            mapObj.name = mapObj.tag + "(" + j + ", " + i + ")";
                            mapObj.transform.parent = GameObject.Find("Map12X12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);
                            break;
                        default:
                            break;
                    }

                }
            }
        }
        gameManager.SetBucketAndBalls();
    }

    public void MapDestroy(int lv)
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] buckets = GameObject.FindGameObjectsWithTag("Bucket");
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        for (int i=0; i< walls.Length; i++)
        {
            Destroy(walls[i]);
        }

        for (int i = 0; i < buckets.Length; i++)
        {
            Destroy(buckets[i]);
        }

        for (int i = 0; i < balls.Length; i++)
        {
            Destroy(balls[i]);
        }

        Destroy(player);
        LoadMapData(lv);
        MakeMap();
    }
}