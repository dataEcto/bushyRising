using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

    public int currentHealth = 2;
	// Use this for initialization
	void Start () {

        currentHealth = 2;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void Damage(int damage)
    {
        currentHealth -= damage;
        //gameObject.GetComponent<Animation>().Play("Player_RedFlash");

    }

}
