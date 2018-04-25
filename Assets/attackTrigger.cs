using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour
{

    float dmg = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        //If we collide with the enemy
        if (col.isTrigger != true && col.CompareTag("enemy"))
        {
            //Send a message to cause damage
            col.SendMessageUpwards("Damage", dmg);

        }

    }

}
