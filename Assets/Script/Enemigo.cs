using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField]private GameObject destino;
    // Start is called before the first frame update
    void Start()
    {
        agent.destination = destino.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
