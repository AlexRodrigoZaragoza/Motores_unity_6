using UnityEngine;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{

    public static InventoryController Instance { get; private set; }
    public List<string> items = new List<string>();
    public int tiresColected = 0;

    GameManager Manager;

    void Awake()
    {
        Manager = FindFirstObjectByType<GameManager>();
    }

    public void AddItem(string item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);

            if (item.Contains("Tire"))
            {
                tiresColected++;
                Debug.Log("Rueda recogida, hay un total de " + tiresColected);
            }
            else if (item.Contains("SparkPlug"))
            {
                Manager.miniGameSparkPlugCompleted = true;
                Debug.Log("Minijuego de encontrar bujia completado.");
            }
            else if (item.Contains("Key")){
                Manager.hasKey = true;
                Debug.Log("El jugador tiene la llave y el game manager lo sabe");
            }
            if (tiresColected == 4)
            {
                Manager.allTiresColected = true;
                Debug.Log("Todas las ruedas recogidas");
            }
            string mensajeInventario = "";
            mensajeInventario += ("Contenido actual del inventario:");

            foreach (var it in items)
                mensajeInventario += ("\n- " + it + "");

            Debug.Log(mensajeInventario);
        }
    }

    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            string mensajeInventario = "";
            mensajeInventario += ("Contenido actual del inventario:");

            foreach (var it in items)
                mensajeInventario += ("\n- " + it + "");

            Debug.Log(mensajeInventario);
        }
    }

    public void RemoveAllItem(string item)
    {
        items.RemoveAll(it => it.Contains(item));
        string mensajeInventario = "";
        mensajeInventario += ("Contenido actual del inventario:");

        foreach (var it in items)
            mensajeInventario += ("\n- " + it + "");

        Debug.Log(mensajeInventario);
    }
}
