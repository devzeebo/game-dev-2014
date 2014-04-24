using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GUIUtilities {

	private static Dictionary<string, GuiPosition> animations = new Dictionary<string, GuiPosition>();

	private static Vector3 guiScale = new Vector3(1, -1, 1);

	public const int LEFT_TOP = 0;
	public const int LEFT_MID = 1;
	public const int LEFT_BOT = 2;
	public const int MID_TOP = 3;
	public const int MID_MID = 4;
	public const int MID_BOT = 5;
	public const int RIGHT_TOP = 6;
	public const int RIGHT_MID = 7;
	public const int RIGHT_BOT = 8;

	public static Vector3 GuiScreenToWorld(Vector2 pos) {
		Vector3 world = Utilities.ScreenToWorld(pos);
		world.Scale(guiScale);
		return world;
	}

	public static Vector2 WorldToGuiScreen(Vector3 world) {
		Vector2 screen = Utilities.WorldToScreen(world);
		screen.y = Screen.height - screen.y;
		return screen;
	}

	public static Rect AnchoredRect(this MonoBehaviour behaviour, int anchor, float x, float y, float width, float height) {
		switch (anchor) {
			case LEFT_TOP: return LeftTopAnchorRect(x, y, width, height);
			case LEFT_MID: return LeftMidAnchorRect(x, y, width, height);
			case LEFT_BOT: return LeftBotAnchorRect(x, y, width, height);
			case MID_TOP: return MidTopAnchorRect(x, y, width, height);
			case MID_MID: return CenteredRect(behaviour, x, y, width, height);
			case MID_BOT: return MidBotAnchorRect(x, y, width, height);
			case RIGHT_TOP: return RightTopAnchorRect(x, y, width, height);
			case RIGHT_MID: return RightMidAnchorRect(x, y, width, height);
			case RIGHT_BOT: return RightBotAnchorRect(x, y, width, height);
		}
		return new Rect();
	}

	public static Rect LeftTopAnchorRect(float x, float y, float width, float height) {
		return new Rect(x, y, width, height);
	}

	public static Rect LeftMidAnchorRect(float x, float y, float width, float height) {
		return new Rect(x, y - height / 2, width, height);
	}

	public static Rect LeftBotAnchorRect(float x, float y, float width, float height) {
		return new Rect(x, y - height, width, height);
	}
	public static Rect MidTopAnchorRect(float x, float y, float width, float height) {
		return new Rect(x - width / 2, y, width, height);
	}

	public static Rect CenteredRect(this MonoBehaviour behaviour, float x, float y, float width, float height) {
		return new Rect(x - width / 2, y - height / 2, width, height);
	}

	public static Rect MidBotAnchorRect(float x, float y, float width, float height) {
		return new Rect(x - width / 2, y - height, width, height);
	}

	public static Rect RightTopAnchorRect(float x, float y, float width, float height) {
		return new Rect(x - width, y, width, height);
	}

	public static Rect RightMidAnchorRect(float x, float y, float width, float height) {
		return new Rect(x - width, y - height / 2, width, height);
	}

	private static Rect RightBotAnchorRect(float x, float y, float width, float height) {
		return new Rect(x - width, y - height, width, height);
	}

	public static float Width(this MonoBehaviour behaviour, float width) {
		return Width(behaviour, width, Screen.width);
	}

	public static float Width(this MonoBehaviour behaviour, float width, float maxWidth) {
		return width * maxWidth;
	}

	public static float Height(this MonoBehaviour behaviour, float height) {
		return Height(behaviour, height, Screen.height);
	}

	public static float Height(this MonoBehaviour behaviour, float height, float maxHeight) {
		return height * maxHeight;
	}

	public static void Animate(string gui, Vector2 end, float duration) {
		GetGui(gui).SetAnimation(end, duration);
	}

	public static Vector2 GetPosition(string gui) {
		return GetGui(gui).GetPosition();
	}

	public static void SetPosition(string gui, Vector2 position) {
		GetGui(gui).SetPosition(position);
	}

	private static GuiPosition GetGui(string gui) {
		if (!animations.ContainsKey(gui)) {
			animations[gui] = new GuiPosition();
		}
		return animations[gui];
	}

	private class GuiPosition {
		public Vector2 position;

		private bool animating;
		private Vector2 beginAnimation;
		private Vector2 endAnimation;
		private float animationStartTime;
		private float animationEndTime;

		public void SetAnimation(Vector2 end, float duration) {
			beginAnimation = position;
			endAnimation = end;
			animationStartTime = Utilities.GetCurrentTimeMillis();
			animationEndTime = animationStartTime + duration;

			animating = true;
		}

		public void SetPosition(Vector2 position) {
			animating = false;
			this.position = position;
		}

		public void animate() {
			if (animating) {
				if (animationEndTime >= Utilities.GetCurrentTimeMillis()) {
					clearAnimation();
					position = endAnimation;
				}
				else {
					float percent = (animationEndTime - Utilities.GetCurrentTimeMillis()) / (animationEndTime - animationStartTime);
					position = (endAnimation - beginAnimation) * percent + beginAnimation;
				}
			}
		}

		public Vector2 GetPosition() {
			animate();
			return position;
		}

		public void clearAnimation() {
			animating = false;
		}
	}
}
