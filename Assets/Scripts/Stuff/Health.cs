using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float healthMax;
    public float decay;
    public Slider slider;
    public GameObject destroySpawnObject;
    public UnityEvent deathEvent;
    public bool destroyOnDeath = false;

    public float health { get; set; }
    public bool isDead { get; set; } = false;

    void Start()
    {
        health = healthMax;
    }

    void Update()
    {
        AddHeath(Time.deltaTime * -decay);
        Debug.Log("Decay");
        if(slider != null)
        {
            slider.value = health / healthMax;
        }

        if(health <= 0 != isDead)
        {
            isDead = true;
            deathEvent?.Invoke();
            if (destroySpawnObject != null)
            {
                Instantiate(destroySpawnObject, transform.position, transform.rotation);
            }
            if (destroyOnDeath) GameObject.Destroy(gameObject);
        }
    }

    public void AddHeath(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, healthMax);
    }
}
