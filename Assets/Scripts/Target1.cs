using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target1 : MonoBehaviour
{
    public int points = 200;
    public Material material;

    private void Start()
    {
        GetComponent<Renderer>().material = material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Game.Instance.AddPoints(points);
            GameObject.Destroy(this.gameObject ,.01f);
            GameObject.Destroy(collision.gameObject,.01f);
        }
    }
}
