using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private UIManager _UIM;
	private HealthMana _HM;

	[SerializeField]
	private  int health;
	[SerializeField]
	private  int mana;


	public static GameManager instance;

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

		PlayerPrefs.SetInt("Health", health);
		PlayerPrefs.SetInt("Mana", mana);
	}
	private void Start()
	{
		_UIM = GameObject.Find("Canvas").GetComponent<UIManager>();
		if (_UIM == null) Debug.LogError("UIM is null");

		_HM = GameObject.Find("Player").GetComponent<HealthMana>();
		if (_HM == null) Debug.LogError("HM is null");

		

		//_HM.SetHealthMana(health, mana);
		_UIM.SetValues(health,mana);
	}
	public void loadPlayerValues()
	{
		_UIM.SetValues(PlayerPrefs.GetInt("Health"), PlayerPrefs.GetInt("Mana"));
	}/*
	public void SetPlayerValues()
	{
		print("setplayervalues");
		_HM.SetHealthMana(health, mana);
		_UIM.SetValues(health, mana);
	}*/
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
			//use 1 mana
			//activate overlay
			//activate transitional narrative for p1

			case 1://puzzle1
				   
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
