using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] Transform player;
    
    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 nuevaPos = player.position;

        nuevaPos.y = transform.position.y;

        transform.position = nuevaPos;
    }
}
