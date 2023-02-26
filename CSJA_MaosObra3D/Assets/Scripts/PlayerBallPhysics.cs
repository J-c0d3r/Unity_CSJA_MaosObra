using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallPhysics : MonoBehaviour
{
    private bool isGround;
    [SerializeField] private float veloc;
    [SerializeField] private float JumpForce;
    private Rigidbody ballRB;

    void Start()
    {
        ballRB = GetComponentInChildren<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ballRB.AddForce(Vector3.right * -veloc * Time.deltaTime, ForceMode.Acceleration);

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            ballRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 9)
        {
            isGround = true;
        }
    }
}
