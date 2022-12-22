using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObj : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    [Header("親のオブジェクト")]
    Transform _parentTransform;

    public void OnBeginDrag(PointerEventData data)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        _parentTransform = transform.parent;
        transform.SetParent(transform.parent.parent);

    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        transform.SetParent(_parentTransform);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}