using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CURA : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int cura = 25;


    public int Cura { get => cura; set => cura = value;}

}