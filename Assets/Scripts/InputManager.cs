using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour ,IPointerDownHandler, IDragHandler
{
    private float _horizontal;
    private bool _firstClick = true;

    

    public void OnDrag(PointerEventData eventData)
    {
        _horizontal= eventData.delta.x;
        EventManager.Trigger(EventList.OnHorizontalDrag, _horizontal);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_firstClick) return;
        EventManager.Trigger(EventList.GameStarted);
        _firstClick = false;
    }
}