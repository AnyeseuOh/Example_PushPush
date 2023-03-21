using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public DGame_CameraShake dShake;
    public GameObject explosionEffect;

    void Start()
    {
        dShake = Camera.main.GetComponent<DGame_CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dShake.ShakeCamera();
            GameObject effect = Instantiate(explosionEffect, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(effect, 2f);
            Debug.Log($"HIT!");
        }
    }
}
