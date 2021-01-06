using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion : MonoBehaviour
{
    public GameObject sonido;
    private GameObject sonidoo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "prota")
        {
            sonidoo = Instantiate(sonido);
            Destroy(sonidoo,2);
            Destroy(gameObject,0);
        }
    }
}

