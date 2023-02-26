using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float veloc;
    public float JumpForce;
    public bool isGrounded;
    private bool isAtk;

    private float timeAttack;
    public float startTimeAttack;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer sprite;

    public Transform pointRight;
    public Transform pointLeft;
    public GameObject energy;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("isJumping", true);
        }

        if (timeAttack <= 0)
        {
            isAtk = false;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                anim.SetBool("isAttacking", true);
                timeAttack = startTimeAttack;
                isAtk = true;
            }

        }
        else
        {
            timeAttack -= Time.deltaTime;
            anim.SetBool("isAttacking", false);
        }

        anim.SetBool("isAttacking", isAtk);

        if (Input.GetKeyDown(KeyCode.F))
        {
            AudioController.current.PlayMusic(AudioController.current.sfx, 0.6f);
            if (sprite.flipX)
            {
                Instantiate(energy, pointLeft.position, Quaternion.identity);
            }
            else
            {
                Instantiate(energy, pointRight.position, Quaternion.identity);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) && !isAtk)
        {
            rig.velocity = new Vector2(veloc, rig.velocity.y);
            anim.SetBool("isWalking", true);
            sprite.flipX = false;
        }
        else
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.A) && !isAtk)
        {
            rig.velocity = new Vector2(-veloc, rig.velocity.y);
            anim.SetBool("isWalking", true);
            sprite.flipX = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("hit");
            Destroy(other.gameObject, 3f);
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            AudioController.current.PlayMusic(AudioController.current.sfx2, 1);
        }

        if (other.gameObject.name == "EnemyWall")
        {
            Debug.Log("colidiu");
            Destroy(gameObject);
        }
    }
}
