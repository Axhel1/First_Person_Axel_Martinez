using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    [SerializeField] float horizontalMove;
    [SerializeField] float verticalMove;

    [SerializeField] float targetAngulo;
    [SerializeField] float angulo;
    public float smoothTime = 0.1f;
    float smoothVelocity;
    Vector3 moverPlayer;

    CharacterController player;

 
    [SerializeField] float playerSpeed;



    CharacterController Control;
    // Start is called before the first frame update
    void Start()
    {
        Control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverYrotar();

        

        if (moverPlayer.magnitude >= 0.1f)
        {

            targetAngulo = Mathf.Atan2(moverPlayer.x, moverPlayer.z) * Mathf.Rad2Deg;
            angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngulo, ref smoothVelocity, smoothTime);
            
            transform.rotation = Quaternion.Euler(0f, angulo, 0f);
           


        }


    }

    void MoverYrotar() {

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        moverPlayer = new Vector3(horizontalMove, 0, verticalMove).normalized;
        //float anguloRotacion= 
        Control.Move(moverPlayer * playerSpeed * Time.deltaTime);
    }
}
