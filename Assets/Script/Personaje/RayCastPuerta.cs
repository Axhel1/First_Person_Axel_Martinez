using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPuerta : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;

    //public Texture2D puntero;
    public GameObject textoDetectado;

    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Detectado");
        textoDetectado.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, distancia,mask)) 
        {
            textoDetectado.SetActive(true);
            if (hit.collider.tag == "Puerta") 
            { 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    StartCoroutine(hit.collider.transform.GetComponent<Puerta>().animPuerta());
                    Debug.Log("PUERTA");

                }
            
            
            
            }

        }
        else
        {
            textoDetectado.SetActive(false);

        }
    }
}
