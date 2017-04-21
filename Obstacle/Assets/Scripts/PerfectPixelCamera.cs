using UnityEngine;
using System.Collections;

public class PerfectPixelCamera : MonoBehaviour {

	private static float pixelsToUnits = 32.0f;
	private static float scale = 1.0f;

	// 32 * 14 = 448
	// So use 15 for columns, and 15 for rows. 15 because this needed padding + centering for the height + width
	// So now the camera position will be (7,7) since 0 is inclusive
	// For background, use 14*32 by 15*32 size.
	private Vector2 nativeResolution = new Vector2 (448, 448);	

	void Awake () {
		Debug.Log ("PerfectPixelCamera: Setting up camera");
		var camera = GetComponent<Camera> ();

		if (camera.orthographic) {
			scale = Screen.height/nativeResolution.y;
			pixelsToUnits *= scale;
			camera.orthographicSize = ((Screen.height) / 2.0f) / pixelsToUnits;
		}
		Debug.Log (camera.WorldToScreenPoint(new Vector2(0,0)));
	}
}
