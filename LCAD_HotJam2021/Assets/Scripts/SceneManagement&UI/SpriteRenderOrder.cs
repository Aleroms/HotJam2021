using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRenderOrder : MonoBehaviour
{
    public SpriteRenderer houseSprite;
	public Transform housePos;

    public SpriteRenderer playerSprite;
    public Transform playerPos;

	private void Update()
	{
		if (playerPos.position.y > housePos.position.y)
			houseSprite.sortingOrder = 52;
		else
			houseSprite.sortingOrder = 49;
		//if player y > house y
		//order = 52 
		//else
		//order = 49
	}
}
