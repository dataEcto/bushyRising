using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour {

    float time = 1;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);

    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            time = 5;
        }
	}
}
