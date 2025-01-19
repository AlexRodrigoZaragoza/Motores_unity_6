using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class RayCastSelection : MonoBehaviour
{
    LayerMask mask;
    public float distance = 1.5f;
    public Material Outline;
    private Material baseMaterial;
    private MeshRenderer meshRenderer;

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
            meshRenderer = hit.transform.GetComponent<MeshRenderer>();
            baseMaterial = meshRenderer.material;
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
        //Renderer renderer = GetComponent<Renderer>();
        /*if(renderer != null && Outline != null) 
         {
             renderer.material = Outline;
         }
         //transform.GetComponent<MeshRenderer>().material.color = UnityEngine.Color.green;
         //transform.GetComponent<MeshRenderer>().material = Outline;*/


        /*if (renderer != null && Outline != null)
        {
            Material[] materials = renderer.materials;
            Material[] newMaterials = new Material[materials.Length + 1];

            for (int i = 0; 1 < materials.Length; i++)
            {
                newMaterials[i] = materials[i];
            }


            newMaterials[materials.Length] = Outline;


            renderer.materials = newMaterials;

            Debug.Log("Second material added successfully!");

        }*/


        

        if (meshRenderer != null)
        {
            // Crear un array de materiales
            Material[] materials = new Material[2];
            materials[0] = baseMaterial;
            materials[1] = Outline;  // Asignar el material de outline

            // Asignar los materiales al MeshRenderer
            meshRenderer.materials = materials;
        }
        else
        {
            Debug.LogError("No se encontró un MeshRenderer en este objeto.");
        }



    }
    void Deselected()
    {
        
        Material[] materials = new Material[1];
        materials[0] = baseMaterial;
        meshRenderer.materials = materials;
        if (lastRecon)
        {
            lastRecon.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
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
