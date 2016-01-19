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

	public Text text;

	public void Start ()
	{
		string kanjiInput = System.IO.File.ReadAllText ("assets/sample_dictionary.json");

		var parsedInput = JSON.Parse (kanjiInput);
		
	
		var levelKanji = parsedInput [UnityEngine.Random.Range (0, parsedInput.Count)];
		Debug.Log (levelKanji ["kanji"]);

		text = GetComponent<Text> ();

		text.text = levelKanji ["kanji"];  
		


	}

}


