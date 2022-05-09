using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] float[] Rotations;
    [SerializeField] float Velocity, Limit, TimeAppearanceShoot;
    public bool Shoot;
    [SerializeField] GameObject BulletEnemy,Animation;
    [SerializeField] Transform Look;
    public int Life;
    GameManager manager;
    [SerializeField] Text LifeText;
    void Start()
    {
        InvokeRepeating("Shooting", 0, TimeAppearanceShoot);
        manager = FindObjectOfType<GameManager>();
        LifeText = GameObject.FindGameObjectWithTag("LifeText").GetComponent<Text>();
    }

    void Update()
    {
        if (gameObject.transform.position.x >= Limit) gameObject.transform.Translate(-Velocity * Time.deltaTime, 0, 0);
        if (gameObject.transform.position.x <= Limit) Shoot = true;
        Dead();
        LifeText.text = "Vida enemigo: " + Life;
    }
    void Shooting()
    {
        if (Shoot)
        {
            int random = Random.Range(0, Rotations.Length);
            float rotation = 0;
            rotation = Rotations[random];
            Instantiate(BulletEnemy, Look.position, Quaternion.Euler(0, 0, rotation));
        }
    }
    void Dead()
    {
        if (Life <= 0)
        {
            Instantiate(Animation, gameObject.transform.position,Quaternion.identity);
            manager.SpawnPlanet();
            Destroy(gameObject);
            Shoot = false;
        }
    }
}
