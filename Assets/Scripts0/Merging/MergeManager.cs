using UnityEngine;
using UnityEngine.UIElements;

public class MergeManager : MonoBehaviour
{
    public static MergeManager Instance;
    public GameObject ParentPrefab;

    private void Awake()
    {
        //singleton
        if (Instance == null) { Instance = this; }
        else { Destroy(Instance.gameObject); }
    }

    public void Merge(GameObject itemToMerge, GameObject item2ToMerge, GameObject item3ToMerge)
    {
        Item itemScript = itemToMerge.GetComponent<Item>();
        //do something if we reached the last merge of the item
        if (itemScript.mergedItem == null) { return; }

        //how do i choose position?
        Vector3 v3 = Vector3.zero;
        SpanweItem(itemScript.mergedItem, v3);

        Destroy(itemToMerge);
        Destroy(item2ToMerge);
        Destroy(item3ToMerge);
    }


    //a different script should probably handle the spawning

    public GameObject SpanweItem(ItemScriptable itemData, Vector3 position)
    {
        var GO = Instantiate(MergeManager.Instance.ParentPrefab, position, Quaternion.identity);
        GO.GetComponent<Item>().SetItemData(itemData);
        return GO;
    }
}
