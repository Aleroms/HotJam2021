using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	[SerializeField]
	private GameObject _enemylist;

	private void Start()
	{
		if (PlayerPrefs.GetInt("Gameover") == 1)
			_enemylist.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			FindObjectOfType<GameManager>().Gameover();
		}
	}
}
