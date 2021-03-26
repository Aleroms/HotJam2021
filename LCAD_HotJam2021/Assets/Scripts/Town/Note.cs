using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField]
    private GameObject _NotePanel;

    [SerializeField]
    private Transform _target;

	private bool _hasPressedButton = false;

	private void OnMouseDown()
	{
		if(!_hasPressedButton)
		{
			_NotePanel.SetActive(true);
			_hasPressedButton = true;
		}
	}
	public void MovePlayer()
	{
        GameObject.Find("Player").GetComponent<Transform>().position = _target.position;
	}
    
}
