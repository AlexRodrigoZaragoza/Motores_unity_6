using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public enum Color { blue, red, yellow, green };
public class PoweredWireStatus : MonoBehaviour
{
    public bool movable = false;
    public bool moving = false;
    public Vector3 startPosition;
    public Color objectColor;


    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
