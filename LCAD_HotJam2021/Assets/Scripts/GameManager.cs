using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private UIManager _UIM;
	private HealthMana _HM;

	[SerializeField]
	private int health;
	[SerializeField]
	private int mana;


	private void Start()
	{
		_UIM = GameObject.Find("Canvas").GetComponent<UIManager>();
		if (_UIM == null) Debug.LogError("UIM is null");

		_HM = GameObject.Find("Player").GetComponent<HealthMana>();
		if (_HM == null) Debug.LogError("HM is null");

		_HM.SetHealthMana(health, mana);
		_UIM.SetValues(health,mana);
	}
	public void OnPlayerDeath()
	{
		print("Player Has Died");
		Time.timeScale = 0;
		_UIM.OnPlayerDeath();
	}
	public void PuzzleComplete(int puzzleNum)
	{
		print("PuzzleComplete:" + puzzleNum);
		switch(puzzleNum)
		{
			case 1://puzzle1
				   //update checkpoint to puzzle1
				   //add lives || mana for player
				break;
			case 2://puzzle2
				break;
			case 3://puzzle3
				break;
			default:
				Debug.LogError(puzzleNum + "Not found");
				break;
		}
	}
	
}
