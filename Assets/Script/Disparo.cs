using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawn;
    public GameObject bala;

    [SerializeField] private float fuerza =1500f;
    [SerializeField] private float delay = 0.5f;
    private float contDelay =0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if(Time.time > contDelay && GameManager.Instance.municionArma > 0 )
            {
                GameManager.Instance.municionArma--;

                GameObject prefBala;

                prefBala = Instantiate(bala, spawn.position, spawn.rotation);

                prefBala.GetComponent<Rigidbody>().AddForce(spawn.forward * fuerza);

                contDelay = Time.time + delay;



            }


        }
    }
}
