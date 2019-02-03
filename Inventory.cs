using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{

    public Object[] items = new Object[numItemSlots];
    public const int numItemSlots = 4;
    public void AddItem(Object itemToAdd)
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
    public void RemoveItem(Object itemToRemove)
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