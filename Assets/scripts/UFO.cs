using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed_min;
    public float speed_max;
    public GameObject disparo;
    public float cadencia;
    public float ultdisparo = 0f;
    public GameObject ship;
    public GameObject sistemap3;
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
        if(Time.time > ultdisparo + cadencia)
        {
            
            GameObject nuevoD = Instantiate(disparo, transform.position, transform.rotation);

            nuevoD.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, cadencia));
            ultdisparo = Time.time;
            Destroy(nuevoD, 1.5f);
        }
        
    }
    public void Muerte()
    {
        ship.SetActive(false);
        GameObject temp = Instantiate(sistemap3, transform.position, transform.rotation);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<MovimientoPJ>().Muerte();

        }
    }
}
