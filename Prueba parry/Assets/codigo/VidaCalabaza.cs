using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VidaCalabaza : MonoBehaviour
{
    public GameObject personaje;
    private float vidaa;
    private string texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidaa = personaje.GetComponent<Calabaza>().vida;
        texto = vidaa.ToString();
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Vida: "+texto+"/100";
    }
}
