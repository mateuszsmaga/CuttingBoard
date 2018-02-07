using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectData : MonoBehaviour {

	private int boardLenght = 40;
	private int boardThickness = 2;
	private int numberOfCuts = 1;

	private bool boardChanged = false;

	GameObject board;

	// Use this for initialization
	void Start () {
		board = GameObject.CreatePrimitive(PrimitiveType.Cube);
		board.transform.localScale = new Vector3(50,boardLenght,boardThickness);
		board.transform.SetParent(transform);
		board.transform.position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

		if(boardChanged){
			board.transform.localScale = new Vector3(1,boardLenght,boardThickness);
			boardChanged = false;
		}
		
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
}
