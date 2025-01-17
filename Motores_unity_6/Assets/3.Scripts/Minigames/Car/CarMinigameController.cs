using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarMinigameController : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    private int neededWheels = 4;
    public int wheelsSnapped;
    public int wheelsScrewed;
    [SerializeField] private GameObject carSide1, carSide2;

    GameManager Manager;
    InventoryController inventoryController;

    public TaskController taskController;

    private void Start()
    {
        Manager = FindFirstObjectByType<GameManager>();
        inventoryController = FindFirstObjectByType<InventoryController>();
    }
    //HAY QUE ASIGNAR A MANO EL AUDIO SOURCE
    private void Update()
    {
        if(wheelsSnapped < 2)
        {
            infoText.text = "Drag the wheels to the car.";
        }
        else
            infoText.text = "Hold <E> over the placed wheels to screw them in.";

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
            Manager.miniGameTiresCompleted = true;
            inventoryController.RemoveAllItem("Tire");
            Manager.InteractionCar();
            Debug.Log("Minijuego completado");
        }
    }
}
