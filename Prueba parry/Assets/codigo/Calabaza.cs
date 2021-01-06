using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calabaza : MonoBehaviour
{
    private Animator animacion;
    private Transform miTransform;
    private Rigidbody2D rigidBody2D;
    public float vida;
    private float daño;
    public GameObject prota;
    public GameObject dañocalabaza;
    private GameObject dañosonido;
    public float potencia;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        miTransform = GetComponent <Transform> ();
        rigidBody2D = GetComponent<Rigidbody2D>();
        vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
        daño = prota.GetComponent<Controller>().damages;
        if(vida <= 0)
        {
            rigidBody2D.velocity = new Vector2(0f, 0f);
            animacion.SetBool("Muertaa", true);
            Destroy(gameObject,2);
        }
    }

    void FixedUpdate()
    {
        //Movimiento
        if(vida > 0)
        {
            rigidBody2D.AddForce(new Vector2(Random.Range(-potencia,potencia),Random.Range(-potencia,potencia)));
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //ataque no rinde, tag distinta para cada arma
        if(vida > 0)
        {
            if(collider.gameObject.tag == "Ataque")
            {
                vida=vida-daño;
                dañosonido = Instantiate(dañocalabaza);
                Destroy(dañosonido,1f);
            }
        }
        
    }
}
