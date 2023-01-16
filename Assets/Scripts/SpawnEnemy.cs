using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemys;

    public Transform xRangeLeft;
    public Transform xRangeRight;
    public Transform yRangeUp;
    public Transform yRangeDown;

 
    public float timeSpawn;
    private float time;

    

    // Start is called before the first frame update
    void Start()
    {
       
        time = timeSpawn;
       
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Spawn();
            time = timeSpawn;
        }

        if(Cronometro.time >= 60)
        {
            timeSpawn = 8;
        }

        if (Cronometro.time >= 80)
        {
            timeSpawn = 5;
        }

        if (Cronometro.time >= 120)
        {
            timeSpawn = 3;
        }

        if (Cronometro.time >= 160)
        {
            timeSpawn = 2;
        }

    }

    void Spawn()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);

        spawnPos = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeUp.position.y, yRangeDown.position.y), 0);

        GameObject enemy = Instantiate(enemys[Random.Range(0,enemys.Length)], spawnPos, gameObject.transform.rotation);
    }
}
