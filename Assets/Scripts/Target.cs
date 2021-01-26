using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Range(0, 5)] public float speed = 5;
    public int points = 100;
    public Material material;

    private void Start()
    {
        GetComponent<Renderer>().material = material;
    }

    private void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
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
