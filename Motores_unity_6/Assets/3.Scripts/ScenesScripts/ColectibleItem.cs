using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    //public GameObject pressEText; Variable para un posible canvas que indique al jugador que presione E para recoegr
    public string itemName;
    InventoryController Inventory;
    GameManager Manager;
    public TaskController TaskController;

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

        if (itemName.Equals("CocheProta")) {
            Debug.Log("Has clicado sobre el coche");
            Manager.InteractionCar();
        }
        else if(itemName.Equals("Door")) {
            Debug.Log("He interaccionado con la puerta");
        }
        else if (itemName.Equals("Nota_Electricidad"))
        {
            Debug.Log("He interaccionado con la nota");
            TaskController.setNota(1);
            Destroy(gameObject);
        }
        else if (itemName.Equals("Nota_Llave"))
        {
            Debug.Log("He interaccionado con la nota");
            TaskController.setNota(2);
            Destroy(gameObject);
        }
        else if (itemName.Equals("Nota_Ruedas"))
        {
            Debug.Log("He interaccionado con la nota");
            TaskController.setNota(3);
            Destroy(gameObject);
        }
        else if (itemName.Equals("Nota_Bujia"))
        {
            Debug.Log("He interaccionado con la nota");
            TaskController.setNota(4);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("El jugador recogió el objeto: " + itemName);
            Inventory.AddItem(itemName);
            Destroy(gameObject);
        }
/*        else if (itemName.Contains("Tire"))
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
*/      
    }
}