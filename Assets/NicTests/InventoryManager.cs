using System.Collections.Generic;
using UnityEngine;


////////////// THIS IS NOT BEING USED YET /////////////////////


public class InventoryManager : MonoBehaviour
{
    private List<Item> inventoryItems = new List<Item>();
    private ShoppingListUI shoppingListUI;
    private List<ItemType> shoppingList;

    private void Start()
    {
        shoppingListUI = FindObjectOfType<ShoppingListUI>();
        if (shoppingListUI == null)
        {
            Debug.LogError("ShoppingListUI not found!");
        }
    }

    public void SetShoppingList(List<ItemType> items)
    {
        Debug.Log("Setting shopping list in InventoryManager");

        shoppingList = items;
        shoppingListUI.SetShoppingList(items);
    }

    public void AddItem(Item item)
    {
        inventoryItems.Add(item);
        shoppingListUI.MarkItemCollected(item.itemType);
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
