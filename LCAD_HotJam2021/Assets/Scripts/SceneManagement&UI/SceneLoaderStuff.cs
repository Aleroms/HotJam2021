using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoaderStuff : MonoBehaviour
{
	protected static Transform playerPosition;
	protected static int caveID;

	public static SceneLoaderStuff instance;

	
	public  void PlayerPosition(Transform pl, int cid)
	{
		print("here");
		playerPosition = pl;
		caveID = cid;

		print("playerID" + playerPosition.position + "\nCaveID:" + caveID);

	}
	public void ReloadCurrentLevel()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void LoadLevelByName(string name)
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(name);
	}
	public void QuitGame()
	{
		print("Quitting");
		Application.Quit();
	}
}
