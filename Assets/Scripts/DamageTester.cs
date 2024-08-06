using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo);
            {
                if (hitInfo.collider.gameObject);
                {
                    playerAtm.DealDamage(enemyAtm.gameObject);
                }

                

            }
            

        }
   
    }
}
