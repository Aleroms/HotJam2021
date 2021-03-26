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
	private GameObject Overlay1, Overlay2, Overlay3;
	[SerializeField]
	private GameObject _OnPlayerDeathPanel;

	public static UIManager instance;

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
	public void ToggleOverlay(int id)
	{
		if(id == 1)
		{
			Overlay1.SetActive(true);
		}else if(id == 2)
		{
			Overlay1.SetActive(false);
			Overlay2.SetActive(true);
		}else if(id == 3)
		{
			Overlay2.SetActive(false);
			Overlay3.SetActive(true);
		}
	}
}
