using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    Rigidbody2D myRigidBody;
    public float speed;

    public int meleeDamage;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        speed = 5;
	}
	
	// Update is called once per frame
	void Update () {

        myRigidBody.velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.velocity += new Vector2(speed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.velocity += new Vector2(-speed, 0);
        }


    }
}
