using System.Threading.Tasks;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject PopUpPrefab;
    [SerializeField] private TMPro.TextMeshPro title;
    [SerializeField] private TMPro.TextMeshPro description;
    [SerializeField] private Transform PopupPosition;
    [SerializeField] private int popupLifeTime;
    private GameObject popupGO; //GameObject

    private void Awake()
    {   //make sure the text is clear
        //title = PopUpPrefab.getcomp
        description.text = "";
    }

    public async void StartPopupPopLifeCycle(PopupScriptable popup)
    {
        popupGO = Instantiate(PopUpPrefab, PopupPosition);
        title.text = popup.title;
        description.text = popup.description;

        await Task.Delay(popupLifeTime *1000);
        Destroy(popupGO);

        //we may need to register it somewhere if its an achievement
    }

}
