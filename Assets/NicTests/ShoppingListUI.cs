using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShoppingListUI : MonoBehaviour
{
    public Transform shoppingListPanel;
    public GameObject shoppingListItemPrefab;
    private InventoryManager inventoryManager;

    // Sprites for each item type 
    public Sprite appleSprite;
    public Sprite cheeseSprite;
    public Sprite Bottle_of_Cola;
    public Sprite Turkey_Leg;
    public Sprite batterySprite;
    public Sprite Tennis_Racket;
    public Sprite hammerSprite;
    public Sprite Trumpet;
    public Sprite Traffic_Cone;
    public Sprite Fire_Hydrant;
    public Sprite Cactus;
    public Sprite defaultSprite;


    private Dictionary<ItemType, GameObject> shoppingListItems = new Dictionary<ItemType, GameObject>();

    private void Start()
    {

        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManager>();

            if (inventoryManager == null)
            {
                Debug.LogError("InventoryManager not found!");
                return;
            }
        }


        /////// THESE ARE TEST ITEMS ON THE LIST //////
        List<ItemType> level1Items = new List<ItemType> { ItemType.Apple, ItemType.Cheese, ItemType.Battery, ItemType.Hammer };

        /////// THESE ARE THE RANDOM 4 ITEMS ON THE LIST ///////
        //List<ItemType> level1Items = GetRandomItems(4);

        SetShoppingList(level1Items); // Call this to instantiate the new shopping list
    }


    public void SetShoppingList(List<ItemType> items)
    {
        // Clear existing prefab to allow new set of shopping list for each level
        foreach (Transform child in shoppingListPanel)
        {
            Destroy(child.gameObject);
        }
        shoppingListItems.Clear();



        // Instantiate a list of new items inside the shopping list panel with their corresponding images
        foreach (ItemType item in items)
        {

            GameObject listItem = Instantiate(shoppingListItemPrefab, shoppingListPanel); // creating each object for the shopping list
            listItem.name = (item.ToString() + " Icon"); // naming each item

            Image itemIcon = listItem.GetComponentInChildren<Image>(); 

            itemIcon.sprite = GetItemIcon(item); // adding the correct icon to each item
            shoppingListItems[item] = listItem;

            Debug.Log("Added item to shopping list: " + item + " with GameObject name: " + listItem.name);
        }
    }



    //////////////////// USED TO UPDATE THE SHOPPING LIST UI //////////////////////
    public void MarkItemCollected(ItemType item) // "item" here is what item/shelf that the player bumped into
    {
        if (shoppingListItems.ContainsKey(item)) 
        {
            GameObject listItem = shoppingListItems[item]; 

            if (listItem != null)
            {
                if (inventoryManager.HasItem(item)) // checks if item is in inventory or not
                {
                    shoppingListItems.Remove(item);
                    listItem.SetActive(false); // CURRENTLY DISABLING THE GAME OBJECT TO SHOW THAT PLAYER GOT AN ITEM OFF THE LIST
                }
            }
            else
            {
                Debug.LogWarning("List item GameObject is null for item: " + item.ToString());
            }
        }
        else
        {
            Debug.LogWarning("Item not found in shopping list: " + item.ToString());
        }
    }



    // This gets the correct image attached the their respective itemType
    // It is used in SetShoppingList, when the list is instantiated for each level
    private Sprite GetItemIcon(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Apple:
                return appleSprite;
            case ItemType.Cheese:
                return cheeseSprite;
            case ItemType.Bottle_of_Cola:
                return Bottle_of_Cola;
            case ItemType.Turkey_Leg:
                return Turkey_Leg;
            case ItemType.Battery:
                return batterySprite;
            case ItemType.Tennis_Racket:
                return Tennis_Racket;
            case ItemType.Hammer:
                return hammerSprite;
            case ItemType.Trumpet:
                return Trumpet;
            case ItemType.Traffic_Cone:
                return Traffic_Cone;
            case ItemType.Fire_Hydrant:
                return Fire_Hydrant;
            case ItemType.Cactus:
                return Cactus;
            default:
                return defaultSprite; // Fallback sprite if none is found
        }
    }



    /////////// This is the mehod to get a random item from our Item enum list ////////////
    private List<ItemType> GetRandomItems(int count)
    {
        System.Array itemTypeValues = System.Enum.GetValues(typeof(ItemType));
        List<ItemType> randomItems = new List<ItemType>();

        while (randomItems.Count < count)
        {
            ItemType randomItem = (ItemType)itemTypeValues.GetValue(Random.Range(0, itemTypeValues.Length));
            if (!randomItems.Contains(randomItem))
            {
                randomItems.Add(randomItem);
            }
        }
        return randomItems;
    }
}
