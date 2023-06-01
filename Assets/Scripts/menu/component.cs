using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class component : MonoBehaviour
{
    public componentsPanel master;
    public Button btn;
    public GameObject model;
    public bool active;
    private float speed = 50.0f;
    public bool Zup = false;

    void OnMouseDown(){
        Zup = !Zup;
    }

    void BtnOnClick(){
        master.hideAllComponents();
        setActive(true);
    }

    public void setActive(bool ac){
        active = ac;
        model.SetActive(active);
        model.transform.rotation = Quaternion.identity;
    }

    void Start(){
        active = false;
        btn.onClick.AddListener(BtnOnClick);
    }

    void Update(){
        if (active){
            if(Zup)
                model.transform.Rotate( Vector3.forward, speed * Time.deltaTime );
            else
                model.transform.Rotate( Vector3.up, speed * Time.deltaTime );
        }
    }

}
