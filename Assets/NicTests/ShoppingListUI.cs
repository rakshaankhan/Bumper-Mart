using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq; // Add this to use LINQ methods

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
        // not used right now
        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }

        ////////////////////////////////////
        /////////////////////////////////////
        // THESE ARE THE ITEMS ON THE LIST FOR LEVEL 1(ADJUSTABLE)
        List<ItemType> level1Items = GetRandomItems(4);
        SetShoppingList(level1Items);
        ////////////////////////////////////
        ///////////////////////////////////////
    }

    // Call this to make the new shopping list!
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

            GameObject listItem = Instantiate(shoppingListItemPrefab, shoppingListPanel);
            listItem.name = item.ToString();

            Image itemIcon = listItem.GetComponentInChildren<Image>();


            itemIcon.sprite = GetItemIcon(item);
            shoppingListItems[item] = listItem;
        }
    }

    // THIS IS NOT USED YET //
    public void MarkItemCollected(ItemType item)
    {
        if (shoppingListItems.ContainsKey(item))
        {
            GameObject listItem = shoppingListItems[item];

        }
    }

    // This gets the correct image attached the their respective itemType
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
