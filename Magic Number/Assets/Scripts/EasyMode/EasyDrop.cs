using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EasyDrop : MonoBehaviour, IDropHandler
{
    public EasyDrag.CardType cardType = EasyDrag.CardType.Answer;
    public EasyGameManager game;

    void Awake()
    {
        game = GameObject.FindObjectOfType<EasyGameManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        EasyDrag d = eventData.pointerDrag.GetComponent<EasyDrag>();

        if (d != null && d.active)
        {
            if (d.cardType == EasyDrag.CardType.Number && this.transform.gameObject.name == "Answer2") { d.gameObject.GetComponent<CanvasGroup>().alpha = 1f; }
            else if (d.cardType == EasyDrag.CardType.Operator && (this.transform.gameObject.name == "Answer1" || this.transform.gameObject.name == "Answer3")) { }
            else if (d.cardType == EasyDrag.CardType.Answer && d.GetComponentInChildren<Text>().text == "") { }
            else if ((this.gameObject.name == "Answer1" &&
                (d.gameObject.name == "Answer2")) ||
                (this.gameObject.name == "Answer3" &&
                (d.gameObject.name == "Answer2") ||
                (this.gameObject.name == "Answer2" &&
                (d.gameObject.name == "Answer1" || d.gameObject.name == "Answer3")))) { }
            else if (d.cardType == EasyDrag.CardType.Answer)
            {
                string text = this.transform.gameObject.GetComponentInChildren<Text>().text;
                UnityEngine.FontStyle fontStyle = this.transform.gameObject.GetComponentInChildren<Text>().fontStyle;
                int fontSize = this.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                UnityEngine.TextAnchor align = this.transform.gameObject.GetComponentInChildren<Text>().alignment;

                this.transform.gameObject.GetComponentInChildren<Text>().text = d.transform.gameObject.GetComponentInChildren<Text>().text;
                this.transform.gameObject.GetComponentInChildren<Text>().fontStyle = d.transform.gameObject.GetComponentInChildren<Text>().fontStyle;
                this.transform.gameObject.GetComponentInChildren<Text>().fontSize = d.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                this.transform.gameObject.GetComponentInChildren<Text>().alignment = d.transform.gameObject.GetComponentInChildren<Text>().alignment;
                this.gameObject.GetComponent<CanvasGroup>().alpha = 1f;

                d.transform.gameObject.GetComponentInChildren<Text>().text = text;
                d.transform.gameObject.GetComponentInChildren<Text>().fontStyle = fontStyle;
                d.transform.gameObject.GetComponentInChildren<Text>().fontSize = fontSize;
                d.transform.gameObject.GetComponentInChildren<Text>().alignment = align;
                d.gameObject.GetComponent<CanvasGroup>().alpha = 1f;

                d.active = true;
                d.droppedToLocation = true;
            }
            else
            {
                string num = this.transform.gameObject.GetComponentInChildren<Text>().text;

                this.transform.gameObject.GetComponentInChildren<Text>().text = d.transform.gameObject.GetComponentInChildren<Text>().text;
                this.transform.gameObject.GetComponentInChildren<Text>().fontStyle = d.transform.gameObject.GetComponentInChildren<Text>().fontStyle;
                this.transform.gameObject.GetComponentInChildren<Text>().fontSize = d.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                this.transform.gameObject.GetComponentInChildren<Text>().alignment = d.transform.gameObject.GetComponentInChildren<Text>().alignment;
                this.transform.gameObject.GetComponent<CanvasGroup>().alpha = 1f;

                if (d.cardType == EasyDrag.CardType.Number)
                {
                    d.gameObject.GetComponent<CanvasGroup>().alpha = 0.6f;
                    d.active = false;
                    d.droppedToLocation = true;

                    if (game.numberOne.GetComponentInChildren<Text>().text == num && !game.numberOne.GetComponent<EasyDrag>().active)
                    {
                        game.numberOne.GetComponent<EasyDrag>().active = true;
                        game.numberOne.GetComponent<EasyDrag>().GetComponent<CanvasGroup>().alpha = 1f;

                    }
                    else if (game.numberTwo.GetComponentInChildren<Text>().text == num && !game.numberTwo.GetComponent<EasyDrag>().active)
                    {
                        game.numberTwo.GetComponent<EasyDrag>().active = true;
                        game.numberTwo.GetComponent<EasyDrag>().GetComponent<CanvasGroup>().alpha = 1f;
                    }
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
