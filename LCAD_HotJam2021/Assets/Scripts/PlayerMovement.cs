using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5f;
    
    private Rigidbody2D _rb;

    private Vector2 movement;

    private Animator _animator;

    void Start()
    {
        _rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        _animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

	private void Update()
	{
        //used to register input

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);
        _animator.SetFloat("Speed", movement.sqrMagnitude);
	}
	// Update is called once per frame
	private void FixedUpdate()
    {
        //used for physics

        _rb.MovePosition(_rb.position + movement * _playerSpeed * Time.fixedDeltaTime);
    }
}
