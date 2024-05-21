using UnityEngine;

public enum ItemType
{
    Carrot,
    CerealBox,
    Cheese,
    CrackerBox,
    Grape,
    Leek,
    Onion,
    Soda_1,
    Soda_2,
    Watermelon,
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
