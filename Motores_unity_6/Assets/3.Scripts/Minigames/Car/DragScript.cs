using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CarMinigameController _controller;
    [SerializeField] List<RectTransform> positionsToSnap;
    private Vector3 inicialTransform;
    public Transform initialParent;
    private Image img;
    public bool snaped, screwed;

    private void Start()
    {
        _controller = FindFirstObjectByType<CarMinigameController>();
        inicialTransform = GetComponent<RectTransform>().position;
        initialParent = GetComponent<RectTransform>().parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (screwed) return;
        img = GetComponent<Image>();
        img.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (screwed) return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (screwed) return;
        img.raycastTarget = true;
        CheckIfOver(eventData);
    }

    private void CheckIfOver(PointerEventData eventData)
    {
        foreach(RectTransform rectTrans in positionsToSnap)
        {
            if(rectTrans.position == img.rectTransform.position)
            {
                _controller.wheelsSnapped += 1;
                snaped = true;
                return;
            }
        }

        if(snaped)
        {
            _controller.wheelsSnapped -= 1;
        }

        snaped = false;
        GameObject dropped = eventData.pointerDrag;
        dropped.transform.SetParent(initialParent, false);
        gameObject.GetComponent<RectTransform>().position = inicialTransform;
    }
}

