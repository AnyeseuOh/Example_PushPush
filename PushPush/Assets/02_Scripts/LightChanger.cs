using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    
    float duration = 1.0f;
    Color color0 = new Color(156f / 255f, 92f / 255f, 70f / 255f);
    Color color1 = new Color(255f / 255f, 233f / 255f, 225f / 255f);

    [SerializeField]
    Light lt;

    void Start()
    {
        lt = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    void Update()
    {
        // set light color
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }
}
