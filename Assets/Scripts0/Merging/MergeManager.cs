using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public static MergeManager Instance;

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
        
        Destroy(itemToMerge);
        Destroy(item2ToMerge);
        Destroy(item3ToMerge);
        GameObject newItem = itemScript.CreateItem(itemScript.mergedItem, itemToMerge.transform.position);


    }
}
