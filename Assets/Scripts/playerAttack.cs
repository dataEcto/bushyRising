using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

    public bool attacking = false;
    private float attackTimer;
    private float attackCoolDown = 0.3f;

    public BoxCollider2D attackTrigger;

    private Animator anim;
    
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        //First we are disabling the trigger box
        //If we don't, it will always be active
        attackTrigger.enabled = false;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown("space") && !attacking)
        {
            attacking = true;
            //Set the timer on cool down
            attackTimer = attackCoolDown;

            attackTrigger.enabled = true;
           
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;

            }

            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }

        
        }

        anim.SetBool("isAttacking", attacking);

    }
}
