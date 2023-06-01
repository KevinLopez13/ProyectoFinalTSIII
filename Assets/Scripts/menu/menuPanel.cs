using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuPanel : MonoBehaviour
{
    public Button circuit_btn, component_btn;
    public menu master;
    
    void Start()
    {
        circuit_btn.onClick.AddListener(master.CircuitPanel);
        component_btn.onClick.AddListener(master.ComponentPanel);
    }

    
}
