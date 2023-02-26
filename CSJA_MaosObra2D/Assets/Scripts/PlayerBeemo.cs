using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeemo : MonoBehaviour
{
    public int life;
    public int veloc;
    public int JumpForce;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rig.velocity = new Vector2(veloc, rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.velocity = new Vector2(rig.velocity.x, JumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "life")
        {
            life++;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "spike")
        {
            life--;
        }
    }
}
