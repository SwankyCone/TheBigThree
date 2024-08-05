using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestroy : MonoBehaviour
{
    public void OnTriggerEnter()
    {
        Destroy(gameObject);
    }

}
