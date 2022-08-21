using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Kanji_Data : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public int kanji_id;
		public int grade;
		public string kanji;
		public string bushu;
		public string example;
		public string choices;
	}
}