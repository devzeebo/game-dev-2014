using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GUIUtilities {

	private static Dictionary<string, GuiPosition> animations;

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
