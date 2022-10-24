using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject ship;
    public int vidas;
    public int puntuacon;
    public int random;
    public GameObject powerup;
    public GameObject powerup2;
    public GameObject evolucion;
    public bool poweruP2 = false;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (puntuacon == 1000)
        {
            ship.SetActive(true);
            StartCoroutine(Respawn());

        }

        if(puntuacon == 500)
        {
            powerup.SetActive(true);
         
        }
        if(puntuacon == 1500)
        {
            poweruP2 = true;
            powerup2.SetActive(true);

        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(60);
        ship.SetActive(true);
    }
}