using UnityEngine;

public class Shelf : MonoBehaviour
{
    public ItemType itemType;
    public Sprite itemIcon;



    // This method will be called by the PlayerController on collision
    public ItemType GetItemType()
    {
        return itemType;
    }

}
