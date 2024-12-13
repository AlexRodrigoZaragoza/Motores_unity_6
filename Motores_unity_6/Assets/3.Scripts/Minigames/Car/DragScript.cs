using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] List<RectTransform> positionsToSnap;
    private Vector3 inicialTransform;
    public Transform initialParent;
    private Image img;
    private bool snaped;

    private void Start()
    {
        inicialTransform = GetComponent<RectTransform>().position;
        initialParent = GetComponent<RectTransform>().parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        img = GetComponent<Image>();
        img.raycastTarget = false;
        Debug.Log("Begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End dragging");
        img.raycastTarget = true;

        CheckIfOver(eventData);
    }

    private void CheckIfOver(PointerEventData eventData)
    {
        foreach(RectTransform rectTrans in positionsToSnap)
        {
            if(rectTrans.position == img.rectTransform.position)
            {
                snaped = true;
                return;
            }
        }

        snaped = false;
        GameObject dropped = eventData.pointerDrag;
        dropped.transform.SetParent(initialParent, false);
        gameObject.GetComponent<RectTransform>().position = inicialTransform;
    }
}

