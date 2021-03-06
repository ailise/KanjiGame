﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;
using System.Linq;


public class JSONReader : MonoBehaviour
{
	public GameObject[] radicals;
	public Text text;

	public Text radical;

	private string[] answers;

	JSONNode parsedInput;

	public void Start ()
	{
		answers = new string[2];
		string kanjiInput = System.IO.File.ReadAllText ("assets/moon_speak.json");
		parsedInput = JSON.Parse (kanjiInput);
		populateLevel();

	}

	void Update() {
		// I am completely sure there is a better way to do this

		Debug.Log(radicals[0].transform.parent.GetComponent<DragHandler>());
		if(Input.GetMouseButtonUp(0) && radicals[0].transform.position.x > 600 && radicals[1].transform.position.x > 600) {
			string answer1 = radicals[0].GetComponent<Text>().text;
			string answer2 = radicals[1].GetComponent<Text>().text;
			Debug.Log(radicals[0].transform.position);
			bool found1stRad = false;
			bool found2ndRad = false;
			for(int i = 0; i < radicals.Count(); i++){
				if(answer1 == answers[0]){
					found1stRad = true;
					//Debug.Log("first rad is right");
				}
				if(answer2 == answers[1]){
					found2ndRad = true;
					//Debug.Log("second rad is right");
				}
			}

			if(found1stRad && found2ndRad){
				Debug.Log("Correct!");
				radicals[0].transform.parent.SetParent(null);
				radicals[1].transform.parent.SetParent(null);
				GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");
				for(int i = 0; i < slots.Length; i++) {
					if(slots[i].gameObject.transform.childCount == 0) {
						if(radicals[0].transform.parent.parent == null) {
							radicals[0].transform.parent.SetParent(slots[i].gameObject.transform);
						}
						else {
							radicals[1].transform.parent.SetParent(slots[i].gameObject.transform);
							break;
						}
					}
				}
				populateLevel();
				}
		}
	}

	void populateLevel(){
		var levelKanji = parsedInput [UnityEngine.Random.Range (0, parsedInput.Count)];
		//		Debug.Log (levelKanji ["kanji"]);
		text = GetComponent<Text> ();
		text.text = levelKanji ["kanji"];

		radicals = GameObject.FindGameObjectsWithTag ("Radical");
		var radCount = levelKanji ["radicals"].Count;
		var i = 0;

		//answers = levelKanji["radicals"];

		while (i < radCount) { 

			radicals [i].GetComponent<Text> ().text = levelKanji ["radicals"] [i];
			if(i < 2) {
				Debug.Log(levelKanji["radicals"][i]);
				answers[i] = levelKanji["radicals"][i];
				Debug.Log(answers[i]);
			}
			i = i + 1;

		}
	}

}


