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
	private Text _narrationText;
	[SerializeField]
	private string[] narrative_txt;
	

	[SerializeField]
	private GameObject _CrossFade;
	[SerializeField]
	private GameObject Overlay1, Overlay2, Overlay3;
	[SerializeField]
	private GameObject _OnPlayerDeathPanel;
	[SerializeField]
	private GameObject _GameplayPanel;

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
	public void CrossFade(int puzNum)
	{
		//puzNum = 2;
		_GameplayPanel.SetActive(false);
		_CrossFade.SetActive(true);
		_narrationText.gameObject.SetActive(true);
		StartCoroutine(CrossFadeCoroutine(1.0f));

		if (puzNum == 1)
			_narrationText.text = narrative_txt[0];
		else if(puzNum == 2)
			_narrationText.text = narrative_txt[1];
		else if(puzNum == 3)
			_narrationText.text = narrative_txt[2];

		//idk there's a bug here with the bottom code
		/*
		 print("puzNum" + puzNum);
		StartCoroutine(CrossFadeCoroutine(3.0f));
		FindObjectOfType<CrossFade>().MakeTransition();
		_GameplayPanel.SetActive(true);
		_narrationText.gameObject.SetActive(false);
		 */

	}
	IEnumerator CrossFadeCoroutine(float duration)
	{
		yield return new WaitForSeconds(duration);
	}
}
