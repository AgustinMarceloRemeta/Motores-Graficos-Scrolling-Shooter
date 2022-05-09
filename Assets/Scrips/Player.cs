using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [SerializeField] GameObject Look, Bullet, RespawnMenu, RaySound;
    bool Death = false;
    [SerializeField] Text PowerUpText;
    float PowerTimeUp;

    void Start()
    {
        Cursor.visible = false;
    }

  
    void Update()
    {
        Movement();
        PowerTimeUp -= Time.deltaTime * 2;
        if (PowerTimeUp > 0)
        {
            PowerUpText.text = "Lentitud activa por: " + PowerTimeUp.ToString("0");
            Time.timeScale = 0.5f;
        }
        if (PowerTimeUp < 0 && !Death)
        {
            PowerUpText.text = "";
            Time.timeScale = 1f;
        }
    }

    private void Movement()
    {
        if (!Death)
        {
            transform.position = new Vector3(MainCamera.ScreenToWorldPoint(Input.mousePosition).x, MainCamera.ScreenToWorldPoint(Input.mousePosition).y, 0);
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(Bullet, Look.transform.position, Quaternion.identity);
                Instantiate(RaySound, gameObject.transform);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if( collision.gameObject.CompareTag("Enemy")) Dead();
        if (collision.gameObject.CompareTag("Power up"))
        {
            PowerUp();
            Destroy(collision.gameObject);
        }
    }

    void Dead()
    {
        PowerTimeUp = -1;
        RespawnMenu.SetActive(true);
        Time.timeScale = 0;
        Death = true;
    }
    void PowerUp()
    {
        PowerTimeUp = 10;
    }
}
