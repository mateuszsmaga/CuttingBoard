using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectData : MonoBehaviour {

	public List<Material> cutMaterialsList = new List<Material>();

	public GameObject swapGroup;

	//all current board settings
	private int boardLenght = 40;
	private int boardThickness = 2;
	private int numberOfCuts = 1;
	private int stripsCount = 0;
	public static bool boardChanged = false;
	private static List<int> colorList = new List<int>();
	private static List<int> widthList = new List<int>();
	public static List<bool> isLineSwapped = new List<bool>();
	//private static List<GameObject> cutList = new List<GameObject> ();

	void Start () {
		isLineSwapped.Add (false);
	}
		
	void Update () {
		//rebuild the board
		if(boardChanged){
			Quaternion saveRotation = transform.rotation;
			transform.rotation = new Quaternion(0,0,0,0);

			//clear all previous children
			foreach (Transform child in transform) {
				GameObject.Destroy(child.gameObject);
			}

			float sumWidth = 0;
			widthList.ForEach ((i) => {
				sumWidth+=i;
			});



			float maxOffsetY = (float)boardLenght / 2;

			float cutOffsetY = (float)boardLenght / numberOfCuts;

			//Debug.Log ("offset: " + maxOffsetY + ", cutOffset: " + cutOffsetY);

			for (int j = 0; j < numberOfCuts; j++) {
				float maxOffsetX = -sumWidth / 2;
				GameObject newSwapGroup = Instantiate (swapGroup);
				newSwapGroup.name = "swapGroup" + j;
				newSwapGroup.transform.SetParent (transform);
				for (int i = 0; i < stripsCount; i++) {
					GameObject newElement = GameObject.CreatePrimitive(PrimitiveType.Cube);
					newElement.transform.SetParent (newSwapGroup.transform);
					newElement.transform.localScale = new Vector3 (widthList[i], cutOffsetY, boardThickness);
					newElement.GetComponent<Renderer> ().material = cutMaterialsList[colorList[i]];
					float cutPositionX = (float)widthList [i] / 2;
					if (isLineSwapped[j]) {
						newElement.transform.position = new Vector3 (-(maxOffsetX+cutPositionX), (maxOffsetY-cutOffsetY/2), 0);
					} else {
						newElement.transform.position = new Vector3 ((maxOffsetX+cutPositionX), (maxOffsetY-cutOffsetY/2), 0);
					}

					//Debug.Log ("offset:" + (maxOffsetY-cutOffsetY/2));
					maxOffsetX += widthList [i];
					newElement.name = "CutStrip" + i + "Line" + j;
				}
				maxOffsetY -= cutOffsetY;
			}

			transform.rotation = saveRotation;
			boardChanged = false;
		}
		
	}

	public void AddNewCut(){
		widthList.Add (1);
		colorList.Add (0);
		stripsCount++;
		boardChanged = true;
	}

	public void RemoveLastCut(){
		widthList.RemoveAt (widthList.Count - 1);
		colorList.RemoveAt (colorList.Count - 1);
		stripsCount--;
		boardChanged = true;
	}

	public void GetAndSetBoardLenght(string newLength){
		boardLenght = int.Parse(newLength);
		boardChanged = true;
	}

	public void GetAndSetNumberOfCuts(string newNumberOfCuts){
		int oldNumberOfCuts = numberOfCuts;
		numberOfCuts = int.Parse(newNumberOfCuts);
		Debug.Log ("nofc:" + numberOfCuts + ",onofc" + oldNumberOfCuts);
		if (numberOfCuts > oldNumberOfCuts) {
			for (int i = 0; i < (numberOfCuts - oldNumberOfCuts); i++) {
				Debug.Log("AddLines:"+i);
				isLineSwapped.Add (false);s
			}
			boardChanged = true;
		} else if (numberOfCuts < oldNumberOfCuts) {
			for (int i = oldNumberOfCuts-1; i >numberOfCuts-1; i--) {
				Debug.Log("RemoveLines:"+i);
				isLineSwapped.RemoveAt (i);
			}
			boardChanged = true;
		}
	

	}

	public void GetAndSetBoardThickness(string newThickness){
		boardThickness = int.Parse(newThickness);
		boardChanged = true;
	}

	public void GetAndSetLineWidth(string newWidth){
		int cutNumberInt = StripNumber(EventSystem.current.currentSelectedGameObject.transform.parent.name);
		int newCutWidth = int.Parse (newWidth);
		widthList[cutNumberInt] = newCutWidth;
		boardChanged = true;
	}

	public void GetAndSetLineColour(int newColour){
		int cutNumberInt = StripNumber(EventSystem.current.currentSelectedGameObject.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.name);
		colorList [cutNumberInt] = newColour;
		boardChanged = true;
	}


	private int StripNumber(string stringToCut){
		string cutNumber = stringToCut.Replace ("CutSettingsLine","");
		return int.Parse (cutNumber);
	}
}
