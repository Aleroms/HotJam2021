using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
	private PuzzleManager _pm;

	private bool _isComplete = false;

	private float[] _randRotation = {90,180,270 };

	private void Start()
	{
		_pm = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
		//int rand = Random.Range(0, _randRotation.Length);
		//print(rand);
		//transform.Rotate(0f, 0f, _randRotation[rand]);
	}
	private void OnMouseDown()
	{
		if(!_isComplete)
		{
			transform.Rotate(0f, 0f, 90f);
			_pm.UpdatePuzzle();
		}
	}
	public void PuzzleWin()
	{
		print("puzzle completed. Puzzle locked. Player cannot keep pressing on puzzle piece");
		_isComplete = true;
	}
}
