using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFade : MonoBehaviour
{
    private Animator _crossFade;
    // Start is called before the first frame update
    void Start()
    {
        _crossFade = GameObject.FindGameObjectWithTag("CrossFade").GetComponent<Animator>();
        if (_crossFade == null) Debug.LogError("crossfade is null");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
            print("Here");
            MakeTransition();
		}
    }
    public void MakeTransition()
	{
        _crossFade = GameObject.FindGameObjectWithTag("CrossFade").GetComponent<Animator>();
        _crossFade.SetTrigger("MakeTransition");
	}
}
