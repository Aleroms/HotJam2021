using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthMana : MonoBehaviour
{
    private HealthMana hm;
	private void Start()
	{
		hm = GameObject.Find("Player").GetComponent<HealthMana>();
	}
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
		{
			if(hm != null)
				hm.Damage();
		}
        if(Input.GetKeyDown(KeyCode.E))
		{
			if (hm != null)
				hm.UseMana();
		}
    }
}
