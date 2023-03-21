using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DGame_PLMove : MonoBehaviour
{
    public int hp = 5;
    public DOTween doTween;

    void Start()
    {
        hp = 5;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftMove();
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightMove();
        }
    }

    public void LeftMove()
    {
        if (transform.position.x > -4f)
        {
            //transform.Translate(-0.5f, 0, 0);
            transform.DOMoveX(transform.position.x - 0.5f, 0.2f);
        }
        
    }

    public void RightMove()
    {
        if (transform.position.x < 4f)
        {
            //transform.Translate(0.5f, 0, 0);
            transform.DOMoveX(transform.position.x + 0.5f, 0.2f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp--;
            Debug.Log($"Current HP ::: {hp}");
        }
    }
}
