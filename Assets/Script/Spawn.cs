using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private GameObject enemigosPrefap;
    private Transform[] puntosSpawn; 

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemigosPrefap, puntosSpawn[Random.Range(0,puntosSpawn.Length)].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

