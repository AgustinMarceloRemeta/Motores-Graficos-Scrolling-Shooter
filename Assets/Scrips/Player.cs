using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [SerializeField] GameObject Look, Bullet;
    void Start()
    {
        Cursor.visible = false;
    }

  
    void Update()
    {
        transform.position = new Vector3 (MainCamera.ScreenToWorldPoint(Input.mousePosition).x, MainCamera.ScreenToWorldPoint(Input.mousePosition).y,0);
        if (Input.GetMouseButtonDown(0)) Instantiate(Bullet, Look.transform.position, Quaternion.identity);

    }
}
