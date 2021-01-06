using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brazo : MonoBehaviour
{
    public GameObject ataque1;
    private GameObject ataquexd;
    public GameObject prota;
    private bool cooldownataque;
    private float vida;
    // Start is called before the first frame update
    void Start()
    {
        cooldownataque = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        vida = prota.GetComponent<Controller>().live;
        if(vida > 0)
        {
            if(Input.GetMouseButtonDown(0) && cooldownataque == false)
            {
                cooldownataque = true;
                ataquexd = Instantiate(ataque1,new Vector2(gameObject.transform.position.x,gameObject.transform.position.y), transform.rotation);
                Invoke("culdawn",1);
            }
        }
        
    }
    void culdawn()
    {
        cooldownataque = false;
    }
}
