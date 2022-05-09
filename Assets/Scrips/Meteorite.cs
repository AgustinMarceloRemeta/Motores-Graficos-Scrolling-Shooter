using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] float Velocity;
    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.Translate(-Velocity*Time.deltaTime, 0,0);
    }

}
