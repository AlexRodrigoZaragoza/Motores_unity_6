using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    //public GameObject pressEText; Variable para un posible canvas que indique al jugador que presione E para recoegr
    public string itemName;
    InventoryController Inventory;
    GameManager Manager;

    void Start()
    {
        Inventory = FindFirstObjectByType<InventoryController>();
        Manager = FindFirstObjectByType<GameManager>();
        
    }

    void Update()
    {

    }

    public void Interactions()
    {

        if (itemName.Equals("CocheProta"))
        {
            Debug.Log("Has clicado sobre el coche");
            Manager.miniGameCar();
        }
        else if (itemName.Contains("Tire"))
        {
            Debug.Log("El jugador recogió el objeto: " + itemName);
            Inventory.AddItem(itemName);
            Destroy(gameObject);
        }
        else if (itemName.Equals("SparkPlug"))
        {
            Debug.Log("El jugador recogió el objeto: " + itemName);
            Inventory.AddItem(itemName);
            Destroy(gameObject);
        }





    }
}