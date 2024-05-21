using UnityEngine;

public class Shelf : MonoBehaviour
{
    // assign the item type for each shelf in the inspector
    public ItemType itemType;


    // This method tells us what type of item is assigned to each shelf
    // It is called on player controller
    public ItemType GetItemType()
    {
        return itemType;
    }

}
