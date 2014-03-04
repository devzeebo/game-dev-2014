using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InputHandler : MonoBehaviour {
	private static readonly int MOUSE = 10;

	public float InputDeadzone = 0.5f;

	// Touch indexes are 0-9, Mouse is 10
	private List<InputEvent> events;
	public List<InputEvent> Events {
		get { return events.FindAll(e => e.active); }
		private set { events = value; }
	}

	public void Start() {
		Input.simulateMouseWithTouches = false;
		events = new List<InputEvent>();

		for (int i = 0; i < 10; i++) {
			events.Add(new InputEvent(InputEvent.Source.TOUCH));
		}
		events.Add(new InputEvent(InputEvent.Source.MOUSE));
	}

	public void handleInput() {

		foreach (InputEvent e in events) {
			if (e.phase == TouchPhase.Ended) {
				e.active = false;
				e.position = Vector3.zero;
				e.deltaPosition = Vector3.zero;
				e.totalMagnitude = 0.0f;
				e.clickTime = 0;
			}
		}

		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				InputEvent e = events[touch.fingerId];
				e.phase = touch.phase;
				e.position = touch.position;
				e.clickCount = touch.tapCount;
				e.deltaPosition = touch.deltaPosition;
				e.totalMagnitude += touch.deltaPosition.magnitude;
				e.clickTime = Utilities.GetCurrentTimeMillis();
				e.active = true;
			}
		}

		InputEvent me = events[MOUSE];
		if (Input.mousePresent) {

			if (me.active) {
				me.deltaPosition = Input.mousePosition - me.position;

				if (me.deltaPosition.magnitude > InputDeadzone) {
					me.phase = TouchPhase.Moved;
					me.totalMagnitude += me.deltaPosition.magnitude;
				}
				else if (me.phase != TouchPhase.Moved) {
					me.phase = TouchPhase.Stationary;
				}
			}

			if (Input.GetMouseButtonUp(0)) {
				me.phase = TouchPhase.Ended;
			}

			if (Input.GetMouseButtonDown(0)) {
				me.active = true;
				me.clickTime = Utilities.GetCurrentTimeMillis();
				me.phase = TouchPhase.Began;
				me.deltaPosition = Vector3.zero;
			}

			me.position = Input.mousePosition;
		}
	}
}