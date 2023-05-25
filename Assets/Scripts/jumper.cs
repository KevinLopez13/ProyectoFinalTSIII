using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumper : MonoBehaviour
{
    public float pin1, pin2;
    void Start()
    {
        
    }

    void Update()
    {
        pin2 = pin1;
    }
}
