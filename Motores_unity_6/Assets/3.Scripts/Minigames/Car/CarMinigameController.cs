using UnityEngine;
using UnityEngine.EventSystems;

public class CarMinigameController : MonoBehaviour
{
    private int neededWheels = 4;
    public int wheelsScrewed;
    [SerializeField] private GameObject carSide1, carSide2;

    //HABIRA QUE ACTIVAR ESTE CANVAS SOLO SI TIENE LAS $ RUEDAS NECESARIAS
    private void Update()
    {
        if (wheelsScrewed >= 2)
        {
            ShowCarSide(0);
        }
        else
            ShowCarSide(1);
    }
    public void ShowCarSide(int i)
    {
        switch (i) 
        {
            case 0:
                carSide1.SetActive(true);
                carSide2.SetActive(false);
                break;
            case 1:
                carSide1.SetActive(false);
                carSide2.SetActive(true);
                break;

            default:
                break;
        }
    }

    public void CheckIfEnded()
    {
        if(wheelsScrewed >= neededWheels)
        {
            //AQUI HABRIAS QUE PONER EL CODIGO DE MINIJUEGO COMPLETADO
            Debug.Log("Minijuego completado");
        }
    }
}
