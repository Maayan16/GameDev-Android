using UnityEngine;

public class TesterMerge : MonoBehaviour
{
    [SerializeField] private ItemScriptable IS1;
    [SerializeField] private ItemScriptable IS2;
    [SerializeField] private Vector3 Pos1;
    [SerializeField] private Vector3 Pos2;
    private void Start()
    {
        MergeManager.Instance.SpanweItem(IS1, Pos1);
        MergeManager.Instance.SpanweItem(IS2, Pos2);
    }
}
