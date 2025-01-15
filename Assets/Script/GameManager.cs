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
    [SerializeField]public float vida = 100f;

    //munucion y curas

    [SerializeField] GameObject cajamunicion;
    [SerializeField] GameObject cajaCura;
    public bool cajaMunAct = true;
    public bool cajaCuraAct = true;

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

        if (cajaCuraAct == false)
        {

            StartCoroutine(RepCajaCura());
        }
    }


    public void PerdidaVida(float reduccionVida) {

        vida -= reduccionVida;
        healthBar.UpdateBar (healthBar.CurrentValue-reduccionVida);
    }

    public void AumentoVida(float sumaVida)
    {

        vida += sumaVida;
        healthBar.UpdateBar(healthBar.CurrentValue + sumaVida);
    }

    void Muerte()
    {
        if (vida <= 0) {

            SceneManager.LoadScene(1);

        }


    }



    IEnumerator RepCajaMun() {

        cajaMunAct = true;
        yield return new WaitForSeconds(5);
        Instantiate(cajamunicion, cajamunicion.transform.position, cajamunicion.transform.rotation);
        
    
    }

    IEnumerator RepCajaCura()
    {
        cajaCuraAct = true;
        yield return new WaitForSeconds(5);
        Instantiate(cajaCura, cajaCura.transform.position, cajaCura.transform.rotation);
    }
}
