using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectData : MonoBehaviour {

	public List<Material> cutMaterialsList = new List<Material>();

	private int boardLenght = 40;
	private int boardThickness = 2;
	private int numberOfCuts = 1;

	private bool boardChanged = false;

	private List<int> colorList = new List<int>();
	private List<int> widthList = new List<int>();
	private List<GameObject> cutList = new List<GameObject> ();


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if(boardChanged){
			transform.rotation = new Quaternion(0,0,0,0);
			float sumWidth = 0;
			widthList.ForEach ((i) => {
				sumWidth+=i;
			});

			float maxOffset = -sumWidth / 2;

			Debug.Log ("Width sum: "+sumWidth+", half: "+maxOffset);
			for (int i = 0; i < cutList.Count; i++) {
				//Debug.Log ("Index number: "+i);
				cutList[i].transform.localScale = new Vector3 (widthList[i], boardLenght, boardThickness);
				cutList[i].GetComponent<Renderer> ().material = cutMaterialsList[colorList[i]];
				cutList [i].transform.position = new Vector3 ((maxOffset+widthList[i]), 0, 0);
				maxOffset += widthList [i];
			}

			boardChanged = false;
		}
		
	}

	public void AddNewCut(){
		transform.rotation = new Quaternion(0,0,0,0);
		GameObject newCut = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//newCut.transform.localScale = new Vector3(1,boardLenght,boardThickness);
		newCut.transform.SetParent(transform);
		//newCut.transform.position = Vector3.zero;
		colorList.Add (0);
		widthList.Add (1);
		for (int i = 0; i < colorList.Count; i++) {
			Debug.Log ("color nr"+i+", value:"+colorList[i]);
		}
		for (int i = 0; i < widthList.Count; i++) {
			Debug.Log ("width nr"+i+", value:"+widthList[i]);
		}
		cutList.Add (newCut);
		boardChanged = true;
	}

	public void GetAndSetBoardLenght(string newLength){
		boardLenght = int.Parse(newLength);
		boardChanged = true;
	}

	public void GetAndSetNumberOfCuts(string newNumberOfCuts){
		numberOfCuts = int.Parse(newNumberOfCuts);
		boardChanged = true;
	}

	public void GetAndSetBoardThickness(string newThickness){
		boardThickness = int.Parse(newThickness);
		boardChanged = true;
	}

	public void GetAndSetLineWidth(string newWidth){
		int cutNumberInt = StripNumber(EventSystem.current.currentSelectedGameObject.transform.parent.name);
		int newCutWidth = int.Parse (newWidth);
		widthList[cutNumberInt] = newCutWidth;

	}

	public void GetAndSetLineColour(int newColour){
		int cutNumberInt = StripNumber(EventSystem.current.currentSelectedGameObject.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.name);
		colorList [cutNumberInt] = newColour;


	}


	private int StripNumber(string stringToCut){
		string cutNumber = stringToCut.Replace ("CutSettingsLine","");
		return int.Parse (cutNumber);
	}
}
