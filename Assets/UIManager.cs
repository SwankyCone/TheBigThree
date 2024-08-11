using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI keysFound;

    private void Awake()
    {
        Instance = this;
    }

    public void KeysCollected(int amount)
    {
        keysFound.text = "Keys" + amount.ToString(); 
    }
}
 