using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    FPSController fPSController;
    [SerializeField] GameObject player;

    

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Teleport");
    }

    IEnumerator Teleport()
    {
      
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = new Vector3(5f, 1.5f, 10f);
        yield return new WaitForSeconds(1f);
        
    }

}
