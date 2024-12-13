using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptable", menuName = "Scriptable Objects/ItemToMerge")]
public class ItemScriptable : ScriptableObject
{
    public int itemID;
    public string itemName;
    public string description;
    public GameObject prefab;
    public ItemScriptable mergedItemScriptable;
}
