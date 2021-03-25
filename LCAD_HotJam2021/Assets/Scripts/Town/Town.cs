using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : SceneLoaderStuff
{
    public Transform _playerSpawn;
    public GameObject player;

    public Transform cave1, cave2, cave3;

    

    // Start is called before the first frame update
    void Start()
    {
        //FindObjectOfType<GameManager>().SetPlayerValues();
        //FindObjectOfType<UIManager>().SetValues(health, mana);
        

        //print(caveID);

        switch(SceneLoaderStuff.caveID)
		{
            case 1:
                //_playerSpawn.position = cave1.position;
                player.transform.position = cave1.position;
                break;
            case 2:
                _playerSpawn.position = cave2.position;
                player.transform.position = cave2.position;
                break;
            case 3:
                _playerSpawn.position = cave3.position;
                player.transform.position = cave3.position;
                break;
           
		}
    }

    
}
