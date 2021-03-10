using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum eType
    {
        TimerRepeat,
        TimerOneTime,
        Event
    }

    public GameObject spawnGameObject;
    public float SpawnTimeMin = 2;
    public float SpawnTimeMax = 5;
    public bool IsSpawnChild = true;
    public eType Type = eType.TimerRepeat;

    float spawnTimer;
    int spawnCount = 0;

    void Start()
    {
        spawnTimer = Random.Range(SpawnTimeMin, SpawnTimeMax);
    }

    void Update()
    {

        if(transform.childCount == 0)// && Game.Instance.State == Game.eState.Game)
        {
            spawnTimer -= Time.deltaTime;
        }

        if(spawnTimer <= 0 && (Type == eType.TimerRepeat || (Type == eType.TimerOneTime && spawnCount == 0)))
        {
            spawnTimer = Random.Range(SpawnTimeMin, SpawnTimeMax);
            OnSpawn();
        }
    }

    public void OnSpawn()
    {
        spawnCount++;
        Transform parent = (IsSpawnChild) ? transform : null;
        Instantiate(spawnGameObject, transform.position, transform.rotation, parent);
    }
}
