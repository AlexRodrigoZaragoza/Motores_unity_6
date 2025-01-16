using Unity.AppUI.UI;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public GameObject panel;
    public GameObject notaBujia;
    public GameObject notaLlave;
    public GameObject notaElectricidad;
    public GameObject notaRuedas;
    bool firstNote = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void setNota(int nota)
    {
        if (!firstNote)
        {
            firstNote = true;
            panel.SetActive(true);

        }
        if (nota == 1) notaElectricidad.SetActive(true);
        else if (nota == 2) notaLlave.SetActive(true);
        else if (nota == 3) notaRuedas.SetActive(true);
        else if (nota == 4) notaBujia.SetActive(true);
    }
}
