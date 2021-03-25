using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChecker : MonoBehaviour
{
	[SerializeField]
	private Transform[] puzzle;
	public bool CheckPuzzle()
	{

		if (puzzle[0] != null)
		{
			if (puzzle[0].rotation.z == 0 &&
			puzzle[1].rotation.z == 0 &&
			puzzle[2].rotation.z == 0 &&
			puzzle[3].rotation.z == 0 )
			{
				return true;
			}
		}

		return false;
	}
	public void PuzzleWin()
	{
		for (int i = 0; i < puzzle.Length; i++)
		{
			puzzle[i].transform.gameObject.GetComponent<Puzzle>().PuzzleWin();
		}
	}
}
