using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{



    public IEnumerator animPuerta()
    {
        transform.Translate(new Vector3(0, 250, 0) * 1 * Time.deltaTime);
        yield return new WaitForSeconds(8);
        transform.Translate(new Vector3(0, -250, 0) * 1 * Time.deltaTime);
        yield break;

    }
    

}
