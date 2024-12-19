using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    //public GameObject pressEText; Variable para un posible canvas que indique al jugador que presione E para recoegr
    public string itemName;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Interactions()
    {

        if (itemName.Equals("CocheProta"))
        {
            Debug.Log("Has clicado sobre el coche");
            GameManager.Instance.miniGameCar();
        }
        else
        {
            Debug.Log("El jugador recogió el objeto: " + itemName);
            InventoryController.Instance.AddItem(itemName);
            Destroy(gameObject);
        }
    }
}