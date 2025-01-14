using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Microlight.MicroBar;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemigoMuerto=0;
    [SerializeField] private MicroBar healthBar;
    [SerializeField] private MicroBar staminaBar;
    [SerializeField] public Text municionText;

    [SerializeField]public int municionArma;
    [SerializeField]private float vida = 100f;

    //munucion y curas

    [SerializeField] GameObject cajamunicion;
    public bool cajaMunAct = true;

    public static GameManager Instance { get; private set; }


    void Awake()
    {
        healthBar.Initialize(vida);
        Instance = this;
      
    }

    // Update is called once per frame
    void Update()
    {
        municionText.text = municionArma.ToString();
        Muerte();

        if (cajaMunAct == false)
        {
            StartCoroutine(RepCajaMun());
        }
    }


    public void PerdidaVida(float reduccionVida) {

        vida -= reduccionVida;
        healthBar.UpdateBar (healthBar.CurrentValue-reduccionVida);
    }

    void Muerte()
    {
        if (vida <= 0) {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        }


    }

    IEnumerator RepCajaMun() {

        cajaMunAct = true;
        yield return new WaitForSeconds(5);
        Instantiate(cajamunicion, cajamunicion.transform.position, cajamunicion.transform.rotation);
        
    
    }
}
