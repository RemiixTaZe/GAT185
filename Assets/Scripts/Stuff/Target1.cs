using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target1 : MonoBehaviour
{
    public int points = 200;
    public Material material;
    public AudioSource hitSound;

    private void Start()
    {
        GetComponent<Renderer>().material = material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            hitSound.Play();
            Game.Instance.AddPoints(points);
            GameObject.Destroy(this.gameObject ,.1f);
            GameObject.Destroy(collision.gameObject,.1f);
        }
    }
}
