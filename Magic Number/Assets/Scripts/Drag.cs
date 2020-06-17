using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public enum CardType {Number, Operator, Answer};
    public CardType cardType;
    public Vector2 originalPosition;
    public Boolean active;
    public Boolean droppedToLocation;
    public GameManager game;

    private CanvasGroup canvas;

    private void Awake()
    {
        canvas = GetComponent<CanvasGroup>();
        this.originalPosition = this.transform.position;
        active = true;
        droppedToLocation = false;
        game = GameObject.FindObjectOfType<GameManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.SetAsLastSibling();

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
        this.transform.SetAsFirstSibling();

        if (!active) return;

        if ((this.cardType == CardType.Answer || this.cardType == CardType.Number) && droppedToLocation == false)
        {
            canvas.alpha = 1f;

            if (this.cardType == CardType.Answer)
            {
                if (eventData.position.y > game.answerBackground.transform.position.y + game.answerBackground.GetComponent<RectTransform>().rect.height / 2)
                {
                    if (this.transform.gameObject.GetComponentInChildren<Text>().text != "" && !isOperator(this.transform.gameObject.GetComponentInChildren<Text>().text))
                    {
                        string num = this.transform.gameObject.GetComponentInChildren<Text>().text;

                        if (game.numberOne.GetComponentInChildren<Text>().text == num)
                        {
                            game.numberOne.GetComponent<Drag>().active = true;
                            game.numberOne.GetComponent<Drag>().GetComponent<CanvasGroup>().alpha = 1f;

                        } else if (game.numberTwo.GetComponentInChildren<Text>().text == num)
                        {
                            game.numberTwo.GetComponent<Drag>().active = true;
                            game.numberTwo.GetComponent<Drag>().GetComponent<CanvasGroup>().alpha = 1f;
                        } else if (game.numberThree.GetComponentInChildren<Text>().text == num)
                        {
                            game.numberThree.GetComponent<Drag>().active = true;
                            game.numberThree.GetComponent<Drag>().GetComponent<CanvasGroup>().alpha = 1f;
                        }
                    } 
                        this.transform.gameObject.GetComponentInChildren<Text>().text = "";
                }
            }
        } else if (this.cardType == CardType.Answer || this.cardType == CardType.Number)
        {
            droppedToLocation = false;
        } else if (active)
        {
            canvas.alpha = 1f;
        }
    }

    public bool isOperator(string str)
    {
        return str == "+" || str == "_" || str == "x" || str == "/";
    }
}
