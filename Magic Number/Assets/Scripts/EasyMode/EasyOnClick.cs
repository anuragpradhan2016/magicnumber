using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EasyOnClick : MonoBehaviour, IPointerClickHandler
{
    public EasyGameManager game;
    public EasyDrag drag;

    private CanvasGroup canvas;

    private void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        game = GameObject.FindObjectOfType<EasyGameManager>();
        drag = GetComponent<EasyDrag>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (drag.cardType == EasyDrag.CardType.Number)
        {
            if (drag.active)
            {
                if (game.answerOne.GetComponentInChildren<Text>().text == "")
                {
                    game.answerOne.GetComponentInChildren<Text>().text = this.transform.gameObject.GetComponentInChildren<Text>().text;
                    game.answerOne.GetComponentInChildren<Text>().fontSize = this.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                    game.answerOne.GetComponentInChildren<Text>().alignment = this.transform.gameObject.GetComponentInChildren<Text>().alignment;
                    game.answerOne.GetComponent<CanvasGroup>().alpha = 1f;
                }
                else if (game.answerThree.GetComponentInChildren<Text>().text == "")
                {
                    game.answerThree.GetComponentInChildren<Text>().text = this.transform.gameObject.GetComponentInChildren<Text>().text;
                    game.answerThree.GetComponentInChildren<Text>().fontSize = this.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                    game.answerThree.GetComponentInChildren<Text>().alignment = this.transform.gameObject.GetComponentInChildren<Text>().alignment;
                    game.answerThree.GetComponent<CanvasGroup>().alpha = 1f;
                }

                canvas.alpha = 0.6f;
                drag.active = false;
            }
        }
        else if (drag.cardType == EasyDrag.CardType.Operator)
        {
            if (game.answerTwo.GetComponentInChildren<Text>().text == "")
            {
                game.answerTwo.GetComponentInChildren<Text>().text = this.transform.gameObject.GetComponentInChildren<Text>().text;
                game.answerTwo.GetComponentInChildren<Text>().fontSize = this.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                game.answerTwo.GetComponentInChildren<Text>().alignment = this.transform.gameObject.GetComponentInChildren<Text>().alignment;
                game.answerTwo.GetComponentInChildren<Text>().fontStyle = this.transform.gameObject.GetComponentInChildren<Text>().fontStyle;
                game.answerTwo.GetComponent<CanvasGroup>().alpha = 1f;
            }
        }
    }
}
