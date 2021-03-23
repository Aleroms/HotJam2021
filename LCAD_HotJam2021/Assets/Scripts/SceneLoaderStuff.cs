using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoaderStuff : MonoBehaviour
{
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
