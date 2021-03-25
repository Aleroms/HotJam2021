using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private Image _healthDisplay;
	[SerializeField]
	private Image _manaDisplay;

	[SerializeField]
	private Sprite[] _health;
	[SerializeField]
	private Sprite[] _mana;

	[SerializeField]
	private GameObject _OnPlayerDeathPanel;

	
	public void SetValues(int h, int m)
	{
		_healthDisplay.sprite = _health[h];
		_manaDisplay.sprite = _mana[m];
	}

	public void UpdatePlayerHealth(int h)
	{
		_healthDisplay.sprite = _health[h];
	}
	public void UpdatePlayerMana(int m)
	{
		_manaDisplay.sprite = _mana[m];
	}
	public void OnPlayerDeath()
	{
		_OnPlayerDeathPanel.SetActive(true);
	}
	public void LoadLevelByName(string name)
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(name);
	}
}
