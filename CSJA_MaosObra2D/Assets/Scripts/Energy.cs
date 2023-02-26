using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public float speed;
    private bool direction;
    private Player player;
    private SpriteRenderer spritePlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); ;
        spritePlayer = player.GetComponent<SpriteRenderer>();
        direction = spritePlayer.flipX;

        Destroy(gameObject, 3f);
    }


    void Update()
    {
        if (direction)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }


    }
}
