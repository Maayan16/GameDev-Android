using UnityEngine;
using System.Collections.Generic;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] GameObject ParentPrefab;
    [HideInInspector] public static bool merging = false;

    private void Awake()
    {
        Item.itemMerging += Merge;
    }

    public void Merge(List<GameObject> itemsToMerge)
    {
        Item itemScript = itemsToMerge[0].GetComponent<Item>();
        //do something if we reached the last merge of the item
        if (itemScript.mergedItem == null) { return; }

        //how do i choose position?
        Vector3 v3 = Vector3.zero;
        SpawnItem(itemScript.mergedItem, v3);

        foreach (GameObject item in itemsToMerge)
        {
            Destroy(item);
            itemsToMerge.RemoveAt(0);
        } 
    }

    public GameObject SpawnItem(ItemScriptable itemData, Vector3 position)
    {
        var GO = Instantiate(ParentPrefab, position, Quaternion.identity);
        GO.GetComponent<Item>().SetItemData(itemData);
        return GO;
    }
}
