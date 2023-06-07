using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Screen touch manager.
    Triggered its respective component function when is touched.
*/
public class selection : MonoBehaviour
{
    private RaycastHit raycastHit;

    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            
            if (Physics.Raycast(ray, out raycastHit) && (touch.phase == TouchPhase.Began)){
                raycastHit.transform.gameObject.GetComponent<adapter>().onTouch();
            }
        }
    }
}
