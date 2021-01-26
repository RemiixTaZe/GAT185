using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnGameObject;
    public float SpawnTimeMin = 2;
    public float SpawnTimeMax = 5;

    float childCount = 0;
    float spawnTimer;

    void Start()
    {
        spawnTimer = Random.Range(SpawnTimeMin, SpawnTimeMax);
    }

    void Update()
    {

        if(childCount == 0 && Game.Instance.State == Game.eState.Game)
        {
            spawnTimer -= Time.deltaTime;
        }
        if(spawnTimer <= 0)
        {
            spawnTimer = Random.Range(SpawnTimeMin, SpawnTimeMax);
            Instantiate(spawnGameObject, transform.position, transform.rotation, transform);
        }
    }
}
