using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveLogic : MonoBehaviour
{
	[SerializeField]
	private GameObject _activateText;
	[SerializeField]
	private GameObject _puzzle;
	[SerializeField]
	private GameObject _puzzleComplete;
	[SerializeField]
	private GameObject _caveSolved;

	private bool _insideTrigger = false;
	private bool _isSolved = false;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && _insideTrigger && !_isSolved)
		{
			//print("working");
			_puzzle.SetActive(true);
		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		//player enters activation zone
		if(collision.CompareTag("Player"))
		{
			//print("Activate Rune");
			_insideTrigger = true;
			_activateText.SetActive(true);

			
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		//player leaves activation zone
		if (collision.CompareTag("Player"))
		{
			//print("Leaving trigger zone");
			_insideTrigger = false;
			_activateText.SetActive(false);
			_puzzle.SetActive(false);
		}
	}
	public void PuzzleComplete()
	{
		//print("puzzlecomplete");
		_puzzleComplete.SetActive(true);
		_caveSolved.SetActive(true);
		_activateText.SetActive(false);
		_isSolved = true;
		//gameObject.SetActive(false);
	}
}
