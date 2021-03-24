using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _startTime;
    [SerializeField]
    private float _approachDistance;
    [SerializeField]
    private float _stoppingDistance;
    private float _waitTime;

    private int _randSpot;

    [SerializeField]
    private Transform[] _moveSpots;
    [SerializeField]
    private Transform _target;//the player

    private HealthMana _player;

	private void Start()
	{
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (_target == null) Debug.LogError("target is null");

        _player = GameObject.Find("Player").GetComponent<HealthMana>();
        if (_player == null) Debug.LogError("player is null");

        _waitTime = _startTime;
        _randSpot = Random.Range(0, _moveSpots.Length);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
            //set a timer that makes it so that enemy has to wait f seconds before colliding again
            //call player damage()
            _player.Damage();
            print("collided with player");
		}
	}
	private void FixedUpdate()
	{
        if (Vector2.Distance(transform.position, _target.position) > _approachDistance)
            PatrolArea();
        else
            ApproachPlayer();
	}
    private void PatrolArea()
	{
        transform.position = Vector2.MoveTowards(transform.position, _moveSpots[_randSpot].position, _speed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, _moveSpots[_randSpot].position) < 0.2f)
        {
            if (_waitTime <= 0)
            {
                //update random spot; start moving again
                _randSpot = Random.Range(0, _moveSpots.Length);
                _waitTime = _startTime;
            }
            else
            {
                _waitTime -= Time.fixedDeltaTime;
            }
        }
    }
    private void ApproachPlayer()
	{
        if (Vector2.Distance(transform.position, _target.position) > _stoppingDistance)
		{
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.fixedDeltaTime);
		}

    }
}
