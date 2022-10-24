using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class asteroideC : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    public AsteroidM manager;
    public int i;
    public GameObject sistemaP2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direccion = direccion * Random.Range(speed_min, speed_max);
        rb.AddForce(direccion);
        manager.Asteroides += 1;
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void Muerte()
    {
        if (transform.localScale.x > 0.5f)
        {
            GameObject temp1 = Instantiate(manager.Asteroid, transform.position, transform.rotation);
            temp1.GetComponent<asteroideC>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.5f;
            GameObject temp2 = Instantiate(manager.Asteroid, transform.position, transform.rotation);
            temp2.GetComponent<asteroideC>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.5f;
        }
        Gamemanager.instance.puntuacon += 100;
        Destroy(gameObject);
        manager.Asteroides -= 1;
        GameObject temp = Instantiate(sistemaP2, transform.position, transform.rotation);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<MovimientoPJ>().Muerte();

        }
    }
    
}
