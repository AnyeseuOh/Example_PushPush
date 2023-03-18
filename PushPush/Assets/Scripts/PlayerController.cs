using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    RaycastHit hit2;
    public GameManager gameManager;
    public Camera followCam;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CheckOthers(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CheckOthers(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckOthers(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckOthers(Vector3.back);
        }
    }

    public void CheckOthers(Vector3 dir)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out hit, 1.0f))
        {
            Transform tr = hit.collider.transform;
            switch (hit.collider.tag)
            {
                case "Ball":
                    Debug.Log("BALL!!");
                    if (Physics.Raycast(tr.position, tr.TransformDirection(dir), out hit2, 1.0f))
                    {
                        switch (hit2.collider.tag)
                        {
                            case "Bucket":
                                Debug.Log($"µÎÄ­µÚ :: {hit2.collider.tag}");
                                /*transform.Translate(dir);
                                tr.Translate(dir);
                                Destroy(tr.gameObject);*/
                                Debug.Log("¿Å°Ü³ù´Ù!");
                                break;
                            case "Ball":
                                Debug.Log($"µÎÄ­µÚ :: {hit2.collider.tag}");
                                break;
                            case "Wall":
                                Debug.Log($"µÎÄ­µÚ :: {hit2.collider.tag}");
                                break;
                            default:
                                break;
                        }
                        
                    }
                    else
                    {
                        transform.Translate(dir); //player
                        tr.Translate(dir); //player°¡ ½ð RayÀ» ¸ÂÀº ¹°Ã¼
                        gameManager.CheckBallPosition();
                    }
                    break;
                case "Wall":
                    Debug.Log("WALL!!");
                    break;
                default:
                    break;
            }
        }
        else
        {
            transform.Translate(dir);
        }
    }
}