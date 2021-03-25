using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]//used for checkpoints
    private bool puzzle1 = false, puzzle2 = false, puzzle3 = false;

	//[SerializeField]
	//private Transform[] puzzle1Arr, puzzle2Arr, puzzle3Arr;

	private GameManager _gm;
	private PuzzleChecker _puzzleChecker;

	public static PuzzleManager instance;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		_gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (_gm == null) Debug.LogError("gm is null");

		_puzzleChecker = GameObject.Find("PuzzleChecker").GetComponent<PuzzleChecker>();
		if (_puzzleChecker == null) Debug.LogError("puzzlechecker is null");
	}
	public void UpdatePuzzle(int id)
	{
		FindObjectOfType<AudioManager>().Play("Puzzle");

		if(_puzzleChecker.CheckPuzzle())
		{
			switch(id)
			{
				case 1:
					puzzle1 = true;
					break;
				case 2:
					puzzle2 = true;
					break;
				case 3:
					puzzle3 = true;
					break;

			}
			print("puzzle complete >> PuzzleManager");
			
			_puzzleChecker.PuzzleWin();
			NotifyGM();
			
		}
	}

	private void NotifyGM()
	{
		if (puzzle1)
		{
			_gm.PuzzleComplete(1);
			FindObjectOfType<CaveLogic>().PuzzleComplete();
		}
		else if(puzzle2)
		{
			_gm.PuzzleComplete(2);
			FindObjectOfType<CaveLogic>().PuzzleComplete();
		}
		else if(puzzle3)
		{
			_gm.PuzzleComplete(3);
			FindObjectOfType<CaveLogic>().PuzzleComplete();
		}
	}
	

}
//Graveyard code
/*
 /*if(puzzle1Arr[0] != null)
		{
			if (puzzle1Arr[0].rotation.z == 0 &&
			puzzle1Arr[1].rotation.z == 0 &&
			puzzle1Arr[2].rotation.z == 0 &&
			puzzle1Arr[3].rotation.z == 0 &&
			id == 1)
			{
				print("puzzle complete >> PuzzleManager");
				puzzle1 = true;
				NotifyGM();
				PuzzleWin(puzzle1);
			}
		}
		if(puzzle2Arr[0] != null)
		{
			if (puzzle2Arr[0].rotation.z == 0 &&
			puzzle2Arr[1].rotation.z == 0 &&
			puzzle2Arr[2].rotation.z == 0 &&
			puzzle2Arr[3].rotation.z == 0 &&
			id == 2)
			{
				print("puzzle complete >> PuzzleManager");
				puzzle2 = true;
				NotifyGM();
				PuzzleWin(puzzle2);
			}
		}
		if(puzzle3Arr[0] != null)
		{
			print("puzzle3");
			if (puzzle3Arr[0].rotation.z == 0 &&
			puzzle3Arr[1].rotation.z == 0 &&
			puzzle3Arr[2].rotation.z == 0 &&
			puzzle3Arr[3].rotation.z == 0 &&
			id == 3)
			{
				print("puzzle complete >> PuzzleManager");
				puzzle3 = true;
				NotifyGM();
				PuzzleWin(puzzle3);
			}
		}

 private void PuzzleWin(bool id)
	{
		//lock the puzzle piece so player cannot press on it after completion

		if (puzzle1 && puzzle1Arr != null)
		{
			for (int i = 0; i < puzzle1Arr.Length; i++)
			{
				puzzle1Arr[i].transform.gameObject.GetComponent<Puzzle>().PuzzleWin();
			}
		}
		else if(puzzle2 && puzzle2Arr != null)
		{
			for (int i = 0; i < puzzle1Arr.Length; i++)
			{
				puzzle2Arr[i].transform.gameObject.GetComponent<Puzzle>().PuzzleWin();
			}
		}
		else if(puzzle3 && puzzle3Arr != null)
		{
			for (int i = 0; i < puzzle1Arr.Length; i++)
			{
				puzzle3Arr[i].transform.gameObject.GetComponent<Puzzle>().PuzzleWin();
			}
		}
		
		
	}
 
 */

