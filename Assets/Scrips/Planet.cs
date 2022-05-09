using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    [SerializeField] float Velocity, Limit;
    void Start()
    {
        
    }


    void Update()
    {
        if (gameObject.transform.position.x >= Limit) gameObject.transform.Translate(-Velocity * Time.deltaTime, 0, 0);
        if (gameObject.transform.position.x <= Limit) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
