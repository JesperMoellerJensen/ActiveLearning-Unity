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
	public TeamBehavior Team;
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

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			IInteractable interactable = hit.collider?.gameObject.GetComponent<IInteractable>();
			if (interactable != null)
			{
				interactable.Interact(this);
			}
		}

		if(Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);


			IInteractable interactable = hit.collider?.gameObject.GetComponent<IInteractable>();
			if (interactable != null)
			{
				interactable.Interact(this);
			}
		}

		if(Input.touchCount == 2)
		{
			Touch touch = Input.GetTouch(0);
			Position = Camera.main.ScreenToWorldPoint(touch.position);
		}
	}
}
