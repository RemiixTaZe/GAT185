using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.1f;
    
    float fireTimer = 0;

    public GameObject bullet;

    void Start()
    {
        
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

    }

    public bool Fire(Vector3 position, Vector3 direction)
    {

        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
            GameObject gameObject = Instantiate(bullet, position, Quaternion.identity);
            gameObject.GetComponent<Bullet>().Fire(direction);
            return true;
        }
        else
        {
            return false;
        }

    }
}
