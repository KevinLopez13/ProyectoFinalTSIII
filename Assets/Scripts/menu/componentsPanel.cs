using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class componentsPanel : MonoBehaviour
{
    public component[] components;
    public Button btn_menu;
    public menu master;

    
    public void hideAllComponents(){
        foreach( component comp in components){
            comp.setActive(false);
        }
    }

    public void MenuOnClick(){
        hideAllComponents();
        master.MainMenu();
    }

    void Start()
    {
        btn_menu.onClick.AddListener(MenuOnClick);
        hideAllComponents();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
