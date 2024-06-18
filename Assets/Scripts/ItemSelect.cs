using UnityEngine;

public class ItemSelect : MonoBehaviour
{
    public Item Item;


    void Select()
    {
        //InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Debug.Log("Getroffen");
        Select();

    } 
}
