using UnityEngine;

[CreateAssetMenu(fileName = "PopupScriptable", menuName = "Scriptable Objects/PopupScriptable")]
public class PopupScriptable : ScriptableObject
{
    public string title;
    [TextArea(3,10)] public string description;
}
