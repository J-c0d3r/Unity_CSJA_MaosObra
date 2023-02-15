using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public float life;
    public Image bar;

    void Start()
    {

    }


    void Update()
    {
        bar.fillAmount = life / 100;
    }
}
