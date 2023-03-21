using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject explosionEffect;
    public DGame_PLMove pl;

    void Start()
    {
        pl = GameObject.Find("DGame_Player").GetComponent<DGame_PLMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pl.hp++;
            GameObject effect = Instantiate(explosionEffect, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(effect, 2f);
            Debug.Log($"HP++!");
        }
    }
}
