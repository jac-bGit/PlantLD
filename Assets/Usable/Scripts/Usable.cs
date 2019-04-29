using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : MonoBehaviour {

    [Header("--ACTIONS--")]
    public bool interacted;
    public GameObject abSlot;
    public ActionButton[] actions;

	// Use this for initialization
	protected void OnStart () {
        //get all action buttons
        actions = abSlot.GetComponentsInChildren<ActionButton>();
	}

    // Update is called once per frame
    protected void OnUpdate () {
        showButtons();
	}

    public void showButtons()
    {
        abSlot.SetActive(interacted);
    }

    protected void TriggerEnter (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            interacted = true;
    }

    protected void TriggerExit(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            interacted = false;
    }
}
