using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHpBar : MonoBehaviour
{
    public Transform target;
    public RectTransform canvas;
    public RectTransform hpBar;
    public Camera mainCam;
    public GameObject hpBarPrefab;
    public GameObject hpObj;
    public int maxHp;

    void Start()
    {
        hpObj = Instantiate(hpBarPrefab);
        target = gameObject.transform;
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        hpObj.transform.SetParent(canvas);
        hpBar = hpObj.GetComponent<RectTransform>();
        hpBar.localPosition = Vector3.zero;
        hpBar.localScale = Vector3.one;
        hpBar.localRotation = Quaternion.Euler(0, 0, 0);
        mainCam = Camera.main;
        maxHp = transform.GetComponent<DGame_PLMove>().hp;
    }


    void Update()
    {
        Vector3 curPos = target.GetChild(1).transform.position;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(curPos);
        Vector2 canvasPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, screenPoint, mainCam, out canvasPos);
        hpBar.localPosition = canvasPos;

        if (hpBar != null)
        {
            hpBar.localPosition = canvasPos;
            if (maxHp < transform.GetComponent<DGame_PLMove>().hp)
            {
                maxHp = transform.GetComponent<DGame_PLMove>().hp;
            }
            hpBar.GetComponent<Slider>().value = (float)transform.GetComponent<DGame_PLMove>().hp / maxHp;
        }

    }

    public void DestroyHpBar()
    {
        Destroy(hpBar.gameObject);
    }
}