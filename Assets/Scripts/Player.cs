using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public Weapon[] weapons;

    void Update()
    {

        if(Input.GetButton("Fire1") && Game.Instance.State == Game.eState.Game)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            weapons[0].Fire(ray.origin, ray.direction);
        }
    }
}
