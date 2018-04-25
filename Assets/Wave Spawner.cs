using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState {SPAWNING, WAITING, COUNTING};

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

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
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

    //We want to be able to wait for a certain amount of seconds inside of the method
    IEnumerator SpawnWave(Wave _wave)
    {
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
    }
}

