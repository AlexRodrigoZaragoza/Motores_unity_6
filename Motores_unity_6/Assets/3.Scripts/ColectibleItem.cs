using UnityEngine;

public class CollectibleItem : MonoBehaviour {
    public GameObject pressEText;
    public string itemName;
    private bool playerInRange = false;

    void Start() {
        pressEText.SetActive(false);
    }

    void Update() {
        if (playerInRange){ 
            pressEText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("El jugador recogió el objeto: " + itemName);
                InventoryController.Instance.AddItem(itemName);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            pressEText.SetActive(true);
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            pressEText.SetActive(false);
            playerInRange = false;
        }
    }
}