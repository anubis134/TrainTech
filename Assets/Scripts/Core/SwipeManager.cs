using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManager : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    internal static Action<Vector2> OnWasSwipe;
    [SerializeField]
    private Vector2 DragData;
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.delta != Vector2.zero)
        {
            DragData = new Vector2(eventData.delta.x, eventData.delta.y);
            OnWasSwipe(DragData);
        }
    }


}
