using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI vidas;
    public GameObject gameOver;
    public GameObject evolucuion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo.text = Time.time.ToString("00.00");
        puntuacion.text = Gamemanager.instance.puntuacon.ToString();
        vidas.text = Gamemanager.instance.vidas.ToString();
        if(Gamemanager.instance.vidas <= 0)
        {
            gameOver.SetActive(true);
        }
       
    }

}
