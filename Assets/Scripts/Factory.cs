using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [Range(0,20)] public float lifeTime = 5f;

    [Range(0,5)] public float productionRate = 0.5f;
    float prodcuctionTimer = 0;

    // Update is called once per frame
    void Update()
    {
        prodcuctionTimer += Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    GameObject gameObject = Instantiate(prefab, transform);
        //    Destroy(gameObject, 5);
        //}

        if (prodcuctionTimer > productionRate)
        {
            prodcuctionTimer -= productionRate;
            GameObject gameObject = Instantiate(prefab, transform);
            gameObject.transform.rotation = Quaternion.AngleAxis(90,new Vector3(1,0,0));
            Destroy(gameObject, lifeTime);
        }
    }
}
