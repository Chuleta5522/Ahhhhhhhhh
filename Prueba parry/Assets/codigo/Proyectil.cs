using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedShoot;

    private Vector2 mousePosition;
    private Vector3 pastPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speedShoot;
        pastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(pastPosition != transform.position)
       {
           transform.right = transform.position - pastPosition;
           pastPosition = transform.position;

       }

       Destroy(gameObject,0.1f);

    }
}