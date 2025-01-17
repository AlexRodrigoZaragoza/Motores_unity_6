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
    bool electricidadOK = false;
    bool llaveOK = false;
    bool ruedasOK = false;
    bool bujiaOK = false;

    public GameManager gameManager;

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
        if (nota == 1)
        {
            if (!gameManager.miniGameWiresCompleted)
            {
                notaElectricidad.SetActive(true);
            }
        }
        else if (nota == 2)
        {
            if (!gameManager.hasKey)
            {
                notaLlave.SetActive(true);
            }
        }
        else if (nota == 3)
        {
            if (!gameManager.miniGameTiresCompleted)
            {
                notaRuedas.SetActive(true);
            }
        }
        else if (nota == 4)
        {
            if (!gameManager.miniGameSparkPlugCompleted)
            {
                notaBujia.SetActive(true);
            }
        }
    }

    public void complete(int task)
    {
        if(task == 1)
        {
            notaElectricidad.SetActive(false);
            electricidadOK = true;
        }
        else if(task == 2)
        {
            notaLlave.SetActive(false);
            llaveOK = true;
        }
        else if (task == 3)
        {
            notaRuedas.SetActive(false);
            ruedasOK = true;
        }
        else if (task == 4)
        {
            notaBujia.SetActive(false);
            bujiaOK = true;
        }

        if (electricidadOK && llaveOK && ruedasOK && bujiaOK) gameObject.SetActive(false);
    }
}
