using UnityEngine;

public enum ItemType
{
    Apple,
    Cheese,
    Bottle_of_Cola,
    Turkey_Leg,
    Battery,
    Tennis_Racket,
    Hammer,
    Trumpet,
    Traffic_Cone,
    Fire_Hydrant,
    Cactus,

}

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemIcon;
    public int quantity;

    public Item(ItemType type, string name, Sprite icon, int qty)
    {
        itemType = type;
        itemName = name;
        itemIcon = icon;
        quantity = qty;
    }
}
