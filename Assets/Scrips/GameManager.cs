using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] Meteorites;
    [SerializeField] GameObject Boss, Planet;
    [SerializeField] float Ymin, Ymax, TimeAppearance;
    public int ProbablitysOfPoweUp;
    [SerializeField] Transform Limit;
    public int Objetive;
    [SerializeField] Text ScoreText;
     bool Win= false , SpawnnedBoss= false;
    void Start()
    {
        InvokeRepeating("SpawnMeteorites", 0, TimeAppearance);
    }


    void Update()
    {
       if(Objetive>0) ScoreText.text = "Asteroides restantes: " + Objetive;
        if (Objetive == 0)
        {
            Win = true;
            ScoreText.text = "";
        }
        if (Win) SpawnBoss();
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

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    void SpawnBoss()
    {
        if (!SpawnnedBoss)
        {
            Instantiate(Boss, new Vector3 (Limit.position.x,Limit.position.y,0), Quaternion.identity);
            SpawnnedBoss = true;
        }
    }
    public void SpawnPlanet()
    {
       Instantiate(Planet, new Vector3(Limit.position.x, Limit.position.y, 0), Quaternion.identity);
    }
}
