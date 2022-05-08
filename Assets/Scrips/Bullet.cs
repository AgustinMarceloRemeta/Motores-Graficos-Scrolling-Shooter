using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float velocity;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(new Vector3(velocity*Time.deltaTime, 0, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy")) Destroy(gameObject);
    }
}
