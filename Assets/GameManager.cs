using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] Meteorites;
    [SerializeField] float Ymin, Ymax, TimeAppearance;
    [SerializeField] Transform Limit;
    [SerializeField] bool Win;
    void Start()
    {
        InvokeRepeating("SpawnMeteorites", 0, TimeAppearance);
    }


    void Update()
    {

    }

    void SpawnMeteorites()
    {
        if (!Win)
        {
            int i = Random.Range(0, 3);
            float y = Random.Range(Ymin, Ymax);
            Instantiate(Meteorites[i], new Vector3(Limit.position.x, y, 0), Quaternion.identity);
            
        }
    }
}
