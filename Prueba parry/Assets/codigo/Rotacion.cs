using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    private Vector3 mousePosition, objectPosition;
    private float angulo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    //Posición del mouse en terminos de pixeles
    mousePosition = Input.mousePosition;
    //Para pasar a vector el termino de arriba
    objectPosition = Camera.main.WorldToScreenPoint(transform.position);
    //Calculamos angulo y lo pasamos a Deg
    angulo = Mathf.Atan2((mousePosition.y - objectPosition.y),(mousePosition.x - objectPosition.x)) * Mathf.Rad2Deg;
    //Cambiamos la rotación del objeto
    transform.rotation = Quaternion.Euler(new Vector3(0,0,angulo));

    }
}