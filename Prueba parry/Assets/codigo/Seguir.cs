using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    GameObject objetivo;
    Vector3 initialPosition;
    public float visionRadius;
    public float speed;


    // Start is called before the first frame update
    void Start()
    { 

        objetivo = GameObject.FindGameObjectWithTag("prota");
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(objetivo != null)
        {

            //Por defecto el objetivo será la posiciòn inicial
            Vector3 target = initialPosition;

            //Regulamos el radio
            float dist = Vector3.Distance(objetivo.transform.position, transform.position);
            if (dist < visionRadius) target = objetivo.transform.position;

            //LLevamos al enemigo a el target
            float fixedSpeed = speed*Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        }


    }

    //Dibujo del radio en pantalla
    void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
