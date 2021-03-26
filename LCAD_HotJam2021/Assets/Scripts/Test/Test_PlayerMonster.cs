using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerMonster : MonoBehaviour
{
    //tests to see if player animator controller will change
    //from human animation sprites to monster anim sprites

    public Animator anim;//player's animator
	public SpriteRenderer idle;//changes default sprite renderer to monsteridle
	public Sprite monsterIdle;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.J))
		{
			idle.sprite = monsterIdle;
			anim.SetTrigger("GameOver");
		}
	}
}
