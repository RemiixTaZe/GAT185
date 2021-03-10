using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSpawner : MonoBehaviour
{
    public GameObject spawnGameObject;
    public float lifetime = 2.3f;
    public bool useLifeTime = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            GameObject gameOject = Instantiate(spawnGameObject, transform);
            if(useLifeTime) 
            {
                Destroy(gameOject, lifetime);
            }
        }
    }
}
