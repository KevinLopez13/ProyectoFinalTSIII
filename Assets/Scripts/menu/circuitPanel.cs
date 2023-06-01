using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circuitPanel : MonoBehaviour
{
    public Button btn_menu;
    public menu master;

    void Start()
    {
        btn_menu.onClick.AddListener(master.MainMenu);
    }

}
