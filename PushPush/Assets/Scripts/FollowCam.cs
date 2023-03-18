using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;

    [Range(2.0f, 20f)]
    public float distance = 10.0f;

    [Range(0f, 10f)]
    public float height = 2.0f;

    void Start()
    {
        camTr = GetComponent<Transform>();
    }

    void Update()
    {
        camTr.position = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);

        camTr.LookAt(targetTr.position);
    }
}