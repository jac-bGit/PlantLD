using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionButton : MonoBehaviour {

    public bool triggered;
    private EventTrigger et;

    private void Start()
    {
        et = GetComponent<EventTrigger>();
    }

    private void OnMouseDown()
    {
        Debug.Log("this works");
        ExecuteEvents.Execute<IPointerClickHandler>(this.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
    }
}
