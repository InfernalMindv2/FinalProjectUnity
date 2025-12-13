using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class changeInput : MonoBehaviour {
	EventSystem system;
	public Selectable firstInput;
	public Button submitButton;
	// Use this for initialization
	void Start () {
		system = EventSystem.current;
		firstInput.Select();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.RightShift) &&
			Input.GetKeyDown(KeyCode.Tab))
		{

			Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
			if (previous != null)
			{
				previous.Select();
			}

			return;
		}
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
			if (next != null)
			{
				next.Select();
			}
			return;
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			submitButton.onClick.Invoke();
			Debug.Log("Button pressed!");
		}
	}
}
