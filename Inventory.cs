using UnityEngine;
using UnityEngine.UI;
public class Inventory 
{

    public const int numItemSlots = 4;
    public GameObject[] items = new GameObject[numItemSlots];
    public void AddItem(GameObject itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                return;
            }
        }
    }
    public void RemoveItem(GameObject itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
         
                return;
            }
        }
    }
}