using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OleadasManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawns;
    [SerializeField] private GameObject enemigo;
    [SerializeField] private int IncrementoEnemigos;
    [SerializeField] private Text waveText;
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
        waveText.text = wave.ToString();
        if (spawning == false && enemigosInstaciado == gameManager.enemigoMuerto)
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
            SpawnEnemigo();
            yield return new WaitForSeconds(2);
        }
      
        wave += 1;
        IncrementoEnemigos += 2;
        spawning = false;

        yield break;
    
    }

    void SpawnEnemigo()
    {
        int randomSpawn = Random.Range(0, 4);
        Instantiate(enemigo, spawns[randomSpawn].transform.position, spawns[randomSpawn].transform.rotation);
        enemigosInstaciado += 1;


    }
}
