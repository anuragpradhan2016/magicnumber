using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler
{
    public Drag.CardType cardType = Drag.CardType.Answer;
    public GameManager game;

    void Awake()
    {
        game = GameObject.FindObjectOfType<GameManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Drag d = eventData.pointerDrag.GetComponent<Drag>();

        if (d != null && d.active)
        {
            if (d.cardType == Drag.CardType.Number && (this.transform.gameObject.name == "Answer2" || this.transform.gameObject.name == "Answer4")) { d.gameObject.GetComponent<CanvasGroup>().alpha = 1f; }
            else if (d.cardType == Drag.CardType.Operator && (this.transform.gameObject.name == "Answer1" || this.transform.gameObject.name == "Answer3"
                || this.transform.gameObject.name == "Answer5")) { }
            else if (d.cardType == Drag.CardType.Answer && d.GetComponentInChildren<Text>().text == "") { }
            else if ((this.gameObject.name == "Answer1" && 
                (d.gameObject.name == "Answer2" || d.gameObject.name == "Answer4")) || 
                (this.gameObject.name == "Answer3" &&
                (d.gameObject.name == "Answer2" || d.gameObject.name == "Answer4")) || 
                (this.gameObject.name == "Answer5" &&
                (d.gameObject.name == "Answer2" || d.gameObject.name == "Answer4")) || 
                (this.gameObject.name == "Answer2" &&
                (d.gameObject.name == "Answer1" || d.gameObject.name == "Answer3" || d.gameObject.name == "Answer5")) ||
                 (this.gameObject.name == "Answer4" &&
                (d.gameObject.name == "Answer1" || d.gameObject.name == "Answer3" || d.gameObject.name == "Answer5"))) {}
            else if (d.cardType == Drag.CardType.Answer)
            {
                string text = this.transform.gameObject.GetComponentInChildren<Text>().text;
                UnityEngine.FontStyle fontStyle = this.transform.gameObject.GetComponentInChildren<Text>().fontStyle;
                int fontSize = this.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                UnityEngine.TextAnchor align = this.transform.gameObject.GetComponentInChildren<Text>().alignment;

                this.transform.gameObject.GetComponentInChildren<Text>().text = d.transform.gameObject.GetComponentInChildren<Text>().text;
                this.transform.gameObject.GetComponentInChildren<Text>().fontStyle = d.transform.gameObject.GetComponentInChildren<Text>().fontStyle;
                this.transform.gameObject.GetComponentInChildren<Text>().fontSize = d.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                this.transform.gameObject.GetComponentInChildren<Text>().alignment = d.transform.gameObject.GetComponentInChildren<Text>().alignment;

                d.transform.gameObject.GetComponentInChildren<Text>().text = text;
                d.transform.gameObject.GetComponentInChildren<Text>().fontStyle = fontStyle;
                d.transform.gameObject.GetComponentInChildren<Text>().fontSize = fontSize;
                d.transform.gameObject.GetComponentInChildren<Text>().alignment = align;

                d.active = true;
                d.droppedToLocation = true;
            } else
            {
                this.transform.gameObject.GetComponentInChildren<Text>().text = d.transform.gameObject.GetComponentInChildren<Text>().text;
                this.transform.gameObject.GetComponentInChildren<Text>().fontStyle = d.transform.gameObject.GetComponentInChildren<Text>().fontStyle;
                this.transform.gameObject.GetComponentInChildren<Text>().fontSize = d.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                this.transform.gameObject.GetComponentInChildren<Text>().alignment = d.transform.gameObject.GetComponentInChildren<Text>().alignment;
                this.transform.gameObject.GetComponent<CanvasGroup>().alpha = 1f;

                if (d.cardType == Drag.CardType.Number)
                {
                    d.gameObject.GetComponent<CanvasGroup>().alpha = 0.6f;
                    d.active = false;
                    d.droppedToLocation = true;
                }
                else
                {
                    d.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
                    d.active = true;
                }
            }
        }
    }
}
