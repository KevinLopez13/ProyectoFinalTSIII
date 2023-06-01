using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject menu_panel, circuit_panel, component_panel;

    public void MainMenu(){
        circuit_panel.SetActive(false);
        component_panel.SetActive(false);
        menu_panel.SetActive(true);
    }

    public void CircuitPanel(){
        menu_panel.SetActive(false);
        component_panel.SetActive(false);
        circuit_panel.SetActive(true);
    }

    public void ComponentPanel(){
        menu_panel.SetActive(false);
        circuit_panel.SetActive(false);
        component_panel.SetActive(true);
    }
}
