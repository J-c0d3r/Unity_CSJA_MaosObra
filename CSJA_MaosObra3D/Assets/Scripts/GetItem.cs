using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    public int points;
    public Text pointTxt;

    void Update()
    {
        pointTxt.text = "x " + points.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Coin")
        {
            points += 10;
            Destroy(other.gameObject);
        }
    }
}
