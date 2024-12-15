using UnityEngine;
using System.Collections.Generic;

public class InventoryControler : MonoBehaviour {

    public static InventoryControler Inventory { get; private set; }
    public List <string> items = new List<string>();
    public delegate void InventoryChanged();
    public event InventoryChanged OnInventoryChanged;

    void Awake() {
        if (Inventory != null && Inventory != this)
            Destroy(gameObject);
        else
            Inventory = this;
    }

    public void AddItem(string item) {
        if (!items.Contains(item)){
            items.Add(item);
            OnInventoryChanged?.Invoke();
        }
    }

    public void RemoveItem(string item) {
        if (items.Contains(item)) {
            items.Remove(item);
            OnInventoryChanged?.Invoke();
        }
    }
}
