using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;



    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if(currentHealth < 0)
        {
            Kill();
        }
    }
   
    void Kill()
    {
        Debug.Log("hiii");

        //add animator in after you have made characters models, Leave for now

        GetComponent<Collider>().enabled = false;
        this.enabled=false;
        
    }
}
