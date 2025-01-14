using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField]Animator anim; 
    [SerializeField]NavMeshAgent agent;
    private GameObject player;
    [SerializeField] private float vidaEnemigo =100f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("PBRCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            Debug.Log("bala");
            vidaEnemigo -= 50f;
            if (vidaEnemigo <= 0)
            {
                GameManager.Instance.enemigoMuerto += 1;
                Destroy(this.gameObject);
            }



        }
    }
}
