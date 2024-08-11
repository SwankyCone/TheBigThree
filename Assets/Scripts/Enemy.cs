using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PhotonView photonView;
    public int maxHealth = 100;
    int currentHealth;



    void Start()
    {
        photonView = GetComponent<PhotonView>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        photonView.RPC("RecieveTakeDamage", RpcTarget.Others); 
        currentHealth -= damage;


        if(currentHealth < 0)
        {
            Kill();
        }
    }
   
   
    void Kill()
    {
        photonView.RPC("KillRecieved", RpcTarget.Others); 
        Debug.Log("Dead"); 
        Destroy(gameObject);
        //add animator in after you have made characters models, Leave for now

        GetComponent<Collider>().enabled = false;
        this.enabled=false;
        
    }

    [PunRPC]
    public void RecieveTakeDamage()
    {
        if (currentHealth < 0)
        {
            Kill();
        }
    }

    [PunRPC]
    public void KillRecieved()
    {
        Debug.Log("Dead");
        Destroy(gameObject);
        //add animator in after you have made characters models, Leave for now

        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }
}
