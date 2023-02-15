using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnerTempo = 2f;

    public List<GameObject> walls = new List<GameObject>();

    void Start()
    {

    }

    float countTime;
    void Update()
    {
        countTime += Time.deltaTime;

        if (countTime >= SpawnerTempo)
        {
            Instantiate(walls[Random.Range(0, walls.Count)], transform.position, transform.rotation);
            countTime = 0;
        }

    }
}
