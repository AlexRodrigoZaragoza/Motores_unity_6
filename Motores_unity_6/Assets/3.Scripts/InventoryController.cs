using UnityEngine;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour {

    public static InventoryController Instance { get; private set; }
    public List <string> items = new List<string>();
    public delegate void InventoryChanged();
    public event InventoryChanged OnInventoryChanged;

    void Awake() {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    void Update() {
        string mensajeInventario = "";
        mensajeInventario+=("Contenido actual del inventario:");

        foreach (var it in items)
            mensajeInventario+=("\n- " + it + "");

        Debug.Log(mensajeInventario);
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
