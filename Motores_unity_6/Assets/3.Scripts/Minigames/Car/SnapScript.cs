using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnapScript : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            return;
        }


        GameObject dropped = eventData.pointerDrag;
        dropped.transform.SetParent(transform, false);
        dropped.transform.localPosition = Vector3.zero;

    }
}
