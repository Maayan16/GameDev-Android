using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Tester : MonoBehaviour
{
    public List<PopupScriptable> scripts = new List<PopupScriptable>();
    void Start()
    {
        PopUpManager.instance.StartPopupPopLifeCycle(scripts[0]);
    }

}
