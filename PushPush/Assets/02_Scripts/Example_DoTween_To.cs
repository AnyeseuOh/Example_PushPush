using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Example_DoTween_To : MonoBehaviour
{
    public Slider hpBar;

    [Range(0,1)]
    public float myFloat;

    [Range(0, 1)]
    public float divValue = 0.1f;

    void Start()
    {
        hpBar = GetComponent<Slider>();
        DOTween.Init();
    }

    void Update()
    {
        //hpBar.value = myFloat;
        //프레임마다 확인
    }

    public void MinusHpBar(float t)
    {
        if (hpBar.value > 0)
        {
            float dest = hpBar.value - divValue;
            DOTween.To(() => hpBar.value, x => hpBar.value = x, dest, t);
            //람다식(익명함수) 호출, 매개변수는 myfloat이라고 알려주기, 목표값=0, duration
        }
        
    }

    public void plusHpBar(float t)
    {
        if (hpBar.value < 1)
        {
            float dest = hpBar.value + divValue;
            DOTween.To(() => hpBar.value, x => hpBar.value = x, dest, t);
            //람다식(익명함수) 호출, 매개변수는 myfloat이라고 알려주기, 목표값=0, duration
        }
    }
}
