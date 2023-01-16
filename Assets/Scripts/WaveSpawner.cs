using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING};
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBeetweenWaves = 5f;
    public float waveCountDown;

    private float searchCountDown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public Transform xRangeLeft;
    public Transform xRangeRight;
    public Transform yRangeUp;
    public Transform yRangeDown;


    private void Start()
    {
        waveCountDown = timeBeetweenWaves;
    }

    private void Update()
    {

        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountDown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnMave(waves[nextWave]));
            }
        }
        else{
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountDown = timeBeetweenWaves;
        if (nextWave + 1 > waves.Length -1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }
       

    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;

        if(searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
        
    }


    IEnumerator SpawnMave(Wave _wave)
    {
        Debug.Log("SPAWNING WAVE");
        state = SpawnState.SPAWNING;

        for (int i = 0; i<_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform[] _enemy)
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);

        spawnPos = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeUp.position.y, yRangeDown.position.y), 0);
        Instantiate(_enemy[Random.Range(0, _enemy.Length)], spawnPos, gameObject.transform.rotation);
        
    }


}




