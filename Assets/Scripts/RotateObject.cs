using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	public float AxisX = 0;
	public float AxisY = 0;
	public float AxisZ = 0;
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (AxisX*Time.deltaTime,AxisY*Time.deltaTime,AxisZ*Time.deltaTime);
	
	}
}
