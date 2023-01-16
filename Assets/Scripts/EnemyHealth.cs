using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public SpriteRenderer enemyRender;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        audioSource.Play();
        currentHealth -= damage;
        enemyRender.color = Color.grey;
        Invoke("setNormal", 0.3f);
        Debug.Log("La vida es de: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();

        }
    }

    void setNormal()
    {
        enemyRender.color = Color.white;
    }

    void Die()
    {
        Debug.Log("Muerto");
    }
}
