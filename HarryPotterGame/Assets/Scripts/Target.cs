using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxHealth = 2;
    [SerializeField] private GameObject hitFx;
    [SerializeField] private GameObject deadFx;
   // [SerializeField] private AudioClip clipToPlay;
    private int currentHealth = 10;

    public int GetHealt
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public int GetMaxHealt
    {
        get
        {
            return maxHealth;
        }

    }

    private void Awake()
    {
        currentHealth = maxHealth;

    }

    private void Die()
    {
        if (deadFx != null)
        {
            Instantiate(deadFx, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
