using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class led : MonoBehaviour
{

    public float positive_pin, negative_pin;
    public GameObject led_on, led_off;
    public bool state;

    void Update()
    {
        if (state == true){
            led_on.SetActive(true);
            led_off.SetActive(false);
        }
        else {
            led_on.SetActive(false);
            led_off.SetActive(true);
        }
    }
}
