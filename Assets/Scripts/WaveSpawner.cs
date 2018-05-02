using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public float timeBetweenWaves = 3f;
    public float waveCountdown;

    //Float to check WHEN to search for enemies on screen rather than every frame
    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {

        //Creating a spawn based on when the enemies are all gone. 
        if (state == SpawnState.WAITING)
        {
            //Has the player killed all the enemies?
            if (!EnemyIsAlive())
            {
                //Begin new round
                WaveCompleted();

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

           
        }

        else
        {
            //Debug.Log("Counting Down");
            waveCountdown -= Time.deltaTime;
        }

       

    }

    void WaveCompleted()
    {
        Debug.Log("Wave COMPLETE!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if  (nextWave + 1 > waves.Length - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("All Waves Finished. Looping...");
            //I can do other stuff here, such as loading new scenes
            //So ill just replace the nextWave with another function


        }

        else
        {
            nextWave++;
        }

        
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("enemy") == null)
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
        Debug.Log("Spawning");
        Instantiate(_enemy, transform.position, transform.rotation);

    }
}


