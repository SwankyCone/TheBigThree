using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
        public GameObject[] objectsToCollect;
        public int collectedObjectCount { get; private set; } = 0;

    #region Counts through items
    private bool HasCollectedAllObjects()
        {
            foreach (GameObject obj in objectsToCollect)
            {
                if (obj == null)
                {
                    collectedObjectCount++;
                }
            }
            return collectedObjectCount >= objectsToCollect.Length;
        }
    #endregion

    #region Handles Check
    public void Interact()
        {
            if (HasCollectedAllObjects())
            {
                Debug.Log("Interaction Successful!");
            }
            else
            {
                Debug.Log("Not enough items collected!");
            }
        }

    #endregion
}
