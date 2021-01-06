using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour

{
    private Animator animacion;
    private Transform miTransform;
    private Rigidbody2D rigidBody2D;
    public GameObject dañorecibido;
    private GameObject dañorecibidoxd;
    public GameObject SonidoParry;
    private GameObject Sonidoparry;
    public float dash;
    public float movxp;
    public float movxn;
    public float movyp;
    public float movyn;
    public float tp;
    public float live;
    public float retroseso;
    public bool parry0p;
    public bool contacto;
    public float damages;
    private float buffodaño;
    private bool cooldownparry;
    private bool invencibilidad;
    private bool cooldowndash;
    //public GameObject ataque1;
    //private GameObject ataquexd;
    
    // Start is called before the first frame update
    void Start()
    {
        contacto=false;
        animacion = GetComponent<Animator>();
        miTransform = GetComponent <Transform> ();
        rigidBody2D = GetComponent<Rigidbody2D>();
        live = 100;
        damages = 20;
        cooldownparry = false;
        invencibilidad = false;
        cooldowndash = false;
    }

    void Update()
    {
        if(live > 0)
        {
            animacion.SetBool("Muerte", false);
            //funciones parry
            parry0p = this.transform.GetChild(0).GetComponent<parry0>().deteccion0;
            if(Input.GetMouseButtonDown(1) && parry0p == true && contacto == false && cooldownparry == false)
            {
                invencibilidad = true;
                animacion.SetBool("Invulnerable", true);
                cooldownparry = true;
                animacion.SetBool("parry", true);
                buffodaño= damages*0.2f;
                damages = damages + buffodaño;
                Sonidoparry = Instantiate(SonidoParry);
                Destroy(Sonidoparry,0.6f);
                Invoke("desactivar",0.6f);
                Invoke("Buffo",2f);
            }
            //Dash
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && cooldowndash == false)
                {
                    cooldowndash = true;
                    Invoke("Dash",0.15f);
                }
                if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && cooldowndash == false)
                {
                    cooldowndash = true;
                    Invoke("Dash",0.15f);
                }
                //Lateral superior derecho
                if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && cooldowndash == false)
                {
                    cooldowndash = true;
                    rigidBody2D.AddForce(new Vector2(dash/2, dash/2));
                    Invoke("Dash",0.15f);
                }
                //Lateral inferior derecho
                if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && cooldowndash == false)
                {
                    cooldowndash = true;
                    rigidBody2D.AddForce(new Vector2(dash/2, -dash/2));
                    Invoke("Dash",0.15f);
                }
                //Lateral inferior izquierdo
                if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && cooldowndash == false)
                {
                    cooldowndash = true;
                    rigidBody2D.AddForce(new Vector2(-dash/2, -dash/2));
                    Invoke("Dash",0.15f);
                }
                //Lateral superior izquierdo
                if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && cooldowndash == false)
                {
                    cooldowndash = true;
                    rigidBody2D.AddForce(new Vector2(-dash/2, dash/2));
                    Invoke("Dash",0.15f);
                }
                //Derecha
                if(Input.GetKey(KeyCode.D) && cooldowndash == false)
                {
                    cooldowndash = true;
                    rigidBody2D.AddForce(new Vector2(dash, 0));
                    Invoke("Dash",0.15f);
                }
                //Arriba
                if(Input.GetKey(KeyCode.W) && cooldowndash == false)
                {
                    cooldowndash = true;
                    rigidBody2D.AddForce(new Vector2(0, dash));
                    Invoke("Dash",0.15f);
                }
                //Abajo
                if(Input.GetKey(KeyCode.S) && cooldowndash == false)
                {
                    cooldowndash = true;
                    rigidBody2D.AddForce(new Vector2(0, -dash));
                    Invoke("Dash",0.15f);
                }
                //Izquierda
                if(Input.GetKey(KeyCode.A) && cooldowndash == false)
                {
                    cooldowndash = true;
                    rigidBody2D.AddForce(new Vector2(-dash, 0));
                    Invoke("Dash",0.15f);
                }
            
            }
            //invulnerabilidad
        }
        else
        {
            //muerte
            animacion.SetBool("Muerte", true);
            if(Input.GetKeyDown(KeyCode.X))
            {
                live = live + 100;
            }
        }
        
        
        
    }

    void Invenci()
    {
        //GetComponent<Collider2D>().enabled = true;
        invencibilidad = false;
    }

    void Dash()
    {
        rigidBody2D.velocity = new Vector2(0f, 0f);
        cooldowndash = false;
    }

    void Buffo()
    {
        damages =damages - buffodaño;
        cooldownparry = false;
    }

    /*void DescativarAtaque()
    {
        animacion.SetBool("Ataque", false);
        cooldownataque = false;
    }*/

    void desactivar()
    {
        animacion.SetBool("parry", false);
    }

    void Retrosesot()
        {
            rigidBody2D.velocity = new Vector2(0f, 0f);
        }

    void OnCollisionEnter2D(Collision2D cuerpo)
    {
        if(cuerpo.gameObject.tag == "Daño" && invencibilidad == false)
        {
            invencibilidad = true;
            animacion.SetBool("Invulnerable", true);
            contacto = true;
            live = live-20;
            rigidBody2D.AddForce(new Vector2(-retroseso, 0));
            Invoke("Retrosesot",0.2f);
            dañorecibidoxd = Instantiate(dañorecibido);
            Destroy(dañorecibidoxd,1f);
        }
        if(invencibilidad == true)
        {
           // GetComponent<Collider2D>().enabled = false;
            animacion.SetBool("Invulnerable", false);
            Invoke("Invenci",3);
        }
    }
    void OnCollisionExit2D(Collision2D cuerpo)
    {
        if(cuerpo.gameObject.tag == "Daño")
        {
            contacto = false;
        }
        if(cuerpo.gameObject.tag == "PocionVida")
        {
            if(live < 100)
            {
                live=live+20;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animacion.SetBool("Derecha", false);
        animacion.SetBool("Izquierda", false);
        if(live > 0)
        {
            if(Input.GetKey (KeyCode.W))
            {
                miTransform.Translate(new Vector2(0,movyp));
            }
            if(Input.GetKey (KeyCode.S))
            {
                miTransform.Translate(new Vector2(0,-movyn));
            }
            if(Input.GetKey (KeyCode.D))
            {
                miTransform.Translate(new Vector2(movxp,0));
                animacion.SetBool("Derecha", true);
            }
            if(Input.GetKey (KeyCode.A))
            {
                miTransform.Translate(new Vector2(-movxn,0));
                animacion.SetBool("Izquierda", true);
            }
            if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                animacion.SetBool("Izquierda", false);
                animacion.SetBool("Derecha", false);
            }
        }
        

        
        
    }
}