using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUP2 : MonoBehaviour
{
    Animator anim;
    public CircleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<MovimientoPJ>().PowerUp2();
            Gamemanager.instance.powerup2.SetActive(false);
        }
    }

}
