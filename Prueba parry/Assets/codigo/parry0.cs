using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parry0 : MonoBehaviour
{
    public bool deteccion0 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Daño")
        {
            deteccion0 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        deteccion0 = false;
    }
}
