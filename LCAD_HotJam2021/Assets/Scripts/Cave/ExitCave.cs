using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCave : MonoBehaviour
{
	[SerializeField]
	private GameObject exitText;
    private SceneLoaderStuff loaderStuff;
	private bool _insideTrigger = false;
	private void Start()
	{
		loaderStuff = GameObject.Find("SceneLoader").GetComponent<SceneLoaderStuff>();
		if (loaderStuff == null) Debug.LogError("scene loader is null");
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q) && _insideTrigger)
		{
			loaderStuff.LoadLevelByName("MainMenu");
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		print("in trigger");
		if(collision.CompareTag("Player"))
		{
			exitText.SetActive(true);
			_insideTrigger = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			exitText.SetActive(false);
			_insideTrigger = false;
		}
	}
}
