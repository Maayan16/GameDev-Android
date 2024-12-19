using UnityEngine;

public class TesterMerge : MonoBehaviour
{
    [SerializeField] private ItemScriptable IS1;
    [SerializeField] private ItemScriptable IS2;
    [SerializeField] private Vector3 Pos1;
    [SerializeField] private Vector3 Pos2;
    [SerializeField] private Vector3 Pos3;
    [SerializeField] private ItemHandler IH;

    private void Start()
    {
        IH.SpawnItem(IS1, Pos1);
        IH.SpawnItem(IS1, Pos2);
        IH.SpawnItem(IS1, Pos3);
    }
}
