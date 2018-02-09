using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlls : MonoBehaviour {

	private static float newLinePosY = 0f;
	private static float addButtonPosY = -30f;

	private static int linesCount = 0;

	public GameObject addButtonObject;
	public GameObject removeButtonObject;

	public void AddButtonOnClick(GameObject menuLinePrefab){
		if (linesCount == 0) {
			removeButtonObject.GetComponent<Button> ().interactable = true;
		}
		linesCount++;
		if(linesCount<=12){
			newLinePosY-=40f;
			addButtonPosY-=40f;
			GameObject newMenuLine = Instantiate(menuLinePrefab, new Vector3(0,0,0), Quaternion.identity);
			//newMenuLine.transform.parent = transform;
			newMenuLine.transform.SetParent(transform);
			newMenuLine.name = "CutSettingsLine" + (linesCount - 1);
			newMenuLine.transform.localPosition = new Vector3(0, newLinePosY, 0);
			addButtonObject.transform.localPosition = new Vector3(0, addButtonPosY, 0);
			removeButtonObject.transform.localPosition = new Vector3(100, addButtonPosY, 0);
		}

		if(linesCount==12){
			Text buttonMessage = addButtonObject.transform.GetChild(0).GetComponent<Text>();
			buttonMessage.text = "Maks elementów";
		}
		

		//menuLinePrefab.transform.parent = transform;
		//Debug.Log("You have clicked the button!");
	}

	public void RemoveButtonOnClickMoveBack(){
		GameObject.Destroy(GameObject.Find ("CutSettingsLine" + (linesCount - 1)));
		linesCount--;
		addButtonPosY+=40f;
		newLinePosY+=40f;
		if (linesCount == 0) {
			removeButtonObject.GetComponent<Button> ().interactable = false;
			addButtonObject.transform.localPosition = new Vector3(0, -40, 0);
			removeButtonObject.transform.localPosition = new Vector3(100, -40, 0);
			addButtonPosY=-30f;
		} else {
			addButtonObject.transform.localPosition = new Vector3(0, addButtonPosY, 0);
			removeButtonObject.transform.localPosition = new Vector3(100, addButtonPosY, 0);
		}


	}


}
