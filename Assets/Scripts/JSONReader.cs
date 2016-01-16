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

	public void Awake ()
	{
		string kanjiInput = System.IO.File.ReadAllText ("assets/moon_speak.json");

		var parsedInput = JSON.Parse (kanjiInput);
		Debug.Log (parsedInput.Count);

		var maru = parsedInput [2] ["hiragana"];

//		List<string> keyList = kanjiInput.Keys.ToList();
		Debug.Log (maru);

		text = GetComponent<Text> ();

		text.text = maru [0];



	}


}


