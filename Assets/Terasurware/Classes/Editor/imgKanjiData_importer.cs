using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class imgKanjiData_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/imgKanjiData.xlsx";
	private static readonly string exportPath = "Assets/imgKanjiData.asset";
	private static readonly string[] sheetNames = { "シート1", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			kanji_question_data data = (kanji_question_data)AssetDatabase.LoadAssetAtPath (exportPath, typeof(kanji_question_data));
			if (data == null) {
				data = ScriptableObject.CreateInstance<kanji_question_data> ();
				AssetDatabase.CreateAsset ((ScriptableObject)data, exportPath);
				data.hideFlags = HideFlags.NotEditable;
			}
			
			data.sheets.Clear ();
			using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
				IWorkbook book = null;
				if (Path.GetExtension (filePath) == ".xls") {
					book = new HSSFWorkbook(stream);
				} else {
					book = new XSSFWorkbook(stream);
				}
				
				foreach(string sheetName in sheetNames) {
					ISheet sheet = book.GetSheet(sheetName);
					if( sheet == null ) {
						Debug.LogError("[QuestData] sheet not found:" + sheetName);
						continue;
					}

					kanji_question_data.Sheet s = new kanji_question_data.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						kanji_question_data.Param p = new kanji_question_data.Param ();
						
					cell = row.GetCell(0); p.id = (cell == null ? 0.0 : cell.NumericCellValue);
					cell = row.GetCell(1); p.kanji = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.example = (cell == null ? "" : cell.StringCellValue);
						s.list.Add (p);
					}
					data.sheets.Add(s);
				}
			}

			ScriptableObject obj = AssetDatabase.LoadAssetAtPath (exportPath, typeof(ScriptableObject)) as ScriptableObject;
			EditorUtility.SetDirty (obj);
		}
	}
}
