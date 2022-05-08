using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] GameObject limit2;
    [SerializeField] float VelocityBack;
    void Start()
    {
        
    }


    void Update()
    {
        gameObject.transform.Translate(-VelocityBack * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit")) gameObject.transform.position = limit2.transform.position;

    }
}
