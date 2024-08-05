using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnterTeleport : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Instantiate(other.gameObject);
        quaternion quaternion = Quaternion.identity;
        if (other.GetComponent<Rigidbody>() != null )
            Destroy(other.gameObject);
    }
}
