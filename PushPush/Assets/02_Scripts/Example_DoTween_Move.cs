using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Example_DoTween_Move : MonoBehaviour
{
    
    void Start()
    {
        DOTween.Init();
    }

    public void MoveRight()
    {
        transform.DOMoveX(8f, 2f);
    }

    public void MoveLeft()
    {
        transform.DOMoveX(-8f, 2f);
    }

    public void RotatLeBox()
    {
        transform.DORotate(new Vector3(0, 360f, 0), 1f, RotateMode.Fast);
    }

    public void RotateRBox()
    {
        transform.DORotate(new Vector3(0, -180f, 0), 1f, RotateMode.Fast);
    }
}
