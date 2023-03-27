using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGame_EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject itemPrefab;

    [Range(1f, 3f)]
    public float time;

    [Range(1f, 3f)]
    public float itemTime;

    [Range(1f, 3f)]
    public float repeatRate;

    [Range(1f, 3f)]
    public float itemRepeatRate;

    void Start()
    {
        InvokeRepeating("MakeEnemy", time, repeatRate);
        InvokeRepeating("MakeItem", itemTime, itemRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(Random.Range(-4f, 4f), 16f, 0), transform.rotation);
    }

    public void MakeItem()
    {
        Instantiate(itemPrefab, new Vector3(Random.Range(-4f, 4f), 16f, 0), transform.rotation);
    }
}
