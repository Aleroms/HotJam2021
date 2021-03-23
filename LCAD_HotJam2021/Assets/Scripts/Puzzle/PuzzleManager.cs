using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]//used for checkpoints
    private bool puzzle1 = false, puzzle2 = false, puzzle3 = false;

	[SerializeField]
	private Transform[] puzzle1Arr;

	private GameManager _gm;

	private void Start()
	{
		_gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (_gm == null) Debug.LogError("gm is null");
	}
	public void UpdatePuzzle()
	{
		CheckPuzzles();
	}
	private void CheckPuzzles()
	{
		/*
		if(Mathf.Approximately(puzzle1Arr[0].rotation.z, 0f)&&
			Mathf.Approximately(puzzle1Arr[1].rotation.z, 0f) &&
			Mathf.Approximately(puzzle1Arr[2].rotation.z, 0f) &&
			Mathf.Approximately(puzzle1Arr[3].rotation.z, 0f))
		{
			print("puzzle complete >> PuzzleManager");
			puzzle1 = true;
			NotifyGM();
			Puzzle1Win();
		}*/

		
		if (puzzle1Arr[0].rotation.z == 0 &&
			puzzle1Arr[1].rotation.z == 0 &&
			puzzle1Arr[2].rotation.z == 0 &&
			puzzle1Arr[3].rotation.z == 0)
		{
			print("puzzle complete >> PuzzleManager");
			puzzle1 = true;
			NotifyGM();
			Puzzle1Win();
		}
	
		

	}

	private void NotifyGM()
	{
		if (puzzle1)
		{
			_gm.PuzzleComplete(1);
			//puzzle1 = false;
		}
		else if(puzzle2)
		{
			_gm.PuzzleComplete(2);
			puzzle2 = false;
		}
		else if(puzzle3)
		{
			_gm.PuzzleComplete(3);
			puzzle3 = false;
		}
	}
	private void Puzzle1Win()
	{
		//lock the puzzle piece so player cannot press on it after completion
		for(int i = 0; i < puzzle1Arr.Length;i++)
		{
			puzzle1Arr[i].transform.gameObject.GetComponent<Puzzle>().PuzzleWin();
		}
	}
}
//Graveyard code
/*
 
 */
