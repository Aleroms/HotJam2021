using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMana : MonoBehaviour
{
	[SerializeField]
	private int _health = 5;
	[SerializeField]
	private int _mana = 5;

	private GameManager _gm;
	private UIManager _UIM;
	private void Start()
	{
		_gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (_gm == null) Debug.LogError("GameManager is null");

		_UIM = GameObject.Find("Canvas").GetComponent<UIManager>();
		if (_UIM == null) Debug.LogError("UIM is null");
	}
	public void Damage()
	{
		//deal damage to player; subtract life
		//update UIManager
		//check to see if health = 0; update GameManager

		_health -= 1;
		print("Current Health: " + _health);

		if(_health > -1)
			_UIM.UpdatePlayerHealth(_health);

		if(_health < 1)
		{
			_health = 0;
			_gm.OnPlayerDeath();
			_UIM.OnPlayerDeath();
			Destroy(this.gameObject);
		}
	}
	public void UseMana()
	{
		//use up 1 mana
		//update UI

		_mana -= 1;

		if(_mana > -1)
			_UIM.UpdatePlayerMana(_mana);

		if(_mana < 1)
		{
			print("no mana left");
			_mana = 0;
		}
	}
	public int GetHealth()
	{
		return _health;
	}
	public int GetMana()
	{
		return _mana;
	}
}
