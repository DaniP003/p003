using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUPM : MonoBehaviour
{
    public GameObject powerUP;
    public GameObject powerUP2;
    public Rigidbody2D rb;
    public float speed_min;
    public float speed_max;
    public int powerU;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direccion = direccion * Random.Range(speed_min, speed_max);

        rb.AddForce(direccion);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
