using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Example_DoTween_Path : MonoBehaviour
{
    public GameObject[] path;
    public Vector3[] tweenPath;
    public Transform target;

    void Start()
    {
        DOTween.Init();
        path = GameObject.FindGameObjectsWithTag("Path");
        for (int i = 0; i < path.Length; i++)
        {
            tweenPath[i] = path[i].transform.position;
        }
    }

    public void TweenPlay()
    {
        transform.DOPath(tweenPath, 10f).SetLookAt(target.position, true);
    }

    public void TweenBack()
    {
        transform.DOPath(tweenPath, 10f).SetLookAt(target.position, true).SetInverted();
    }
}
