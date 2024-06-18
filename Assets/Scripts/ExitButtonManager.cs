using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonManager : MonoBehaviour
{
    public Button exitButton;
    public Item Key; // Set this to the item required to activate the button

    void Start()
    {
        exitButton.gameObject.SetActive(false); // Initially hide the button
        CheckInventory();
    }

    void Update()
    {
        CheckInventory();
    }

    void CheckInventory()
    {
        if (InventoryManager.Instance != null && InventoryManager.Instance.items.Contains(Key))
        {
            exitButton.gameObject.SetActive(true); // Show the button if the required item is in the inventory
        }
        else
        {
            exitButton.gameObject.SetActive(false); // Hide the button if the required item is not in the inventory
        }
    }

    public void ExitGame()
    {
        Application.Quit(); // Quits the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in the editor
#endif
    }
}
