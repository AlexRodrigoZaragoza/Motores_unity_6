using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnapScript : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        dropped.transform.position = transform.position;
        dropped.transform.SetParent(transform, true);
    }
}
