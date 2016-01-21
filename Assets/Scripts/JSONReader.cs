using UnityEngine;
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

	public void Start ()
	{
		string kanjiInput = System.IO.File.ReadAllText ("assets/moon_speak.json");
		var parsedInput = JSON.Parse (kanjiInput);
		var levelKanji = parsedInput [UnityEngine.Random.Range (0, parsedInput.Count)];
//		Debug.Log (levelKanji ["kanji"]);
		text = GetComponent<Text> ();
		text.text = levelKanji ["kanji"];  

		radicals = GameObject.FindGameObjectsWithTag ("Radical");
		var radCount = levelKanji ["radicals"].Count;
		var i = 0;

		while (i < radCount) { 

			radicals [i].GetComponent<Text> ().text = levelKanji ["radicals"] [i];

			i = i + 1;

		}
		


	}

}


