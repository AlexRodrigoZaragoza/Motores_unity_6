using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class WireTask : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Image[] leftWires;      // Los 4 cables de la izquierda
    public Image[] rightWires;     // Los 4 cables de la derecha
    public LineRenderer wireConnection; // El LineRenderer para la conexión

    public float stretchDuration = 0.2f; // Duración del efecto de estiramiento

    private Image currentWire;     // El cable que se está arrastrando
    private int wiresConnected;     // Contador de cables conectados

    public void OnPointerDown(PointerEventData eventData)
    {
        // Detectar si se hizo clic en un cable de la izquierda
        for (int i = 0; i < leftWires.Length; i++)
        {
            if (eventData.pointerCurrentRaycast.gameObject == leftWires[i].gameObject)
            {
                currentWire = leftWires[i];
                currentWire.transform.SetAsLastSibling(); // Traer al frente
                break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Mover el cable con el ratón
        if (currentWire != null)
        {
            currentWire.rectTransform.position = eventData.position;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (currentWire != null)
        {
            bool connected = false;

            // Detectar si se soltó sobre un cable de la derecha
            for (int i = 0; i < rightWires.Length; i++)
            {
                if (eventData.pointerCurrentRaycast.gameObject == rightWires[i].gameObject &&
                    currentWire.color == rightWires[i].color) // Comprobar si coinciden los colores
                {
                    // Conectar los cables (visualmente)
                    currentWire.rectTransform.position = rightWires[i].rectTransform.position;
                    currentWire.raycastTarget = false; // Desactivar el raycast para que no se pueda volver a arrastrar
                    rightWires[i].raycastTarget = false;

                    // Activar el LineRenderer e iniciar la corrutina para el efecto de estiramiento
                    wireConnection.enabled = true;
                    StartCoroutine(StretchWire(currentWire.transform.position, rightWires[i].transform.position));

                    wiresConnected++;
                    connected = true;
                    break;
                }
            }

            if (!connected)
            {
                // Devolver el cable a su posición original
                currentWire.rectTransform.anchoredPosition = Vector2.zero;
            }

            currentWire = null;

            // Comprobar si se han conectado todos los cables
            if (wiresConnected == 4)
            {
                Debug.Log("¡Tarea completada!");
                // Aquí puedes añadir la lógica para finalizar el minijuego
            }
        }
    }

    // Corrutina para el efecto de estiramiento
    private IEnumerator StretchWire(Vector3 startPos, Vector3 endPos)
    {
        float elapsedTime = 0f;
        wireConnection.SetPosition(0, startPos); // Inicialmente, la línea comienza en el punto de inicio

        while (elapsedTime < stretchDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / stretchDuration; // Valor normalizado entre 0 y 1

            // Interpolar la posición del segundo punto de la línea
            Vector3 currentPos = Vector3.Lerp(startPos, endPos, t);
            wireConnection.SetPosition(1, currentPos);

            yield return null; // Esperar al siguiente frame
        }

        wireConnection.SetPosition(1, endPos); // Asegurar que la línea llega al punto final
    }
}