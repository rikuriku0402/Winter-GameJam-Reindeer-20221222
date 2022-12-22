using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonHighlight : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    [SerializeField] Text text;
    private void Awake()
    {
        text.enabled = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.enabled = false;
    }
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("b");
    }

    public void OnPointer()
    {
        Debug.Log("c");
    }
}
