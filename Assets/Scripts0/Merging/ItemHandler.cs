using UnityEngine;
using UnityEngine.UIElements;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] static GameObject ParentPrefab;

    public static void Merge(GameObject itemToMerge, GameObject item2ToMerge, GameObject item3ToMerge)
    {
        Item itemScript = itemToMerge.GetComponent<Item>();
        //do something if we reached the last merge of the item
        if (itemScript.mergedItem == null) { return; }

        //how do i choose position?
        Vector3 v3 = Vector3.zero;
        SpawnItem(itemScript.mergedItem, v3);

        Destroy(itemToMerge);
        Destroy(item2ToMerge);
        Destroy(item3ToMerge);
    }

    public static GameObject SpawnItem(ItemScriptable itemData, Vector3 position)
    {
        var GO = Instantiate(ParentPrefab, position, Quaternion.identity);
        GO.GetComponent<Item>().SetItemData(itemData);
        return GO;
    }
}
