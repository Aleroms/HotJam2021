using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    private Animator player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Animator>();

        if(PlayerPrefs.GetInt("Gameover") != -1)
		{
            player.SetTrigger("GameOver");
		}

        print("" + PlayerPrefs.GetInt("Gameover"));
       
    }

}
