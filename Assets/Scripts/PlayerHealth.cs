using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public SpriteRenderer spritePlayer;

    public GameObject panelDeath;
    public AudioSource audio;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > 100)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        audio.Play();
        currentHealth -= damage;
        Debug.Log("La vida del Player: " + currentHealth);
        spritePlayer.color = Color.grey;
        Invoke("setNormal", 0.3f);
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    public void BuffLife(int life)
    {
       
       currentHealth += life;
       healthBar.SetHealth(currentHealth);

    }

    void setNormal()
    {
        spritePlayer.color = Color.white;
    }

    void Die()
    {
        Debug.Log("Muerto");
        panelDeath.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
}
