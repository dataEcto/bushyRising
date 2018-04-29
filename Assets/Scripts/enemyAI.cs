using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

    Rigidbody2D myRigidBody;

    public int currentHealth = 2;

    public float speed;
	// Use this for initialization
	void Start () {

        myRigidBody = GetComponent<Rigidbody2D>();
        currentHealth = 2;
        speed = 2;
	}
	
	// Update is called once per frame
	void Update () {

        myRigidBody.velocity = new Vector2(0, 0);
        myRigidBody.velocity += new Vector2(-speed, 0);

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
