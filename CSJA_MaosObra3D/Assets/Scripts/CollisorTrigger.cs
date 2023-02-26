using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisorTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("tocou");
        }
    }


}
