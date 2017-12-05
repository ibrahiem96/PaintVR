using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineManager : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;

	public Material lMat;

	private GraphicLineRenderer line_curr;

	private int clickCounter = 0;

	// Update is called once per frame
	void Update () {
		// draw basic line
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackedObj.index);
		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			//Debug.LogError ("Code reaches controller trigger");
			GameObject go_i = new GameObject ();

			go_i.AddComponent<MeshFilter> ();
			go_i.AddComponent<MeshRenderer> ();
			line_curr = go_i.AddComponent<GraphicLineRenderer> ();

			line_curr.lmat = new Material (lMat);

			line_curr.setWidth (.1f);

			clickCounter = 0;
		} else if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			//line_curr.SetVertexCount (clickCounter + 1);
			//line_curr.SetPosition (clickCounter, trackedObj.transform.position);

			line_curr.AddPoint (trackedObj.transform.position);
			clickCounter++;
		} else if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
		
			clickCounter = 0;

			line_curr = null;
		}


		if (line_curr != null) {
			line_curr.lmat.color = ColorChanger.Instance.GetCurrentColor ();
		}


	}
}
