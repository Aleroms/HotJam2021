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

    private AudioSource _audioSource;

    private bool _isMoving = false;

    void Start()
    {
        _rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        _animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null) Debug.LogError("audio src null");
    }

	private void Update()
	{
        //used to register input

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);
        _animator.SetFloat("Speed", movement.sqrMagnitude);

        //audio
        if (movement.x != 0 || movement.y != 0)
            _isMoving = true;
        else
            _isMoving = false;

        if (_isMoving)
        {
            if (!_audioSource.isPlaying)
                _audioSource.Play();
        }
        else
            _audioSource.Stop();
            
	}
	// Update is called once per frame
	private void FixedUpdate()
    {
        //used for physics

        _rb.MovePosition(_rb.position + movement * _playerSpeed * Time.fixedDeltaTime);
    }
}
