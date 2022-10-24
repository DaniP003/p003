using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class MovimientoPJ : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;
    public float rotationspeed = -50f;
    Animator anim;
    public GameObject evolucion;
    public GameObject bala;
    public GameObject boquilla;
    public GameObject boquilla2;
    public GameObject boquilla3;
    public GameObject boquilla4;
    public float cadencia;
    public float firerate;
    public GameObject sistemaP;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    public bool dead;
    public GameObject balote;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false) { 
            float vertical = Input.GetAxis("Vertical");
            if (vertical > 0)
            {
                rb.AddForce(transform.up * speed * Time.deltaTime);

            }
            float horizontal = Input.GetAxis("Horizontal");
            transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, horizontal * rotationspeed * Time.deltaTime);
            if (Input.GetButtonDown("Jump") && Time.time > cadencia)
            {   
                cadencia = Time.time + firerate;
                GameObject temp = Instantiate(bala, boquilla.transform.position, transform.rotation);
                Destroy(temp, 1.5f);
            
            }
            if (Gamemanager.instance.poweruP2 == true)
            {
                if (Input.GetButtonDown("Fire1") && Time.time > cadencia)
                {
                    cadencia = Time.time + firerate;
                    GameObject temp = Instantiate(balote, boquilla.transform.position, transform.rotation);
                    GameObject temp1 = Instantiate(balote, boquilla2.transform.position, transform.rotation);
                    GameObject temp2 = Instantiate(balote, boquilla3.transform.position, transform.rotation);
                    GameObject temp3 = Instantiate(balote, boquilla4.transform.position, transform.rotation);
                    Destroy(temp, 1.5f);

                }
            }
        }
    }
     public void Muerte()
     {
         GameObject temp = Instantiate(sistemaP, transform.position, transform.rotation);
         if (Gamemanager.instance.vidas <= 0)
         {
              Destroy(gameObject); 
              Time.timeScale = 0; 
         }
         else
         {
             StartCoroutine(Respawn());
         }

     }
     IEnumerator Respawn()
     {
         dead = true;
         collider.enabled = false;
         sprite.enabled = false;
         yield return new WaitForSeconds(2);
         collider.enabled = true;
         sprite.enabled = true;
         dead = false;
         Gamemanager.instance.vidas -= 1;

         transform.position = new Vector3(0, 0, 0);
         rb.velocity = new Vector2(0, 0);

     }

    public void PowerUP()
    {
        firerate = 0;
        Gamemanager.instance.puntuacon += 100;
        Gamemanager.instance.vidas += 1;
    }
    public void PowerUp2()
    {
        StartCoroutine(Evolucion());
        Gamemanager.instance.vidas += 1;
        StartCoroutine(evolution());

    }
    IEnumerator evolution()
    {
        anim.SetBool("evolution", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("evolucionado", true);
    }
    IEnumerator Evolucion()
    {
        evolucion.SetActive(true);
        yield return new WaitForSeconds(3);
        evolucion.SetActive(false);
    }
}

