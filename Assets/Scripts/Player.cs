using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	private Vector2 _position;
	private Rigidbody2D _body;

	public int PlayerId;
	public int GroupId;
	public string Name;
	public float Radius;

	public Vector2 Position
	{
		get { return _position; }
		set
		{
			_position = value;
			_body.position = _position;
		}
	}

	private void Awake()
	{
		_body = GetComponent<Rigidbody2D>();
	}
}
