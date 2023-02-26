using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float veloc;

    public GameObject bullet;
    public GameObject point;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject shoot = Instantiate(bullet);
            shoot.transform.position = point.transform.position;
            shoot.GetComponent<Rigidbody>().AddForce(transform.forward * veloc, ForceMode.Impulse);
        }
    }
}
