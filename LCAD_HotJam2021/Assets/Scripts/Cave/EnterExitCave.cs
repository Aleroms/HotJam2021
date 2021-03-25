using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitCave : MonoBehaviour
{
	[SerializeField]
	private GameObject _text;

    private SceneLoaderStuff loaderStuff;
	private GameManager _gm;

	private bool _insideTrigger = false;

	[SerializeField]
	private int _caveID;

	[SerializeField]
	private string levelName;

	private Transform _player;

	private HealthMana _HM;

	private void Start()
	{
		loaderStuff = GameObject.Find("SceneLoader").GetComponent<SceneLoaderStuff>();
		if (loaderStuff == null) Debug.LogError("scene loader is null");

		_gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (_gm == null) Debug.LogError("gm is null");

		_HM = GameObject.Find("Player").GetComponent<HealthMana>();
		if (_HM == null) Debug.LogError("HM is null");
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q) && _insideTrigger)
		{
			print("health" + CarryOverPlayerInfo.health);
			FindObjectOfType<UIManager>().UpdatePlayerHealth(CarryOverPlayerInfo.health);

			loaderStuff.PlayerPosition(_player, _caveID);

			print("playerID" + _player.position + "\nCaveID:" + _caveID);

			_gm.loadPlayerValues();
			

			loaderStuff.LoadLevelByName(levelName);
			
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		_player = collision.transform;

		if(collision.CompareTag("Player"))
		{
			//print("in trigger");
			_text.SetActive(true);
			_insideTrigger = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_text.SetActive(false);
			_insideTrigger = false;
		}
	}
}
