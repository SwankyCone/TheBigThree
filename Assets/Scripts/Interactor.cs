using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// make sure the class inherents the IInteractable to link to current code
interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    public Transform InteractionSource;
    public float InteractRange;

    
    void Update()
    {
        // detects if players is pressing E
         if (Input.GetKeyDown(KeyCode.E))
        {
            // will cast a ray cast from the player and detect if it interacts with a collider
            Ray r = new Ray(InteractionSource.position, InteractionSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) { 
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
