using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    //Allows us to change the values of the instances of a class in the Inspector
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }

    public Wave[] waves;
    //Stores the index 
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown = 0;

    //Float to check WHEN to search for enemies on screen rather than every fram
    private float searchCountdown = 1;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        //Creating a spawn based on when the enemies are all gone. 
        if (state == SpawnState.WAITING)
        {
            //Has the player killed all the enemies?
            if (!EnemyIsAlive())
            {
                //Begin new round
                Debug.Log("Wave COMPLETE!");

            }
            else
            {
                return;
            }

        }

        //If its time to start spawing...
        if (waveCountdown <= 0)
        {
            //Check if we are spawning
            //We need a wave to spawn only ONCE 
            if (state != SpawnState.SPAWNING)
            {
                //Start spawning the wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }

            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }


    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
            {
                return false;
            }

        }

        return true;
    }

    //We want to be able to wait for a certain amount of seconds inside of the method
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        //Spawning State
        state = SpawnState.SPAWNING;

        //Look through the array for what enemies we want to spawn
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = SpawnState.WAITING;

        //Return nothing
        yield break;
    }

    //Method to choose what enemy to spawn
    void SpawnEnemy(Transform _enemy)
    {
        //spawn enemy
        Debug.Log("Spawnin");
        Instantiate(_enemy, transform.position, transform.rotation);

    }
}


