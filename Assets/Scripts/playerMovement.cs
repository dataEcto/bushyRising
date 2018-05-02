using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    Rigidbody2D myRigidBody;
    Animator anim;
    public float speed;

    public int meleeDamage;

   

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 10;
        
	}
	
	// Update is called once per frame
	void Update () {

        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");


        bool isWalking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0; 


        myRigidBody.velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            
        {
            myRigidBody.velocity += new Vector2(speed, 0);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity += new Vector2(-speed, 0);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))

        {
            myRigidBody.velocity += new Vector2(0, speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.velocity += new Vector2(0, -speed);
        }

        anim.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            anim.SetFloat("x", input_x);
            anim.SetFloat("y", input_y);

            transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime;
        }


    }
}
