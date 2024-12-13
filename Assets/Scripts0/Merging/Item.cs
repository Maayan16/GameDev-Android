using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemScriptable mergedItem;
    public ItemScriptable itemData;

    private GameObject itemPrefab;
    private int itemID;
    private string itemName;
    private string description;

    public GameObject CreateItem(ItemScriptable itemData, Vector3 position)
    {
        //i have to use the quaterion or unity gets confused with SCENE MANAGER what the fu-
        GameObject item = Instantiate(itemPrefab, position, Quaternion.identity);
        itemID = itemData.itemID;
        itemName = itemData.itemName;
        description = itemData.description;
        this.gameObject.tag = itemData.itemName;
        if (itemData.mergedItemScriptable == null) { mergedItem = null; }
        else { mergedItem = itemData.mergedItemScriptable; }
        return item;
    }

    //how do i make it not happen more than once?
    private void OnTriggerStay2D(Collider2D collision)
    {
        List<GameObject> list = new List<GameObject>();
        if (collision.gameObject.tag == this.gameObject.tag)
        {
            //to not add same clone twice
            if (!list.Contains(collision.gameObject)) { list.Add(collision.gameObject); }
        }
        if (list.Count >=2)
        {
            MergeManager.Instance.Merge(list[0], list[1], list[2]);
        }
    }
}
