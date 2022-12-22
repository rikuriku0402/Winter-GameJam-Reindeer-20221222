using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData data)
    {
        DragObj dragObj = data.pointerDrag.GetComponent<DragObj>();

        SoundManager.Instance.PlaySFX(SFXType.Drag);

        if (dragObj != null)
        {
            Debug.Log(gameObject.name + "‚É" + data.pointerDrag.name + "‚ğƒhƒƒbƒv");
        }
    }
}