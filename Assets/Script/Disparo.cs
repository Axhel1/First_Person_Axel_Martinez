using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawn;
    public GameObject bala;

    public float fuerza =1500f;
    public float rango = 0.5f;
    private float tiempoRango =0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            GameObject prefBala;

            prefBala = Instantiate(bala,spawn.position,spawn.rotation);
        }
    }
}
