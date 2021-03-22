using System.Collections;
using System.Collections.Generic;
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

	private void Start()
	{
		_healthDisplay.sprite = _health[5];
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

	}
}
