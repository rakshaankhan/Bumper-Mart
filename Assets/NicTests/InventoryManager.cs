using System.Collections.Generic;
using UnityEngine;




public class InventoryManager : MonoBehaviour
{
    private List<Item> inventoryItems = new List<Item>();
    private ShoppingListUI shoppingListUI;
    private List<ItemType> shoppingList;

    private void Start()
    {
        shoppingListUI = FindObjectOfType<ShoppingListUI>();

    }

    public void SetShoppingList(List<ItemType> items)
    {
        shoppingList = items;
        shoppingListUI.SetShoppingList(items);
    }

    public void AddItem(Item item)
    {
        inventoryItems.Add(item);
        Debug.Log("Adding item from UI: " + item.itemName);

        Debug.Log("Items collected: " + inventoryItems.Count);

    }

    public void MarkItemCollected(ItemType itemType)
    {
        shoppingListUI.MarkItemCollected(itemType);
    }

    public void ClearInventory()
    {
        inventoryItems.Clear();
        shoppingListUI.SetShoppingList(shoppingList);
    }

    public List<Item> GetInventoryItems()
    {
        return inventoryItems;
    }
}
