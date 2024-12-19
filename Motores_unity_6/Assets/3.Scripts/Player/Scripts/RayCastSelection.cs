using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class RayCastSelection : MonoBehaviour
{
    LayerMask mask;
    public float distance = 1.5f;

    public GameObject TextDetection;
    GameObject lastRecon = null;

    void Start()
    {
        mask = LayerMask.GetMask("RaycastDetection");
        TextDetection.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
            Deselected();
            ObjectSelected(hit.transform);
            if (hit.collider.tag == "ObjetoInteractuable")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<CollectibleItem>().Interactions();
                }
            }
        }
        else
        {
            Deselected();
        }

    }

    void ObjectSelected(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        lastRecon = transform.gameObject;
    }

    void Deselected()
    {
        if (lastRecon)
        {
            lastRecon.GetComponent<Renderer>().material.color = Color.white;
            lastRecon = null;
        }
    }

    private void OnGUI()
    {
        if (lastRecon)
        {
            TextDetection.SetActive(true);
        }
        else
            TextDetection.SetActive(false);
    }
}
