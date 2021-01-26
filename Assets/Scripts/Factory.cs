using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [Range(0,20)] public float lifeTime = 5f;

    [Range(0,5)] public float productionRate = 0.5f;
    float prodcuctionTimer = 0;

    void Update()
    {
        if (Game.Instance.State == Game.eState.Game)
        {
            prodcuctionTimer += Time.deltaTime;
        }

        if (prodcuctionTimer > productionRate)
        {
            prodcuctionTimer -= productionRate;
            GameObject gameObject = Instantiate(prefab, transform);
            gameObject.transform.rotation = Quaternion.AngleAxis(90,new Vector3(1,0,0));
            Destroy(gameObject, lifeTime);
        }
    }
}
