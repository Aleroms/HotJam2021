using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class EndCredits : MonoBehaviour
{
	[SerializeField]
	private Text[] narrative;

	[SerializeField]
	private GameObject logo;

	[SerializeField]
	private float coroutineDuration;


	private void Start()
	{
		StartCoroutine(RollEndCredits());
		
	}
	IEnumerator RollEndCredits()
	{
		yield return new WaitForSeconds(0.8f);

	
		foreach(Text t in narrative)
		{
			StartCoroutine(FadeInOut(t));
			yield return new WaitForSeconds(coroutineDuration*1.5f);
		}

		logo.SetActive(true);

		yield return new WaitForSeconds(coroutineDuration * 1.5f);

		Application.Quit();
		print("quitting");

	}
	IEnumerator FadeInOut(Text textN)
	{
		//fade in and out text 
		textN.gameObject.SetActive(true);
		textN.color = new Color(1f, 1f, 1f, 0f);
		StartCoroutine(AlphaFadeIn(textN));
		yield return new WaitForSeconds(coroutineDuration);
		StartCoroutine(AlphaFadeOut(textN));
		yield return new WaitForSeconds(coroutineDuration);
		textN.gameObject.SetActive(false);
	}
	IEnumerator AlphaFadeIn(Text t)
	{
		float alpha = 0f;

		while(t.color.a < 0.9f)
		{
			alpha += Time.deltaTime;

			t.color = new Color(1f,1f,1f, alpha);

			yield return null;
		}
	}
	IEnumerator AlphaFadeOut(Text t)
	{
		float alpha = 1f;

		while (t.color.a > 0.01f)
		{
			alpha -= Time.deltaTime;

			t.color = new Color(1f, 1f, 1f, alpha);

			yield return null;
		}
	}

}
