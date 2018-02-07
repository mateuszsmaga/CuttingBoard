using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlls : MonoBehaviour {

	private float newLinePosY = 0f;
	private float addButtonPosY = -30f;

	int linesCount = 0;

	public GameObject addButtonObject;

	public void AddButtonOnClick(GameObject menuLinePrefab){
		linesCount++;
		if(linesCount<=12){
			newLinePosY-=40f;
			addButtonPosY-=40f;
			GameObject newMenuLine = Instantiate(menuLinePrefab, new Vector3(0,0,0), Quaternion.identity);
			//newMenuLine.transform.parent = transform;
			newMenuLine.transform.SetParent(transform);
			newMenuLine.transform.localPosition = new Vector3(0, newLinePosY, 0);
			addButtonObject.transform.localPosition = new Vector3(0, addButtonPosY, 0);
		}

		if(linesCount==12){
			Text buttonMessage = addButtonObject.transform.GetChild(0).GetComponent<Text>();
			buttonMessage.text = "Maks elementów";
		}
		

		//menuLinePrefab.transform.parent = transform;
		//Debug.Log("You have clicked the button!");
	}
}
