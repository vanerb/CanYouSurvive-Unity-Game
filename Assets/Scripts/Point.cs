using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{

    public EnemyHealth enemyHeath;

    public float points;

    public Text textPunt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHeath.currentHealth <= 0)
        {
            points = Random.Range(100, 900);
        }

        textPunt.text = "" + points;
    }
}
