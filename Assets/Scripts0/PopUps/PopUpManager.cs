using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject PopUpCanvasPrefab;
    private TextMeshProUGUI title;
    private TextMeshProUGUI description;
    [SerializeField] private Transform PopupPosition;
    [SerializeField] private int popupLifeTime;
    private GameObject popupCanvasGO; //GameObject
    public static PopUpManager instance;

    private void Awake()
    {   
        //singleton
        if (instance == null) { instance = this; }
        else { Destroy(this.gameObject); }
    }

    public async void StartPopupPopLifeCycle(PopupScriptable popup)
    {
        popupCanvasGO = Instantiate(PopUpCanvasPrefab, PopupPosition);
        GameObject popupImage = popupCanvasGO.transform.GetChild(0).gameObject;

        //trying to get the fucking tmpro items
        foreach (Transform childTransform in popupImage.transform)
        {
            GameObject childGO = childTransform.gameObject;

            print(childGO.GetComponentAtIndex(2));

            if (childGO.name == "Title")
            {
                title = childGO.GetComponent<TextMeshProUGUI>();
                print("title success");
            }
            if (childGO.name == "Description")
            {
                description = childGO.GetComponent<TextMeshProUGUI>();
                print("description success");
            }
        }
        //set the vars
        title.text = popup.title;
        description.text = popup.description;

        await Task.Delay(popupLifeTime *1000);
        Destroy(popupCanvasGO);

        //we may need to register it somewhere if its an achievement
    }

}
