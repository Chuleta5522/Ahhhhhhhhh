using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vida : MonoBehaviour
{
    public GameObject personaje;
    private float vidaa;
    private string texto;
    public GameObject musica;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(musica);
    }

    // Update is called once per frame
    void Update()
    {
        vidaa = personaje.GetComponent<Controller>().live;
        texto = vidaa.ToString();
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Vida: "+texto+"/100";
    }
}
