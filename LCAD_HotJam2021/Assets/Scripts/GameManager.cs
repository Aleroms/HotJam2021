using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private UIManager _UIM;
	private HealthMana _HM;
	private AudioManager _AM;

	[SerializeField]
	private  int health;
	[SerializeField]
	private  int mana;
	private int puzzleCounterComplete;

	public bool _isGameOver;

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
		PlayerPrefs.SetInt("Gameover", -1);
	}
	private void Start()
	{
		_UIM = GameObject.Find("Canvas").GetComponent<UIManager>();
		if (_UIM == null) Debug.LogError("UIM is null");

		_HM = GameObject.Find("Player").GetComponent<HealthMana>();
		if (_HM == null) Debug.LogError("HM is null");

		_AM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		if (_AM == null) Debug.LogError("audio manager is null");

		//_HM.SetHealthMana(health, mana);
		_UIM.SetValues(health,mana);
		puzzleCounterComplete = 0;
		_isGameOver = false;
	}
	public void loadPlayerValues()
	{
		_UIM.SetValues(PlayerPrefs.GetInt("Health"), PlayerPrefs.GetInt("Mana"));
	}
	public void OnPlayerDeath()
	{
		print("Player Has Died");
		Time.timeScale = 0;
		_UIM.OnPlayerDeath();
	}
	public void PuzzleComplete(int puzzleNum)
	{
		print(puzzleCounterComplete);
		print("PuzzleComplete:" + puzzleNum);
		
		_HM.UseMana();
		_AM.Play("PlayerDamage");
		_UIM.CrossFade(puzzleCounterComplete);//puznum
		puzzleCounterComplete++;
		_UIM.ToggleOverlay(puzzleCounterComplete);

		if (puzzleCounterComplete == 3)//Game Over
		{
			PlayerPrefs.SetInt("Gameover", 1);
			_isGameOver = true;
		}
		
	}
	public void Gameover()
	{
		if (_isGameOver)
		{
			_UIM.GameoverUI();
			_UIM.LoadLevelByName("Credits");

		}
	}
	
}
