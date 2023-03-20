using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Example_DoTween_Jump : MonoBehaviour
{
    
    void Start()
    {
        DOTween.Init();   
    }

    public void Jump()
    {
        transform.DOLocalJump(transform.position, 5.5f, 1, 1f).OnComplete<Tween>(Grounded);
    }

    void Grounded()
    {
        transform.position = Vector3.zero;
    }
}
