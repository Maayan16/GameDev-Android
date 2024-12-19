using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [HideInInspector] public ItemScriptable mergedItem;
    //public ItemScriptable itemData;

    private int itemID;
    private string itemName;
    private string description;

    public void SetItemData(ItemScriptable itemData)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = itemData.sprite;
        itemID = itemData.itemID;
        itemName = itemData.itemName;
        description = itemData.description;
        this.gameObject.tag = itemData.itemName;
        if (itemData.mergedItemScriptable == null) { mergedItem = null; }
        else { mergedItem = itemData.mergedItemScriptable; }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        List<GameObject> list = new List<GameObject>();
        //step 1. make sure it has the componant item script
        //step 2. compare the itemname to make sure it's the same item.
        if ((collision.GetComponent<Item>() != null) && 
            (collision.GetComponent<Item>().itemName == this.gameObject.GetComponent<Item>().itemName))
        {
            //step 3. make sure this isn't being called 1000 times on all 3 items
            if (!list.Contains(collision.gameObject)) { list.Add(collision.gameObject); }
            //final step - merge
            if (list.Count >= 2)
            {
                ItemHandler.Merge(list[0], list[1], list[2]);
            }
        }
    }
}
