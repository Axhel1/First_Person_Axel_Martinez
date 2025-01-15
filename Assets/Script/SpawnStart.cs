using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStart : MonoBehaviour
    
{
    public Transform Startrespawn;
    [SerializeField] OleadasManager oleadasManager;
    // Start is called before the first frame update


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("TelePort"))
        {
               
               this.gameObject.transform.position = Startrespawn.transform.position;

               oleadasManager.enabled = true;
        }
    }

 
}
