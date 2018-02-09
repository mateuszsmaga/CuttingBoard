using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapControlls : MonoBehaviour {

	private List<Color> startcolor = new List<Color>();
	public float rotSpeed = 20;
	void OnMouseDrag()
	{
		float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

		GameObject.Find("CuttingBoard").transform.RotateAround(Vector3.up, -rotX);
		GameObject.Find("CuttingBoard").transform.RotateAround(Vector3.right, rotY);

	}

	void OnMouseEnter()
	{
		for(int i = 0; i<transform.childCount; i++){
			startcolor.Add(transform.GetChild(i).GetComponent<Renderer> ().material.color);
			transform.GetChild(i).GetComponent<Renderer> ().material.color = Color.red;
		}
	}

	void OnMouseOver(){
		//get right mouse button
		if (Input.GetMouseButtonDown (1)) {
			CollectData.isLineSwapped[StripNumber (transform.name)]=!CollectData.isLineSwapped[StripNumber (transform.name)];
			CollectData.boardChanged = true;
		}
	}
	void OnMouseExit()
	{
		for(int i = 0; i<transform.childCount; i++){
			transform.GetChild(i).GetComponent<Renderer> ().material.color = startcolor[i];
		}
		//renderer.material.color = startcolor;
		startcolor.Clear();
	}

	private int StripNumber(string stringToCut){
		string cutNumber = stringToCut.Replace ("swapGroup","");
		return int.Parse (cutNumber);
	}
}
