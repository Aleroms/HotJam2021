using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGFX : MonoBehaviour
{
    private Transform _player;
	private float x, y, z;

	private void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		x = transform.localScale.x;
		y = transform.localScale.y;
		z = transform.localScale.z;
	}
	private void Update()
	{
		if(_player != null)
		{
			if (_player.position.x > transform.position.x)
				transform.localScale = new Vector3(-1f * x, 1f * y, 1f * z);
			else
				transform.localScale = new Vector3(x, y, z);
		}
		
	}
}
