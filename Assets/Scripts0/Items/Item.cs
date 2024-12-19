using System;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [HideInInspector] public ItemScriptable mergedItem;
    public static event Action<List<GameObject>> itemMerging;
    private List<GameObject> itemsToMerge = new List<GameObject>();
    private int itemID;
    private string itemName;
    private string description;

    public void SetItemData(ItemScriptable itemData)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = itemData.sprite;
        itemID = itemData.itemID;
        itemName = itemData.itemName;
        description = itemData.description;
        if (itemData.mergedItemScriptable == null) { mergedItem = null; }
        else { mergedItem = itemData.mergedItemScriptable; }
    }

    //this is only called on the middle gameobject i guess. if it osnt' it will cause problems, as it will be called multiple times.

    //list is always equal 1
    private void OnTriggerStay2D(Collider2D collision)
    {
        //clear list
        //step 1. make sure it has the componant item script
        //step 2. compare the itemname to make sure it's the same item.
        if ((collision.GetComponent<Item>() != null) && 
            (collision.GetComponent<Item>().itemName == this.gameObject.GetComponent<Item>().itemName))
        {
            //step 3. make sure this isn't being called 1000 times on all 3 items
            if (!itemsToMerge.Contains(collision.gameObject)) { itemsToMerge.Add(collision.gameObject); }
            print(itemsToMerge.Count);

            //final step - merge
            if (itemsToMerge.Count >= 2)
            {
                itemMerging.Invoke(itemsToMerge);
                itemsToMerge.Clear();
            }
        }
    }

    //called every frame as long as its held
    private void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0; //so we can see it 
        this.gameObject.transform.position = mousePos;
    }

    private void OnMouseExit()
    {
        //need "snap into place method, but we need to set the world first
    }
}
