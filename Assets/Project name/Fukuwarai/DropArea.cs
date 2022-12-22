using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData data)
    {
        DragObj dragObj = data.pointerDrag.GetComponent<DragObj>();
     
        if (dragObj != null)
        {
            Debug.Log(gameObject.name + "に" + data.pointerDrag.name + "をドロップ");
        }
    }
}