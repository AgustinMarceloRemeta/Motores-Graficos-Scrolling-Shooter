using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] GameObject PowerUp;
    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        transform.Translate(new Vector3(velocity*Time.deltaTime, 0, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy")) Destroy(gameObject);
        if (collision.gameObject.CompareTag("Enemy")) { 
            Destroy(gameObject);
            int r = Random.Range(0, manager.ProbablitysOfPoweUp);
            if (r == 1) Instantiate(PowerUp, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            if(manager.Objetive>0)
            manager.Objetive--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Boss boss = collision.gameObject.GetComponent<Boss>();
            boss.Life--;
            Destroy(gameObject);
        }
    }
}
