using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControls : MonoBehaviour {

	public float rotSpeed = 20;
	private float camPosition = -100;

	void Start ()
	{
	}


	void Update () {
		if(camPosition>=-120 && camPosition<=-20){
			if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		    {
		    	Debug.Log("do tyłu");
		    	camPosition-=5;
		        Camera.main.transform.position = new Vector3(0,0,camPosition);
		    }
		    if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		    {
		    	Debug.Log("do przodu");
		    	camPosition+=5;
		        Camera.main.transform.position = new Vector3(0,0,camPosition);
		    }
		} else if(camPosition<=-120){
			if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		    {
		    	Debug.Log("do przodu");
		    	camPosition+=5;
		        Camera.main.transform.position = new Vector3(0,0,camPosition);
		    }
		} else if (camPosition>=-20) {
			if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		    {
		    	Debug.Log("do tyłu");
		    	camPosition-=5;
		        Camera.main.transform.position = new Vector3(0,0,camPosition);
		    }	
		}
	    
	}


    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.right, rotY);
    }
}
