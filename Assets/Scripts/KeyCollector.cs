using UnityEngine;
using UnityEngine.UI; // Optional if you want to display the key count on the UI

public class KeyCollector : MonoBehaviour
{
    public int totalKeysNeeded = 3; // Number of keys needed to open the door
    private int keysCollected = 0; // Counter for collected keys

    public Text keyCountText; // Optional UI text to display the key count
    public GameObject door; // Reference to the door GameObject

    void Start()
    {
        UpdateKeyCountText();
    }

    void Update()
    {
        // Check for key collection
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f); // Check for nearby colliders within a radius of 2 units
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Key"))
                {
                    keysCollected++;
                    Destroy(hitCollider.gameObject);
                    UpdateKeyCountText();
                }
            }
        }

        // Check for door interaction
        if (Input.GetKeyDown(KeyCode.E) && keysCollected >= totalKeysNeeded)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f); // Check for nearby colliders within a radius of 2 units
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject == door)
                {
                    // Open the door or load the next level
                    Debug.Log("Door opened!");
                    door.SetActive(false); // Deactivate the door (or add your own logic)
                }
            }
        }
    }

    void UpdateKeyCountText()
    {
        if (keyCountText != null)
        {
            keyCountText.text = "Keys: " + keysCollected.ToString();
        }
    }
}