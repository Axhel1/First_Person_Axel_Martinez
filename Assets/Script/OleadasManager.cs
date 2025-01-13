using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OleadasManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawns;
    [SerializeField] private GameObject enemigo;
    [SerializeField] private int IncrementoEnemigos;
    private int wave;
    private bool spawning;
    private int enemigosInstaciado;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
       IncrementoEnemigos = 2;
       wave = 1;
       spawning = false;
       enemigosInstaciado = 0;
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if(spawning == false && enemigosInstaciado == gameManager.enemigoMuerto)
        {


            StartCoroutine(SpawnOleadas(IncrementoEnemigos));

        }
    }

    IEnumerator SpawnOleadas(int contOleadas )
    {
        
        spawning = true;
       //Canvas
       yield return new WaitForSeconds(4);

        for (int i = 0; i < contOleadas; i++) 
        {
            Debug.Log("corrutina");
            SpawnEnemigo(wave);
            yield return new WaitForSeconds(2);
        }
      
        wave += 1;
        IncrementoEnemigos += 2;
        spawning = false;

        yield break;
    
    }

    void SpawnEnemigo(int oleada)
    {
        int randomSpawn = Random.Range(0, 4);
        Instantiate(enemigo, spawns[randomSpawn].transform.position, spawns[randomSpawn].transform.rotation);
        enemigosInstaciado += 1;


    }
}
