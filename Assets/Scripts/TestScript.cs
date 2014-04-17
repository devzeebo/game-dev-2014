using UnityEngine;
using UnityEditor;
using System.Collections;

[InitializeOnLoad]
public static class TestScript {
	[MenuItem("Edit/Play-Unplay, But From Prelaunch Scene %0")]
	public static void PlayFromPrelaunchScene() {
		if (EditorApplication.isPlaying == true) {
			EditorApplication.isPlaying = false;
			return;
		}

		EditorApplication.SaveCurrentSceneIfUserWantsTo();
		EditorApplication.OpenScene("Assets/Scenes/Splash Screen.unity");
		EditorApplication.isPlaying = true;
	}
}
