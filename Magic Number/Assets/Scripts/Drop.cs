using System.Collections;
using System.Collections.Generic;
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
            this.transform.gameObject.GetComponentInChildren<Text>().text = d.transform.gameObject.GetComponentInChildren<Text>().text;
            this.transform.gameObject.GetComponentInChildren<Text>().fontStyle = d.transform.gameObject.GetComponentInChildren<Text>().fontStyle;
            this.transform.gameObject.GetComponentInChildren<Text>().fontSize = d.transform.gameObject.GetComponentInChildren<Text>().fontSize;
            this.transform.gameObject.GetComponentInChildren<Text>().alignment = d.transform.gameObject.GetComponentInChildren<Text>().alignment;

            if (d.cardType == Drag.CardType.Number){
                d.gameObject.GetComponent<CanvasGroup>().alpha = 0.6f;
                d.active = false;
            } else
            {
                d.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
                d.active = true;
            }
        }
    }
}
