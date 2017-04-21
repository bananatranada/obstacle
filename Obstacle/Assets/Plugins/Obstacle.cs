using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SimpleJSON;

// parses and converts to something that reads bottom row first

// water aka map (visual)
//11111111111
//11000000011
//11000000011
//11000000011
//11000000011
//11000000011
//11000000011
//11000000011
//11000000011
//11000000011
//11111111111


// NOTE: need to verify that the timeframe and total_time matches



public class Obstacle {

	private float totalTime;
	private int rows = 9;
	private int columns = 7;
	private List<List<List<char>>> timeframes = new List<List<List<char>>> ();

	// read bottom up
	private List<List<char>> walls = new List<List<char>> ();
//	private char[][] walls = new char[11,11] {
//		{ '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1' },
//		{ '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' },
//		{ '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' },
//		{ '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' },
//		{ '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' },
//		{ '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' },
//		{ '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' },
//		{ '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' },
//		{ '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' },
//		{ '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' },
//		{ '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1' }
//	};

	public Obstacle(string json) {
		var jsonObj = JSON.Parse (json);

		totalTime = jsonObj ["total_time"].AsFloat;
//		rows = jsonObj ["rows"].AsInt;
//		columns = jsonObj ["columns"].AsInt;

		var timeframes0 = jsonObj["timeframes"];
		for (int i = 0; i < timeframes0.Count; i++) {
			var chars = Regex.Replace(timeframes0[i].Value, @"\s+", "").ToLower();
//				Debug.Log(chars);
			var list0 = new List<List<char>>();
			for (int r = rows-1; r >= 0 ; r--) {
				var list = new List<char> ();
				for (int c = 0; c < columns; c++) {
					list.Add (chars[r*columns + c]);
				}
				list0.Add (list);
			}
			timeframes.Add (list0);
		}





		// build original walls (read bottom up)
		walls.Add (new List<char> { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1' }); //bottom
		walls.Add (new List<char> { '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' });
		walls.Add (new List<char> { '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' });
		walls.Add (new List<char> { '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' });
		walls.Add (new List<char> { '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' });
		walls.Add (new List<char> { '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' });
		walls.Add (new List<char> { '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' });
		walls.Add (new List<char> { '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' });
		walls.Add (new List<char> { '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' });
		walls.Add (new List<char> { '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '1' });
		walls.Add (new List<char> { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1' }); //top

		// if it has a 0 next to the word, it means that it's temp (subset of walls)

		// merge with the water (convert to bottom up array first)
		var walls0 = new List<List<char>> ();
		var wallsString0 = jsonObj ["walls"];
		var wallsRowString0 = Regex.Replace(wallsString0.Value, @"\s+", "").ToLower();
		for (int r = rows-1; r >= 0 ; r--) {
			var wallsRow = new List<char>();
			for (int c = 0; c < columns; c++) {
				wallsRow.Add (wallsRowString0[r*columns + c]);
//				walls[r+1][c+2] = wallsRowString0[r*columns+c];
			}
			walls0.Add (wallsRow);
		}


		for (int i = 0; i < walls0.Count; i++) {
			for (int j = 0; j < walls0[0].Count; j++) {
				if (walls0[i][j] == '1') {
					walls[i+1][j+2] = '1';
				}
			}
		}

		var str = "";
		for (int i = walls.Count-1; i >= 0; i--) {
			for (int j = 0; j < walls[i].Count; j++) {
				str += walls[i][j];
			}
			str += '\n';
		}
		Debug.Log (str);

	




	}

	public List<List<List<char>>> GetTimeframes() {
		return timeframes;
	}

	public float GetTotalTime() {
		return totalTime;
	}
}

public static class ObstacleBuilder {
	public static Obstacle Build(string json) {
		return new Obstacle(json);
	}
}


