using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    
    [SerializeField]NavMeshAgent agent;
    private GameObject player;
    [SerializeField] private float vidaEnemigo =100f;

    [SerializeField] Animator anim;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 20f;
    [SerializeField] LayerMask playerLayer;

    private bool ataque;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();    
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("PBRCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;

        if ( ataque == false)
        {
            
            StartCoroutine(Ataque());

        }

        Debug.Log("ataque" + ataque);


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

        if (other.gameObject.CompareTag("Robot") && ataque == true)
        { 

            GameManager.Instance.PerdidaVida(25f);

        }
    }
    


    IEnumerator Ataque()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, attackRange,playerLayer);

        foreach (var hits in hitColliders)
        {
            ataque = true;
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(2);
            ataque = false;
            

        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
