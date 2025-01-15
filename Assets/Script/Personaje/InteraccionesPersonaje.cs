using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class InteraccionesPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Municion"))
        {
            GameManager.Instance.municionArma += other.gameObject.GetComponent<AMMO>().Municion;
            GameManager.Instance.cajaMunAct = false;
            Debug.Log("municion");
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Cura") && GameManager.Instance.vida <100)
        {
            
            GameManager.Instance.AumentoVida(other.gameObject.GetComponent<CURA>().Cura);
            GameManager.Instance.cajaCuraAct = false;
            Debug.Log("vida");
            Destroy(other.gameObject);
        }


        if (other.gameObject.CompareTag("enemigo"))
        {
            GameManager.Instance.PerdidaVida(25f);
            Debug.Log("enemigo");
          
        }


    }


}
