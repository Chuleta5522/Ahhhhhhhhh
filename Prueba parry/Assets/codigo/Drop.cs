using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject drop;
    private float vidaa;
    public float porcentajedrop;
    private float probabilidad;

    void update()
    {
        //vidaa = enemy.GetComponent<Calabaza>().vida;
    }

    private void OnDestroy()
     {
        probabilidad=Random.Range(0,101);
        if(probabilidad <= porcentajedrop)
        {
            Instantiate(drop, transform.position, drop.transform.rotation);
        }
        
     }

}
