using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public enum CardType {Number, Operator, Answer};
    public CardType cardType;
    public Vector2 originalPosition;
    public Boolean active;

    private CanvasGroup canvas;

    private void Awake()
    {
        canvas = GetComponent<CanvasGroup>();
        this.originalPosition = this.transform.position;
        active = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (active)
        {
            canvas.alpha = 0.6f;
            canvas.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (active)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         canvas.blocksRaycasts = true;
         this.transform.position = this.originalPosition;
   
    }
}
