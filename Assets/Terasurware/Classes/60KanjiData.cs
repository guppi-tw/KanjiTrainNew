using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class 60KanjiData : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public double id;
		public string kanji;
		public string example;
	}
}