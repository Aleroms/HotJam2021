using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCrossFade : MonoBehaviour
{
	[SerializeField]
	private GameObject crossfade;

    public void Activate()
	{
		crossfade.SetActive(true);
	}
}
