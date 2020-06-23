using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClick : MonoBehaviour, IPointerClickHandler
{
    public GameManager game;
    public Drag drag;

    private CanvasGroup canvas;

    private void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        game = GameObject.FindObjectOfType<GameManager>();
        drag = GetComponent<Drag>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (drag.cardType == Drag.CardType.Number)
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
                else if (game.answerFive.GetComponentInChildren<Text>().text == "")
                {
                    game.answerFive.GetComponentInChildren<Text>().text = this.transform.gameObject.GetComponentInChildren<Text>().text;
                    game.answerFive.GetComponentInChildren<Text>().fontSize = this.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                    game.answerFive.GetComponentInChildren<Text>().alignment = this.transform.gameObject.GetComponentInChildren<Text>().alignment;
                    game.answerFive.GetComponent<CanvasGroup>().alpha = 1f;
                }

                canvas.alpha = 0.6f;
                drag.active = false;
            }
        }
        else if (drag.cardType == Drag.CardType.Operator)
        {
            if (game.answerTwo.GetComponentInChildren<Text>().text == "")
            {
                game.answerTwo.GetComponentInChildren<Text>().text = this.transform.gameObject.GetComponentInChildren<Text>().text;
                game.answerTwo.GetComponentInChildren<Text>().fontSize = this.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                game.answerTwo.GetComponentInChildren<Text>().alignment = this.transform.gameObject.GetComponentInChildren<Text>().alignment;
                game.answerTwo.GetComponentInChildren<Text>().fontStyle = this.transform.gameObject.GetComponentInChildren<Text>().fontStyle;
                game.answerTwo.GetComponent<CanvasGroup>().alpha = 1f;
            }
            else if (game.answerFour.GetComponentInChildren<Text>().text == "")
            {
                game.answerFour.GetComponentInChildren<Text>().text = this.transform.gameObject.GetComponentInChildren<Text>().text;
                game.answerFour.GetComponentInChildren<Text>().fontSize = this.transform.gameObject.GetComponentInChildren<Text>().fontSize;
                game.answerFour.GetComponentInChildren<Text>().alignment = this.transform.gameObject.GetComponentInChildren<Text>().alignment;
                game.answerFour.GetComponentInChildren<Text>().fontStyle = this.transform.gameObject.GetComponentInChildren<Text>().fontStyle;
                game.answerFour.GetComponent<CanvasGroup>().alpha = 1f;
            }
        }
    }
}
