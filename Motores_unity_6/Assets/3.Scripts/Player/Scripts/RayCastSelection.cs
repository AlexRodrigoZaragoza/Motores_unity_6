using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayCastSelection : MonoBehaviour
{
    LayerMask mask;
    public float distance = 1.5f;

    void Start()
    {
        mask = LayerMask.GetMask("RaycastDetection");
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
            if(hit.collider.tag == "ObjetoInteractuable")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<InteractiveObject>().Interaction();
                }
            }
        }
        
    }
}
