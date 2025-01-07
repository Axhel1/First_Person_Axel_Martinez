using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    float horizontalMove;
    float verticalMove;
    bool grounded;
    [SerializeField] float gravedad;
    [SerializeField] float jumpVelocidad;
    
    [SerializeField] float targetAngulo;
    [SerializeField] float angulo;
    public float smoothTime = 0.1f;
    float smoothVelocity;
    Vector3 moverPlayer;
    public Vector3 velocityGravedad;

    CharacterController player;

 
    [SerializeField] float playerSpeed;



    CharacterController Control;
     [SerializeField]Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Control = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        MoverYrotar();

        IsGround();

        //Saltar();

        if (moverPlayer.magnitude >= 0.1f)
        {
            anim.SetBool("IsWalk",true);
            //targetAngulo = Mathf.Atan2(moverPlayer.x, moverPlayer.z) * Mathf.Rad2Deg;
            //angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngulo, ref smoothVelocity, smoothTime);

            //transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);

            

            Control.Move(moverPlayer * playerSpeed * Time.deltaTime);
            



        }
        else {
            anim.SetBool("IsWalk", false);
        }

        velocityGravedad.y += gravedad + Time.deltaTime;
        Control.Move(velocityGravedad * Time.deltaTime);


    }

    private void Saltar()
    {
        if(Input.GetButton("Jump")){

            velocityGravedad.y = Mathf.Sqrt(jumpVelocidad * -2 * gravedad);

        }    
    }

    void MoverYrotar() {

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        moverPlayer = transform.right * horizontalMove + transform.forward * verticalMove;
      
    }


    private void IsGround() {

        {
            Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.green);
            if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
            {

                grounded = true;
                Debug.Log("hola");

            }
            else
            {

                grounded = false;
                Debug.Log("caigo");
            }




        }
    }
}
