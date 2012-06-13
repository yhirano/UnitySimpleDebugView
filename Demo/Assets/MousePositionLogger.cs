using UnityEngine;
using System.Collections;

public class MousePositionLogger : MonoBehaviour {

	void Update () {
		Vector3 mousePosition = Input.mousePosition;

		Devu.Log(string.Format("Mouse Position x={0}", mousePosition.x));
		Devu.Log(string.Format("Mouse Position y={0}", mousePosition.y));
		Devu.Log(string.Format("Mouse Position z={0}", mousePosition.z));
	}
}
