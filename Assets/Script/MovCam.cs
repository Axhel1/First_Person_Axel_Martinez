using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovCam : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float sensibilidad = 50f;
    private float rotacionV = 0f;
    [SerializeField] private Transform player;
    void Start()
    {
        //Bloquear cursor solo para pantalla de juego 
        //Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        rotacionV -= mouseY;
        rotacionV = Mathf.Clamp(rotacionV,-90f,90f);

        transform.localRotation = Quaternion.Euler(rotacionV,0,0);

        player.Rotate(Vector3.up * mouseX);
    }
}
