using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGame_Ground : MonoBehaviour
{
    public int score = 0;
    public GameObject explosionEffect;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(explosionEffect, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
            score++;
            Destroy(effect, 2f);
            Debug.Log($"Ground HIT!\n SCORE:: {score}");
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            GameObject effect = Instantiate(explosionEffect, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(effect, 2f);
            Destroy(collision.gameObject);
            Debug.Log("ITEM Ground HIT!");
        }
    }
}
