using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateSpawnObjects : MonoBehaviour
{
    public PlayerHealth PlayerHealth;

    public SpawnObjects spawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.currentHealth >= 100)
        {
            spawn.enabled = false;
        }
        else
        {
            spawn.enabled = true;
        }
    }
}
