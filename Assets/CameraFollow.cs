using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private Transform _player;
	public bool Follow = true;
	public float Zoom = 5f;
	public float FollowSpeed = 5f;

	private void Start()
	{
		Invoke("LateStart", 0.1f);
	}

	private void LateStart()
	{
		_player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	private void LateUpdate()
	{
		if (Follow && _player != null)
		{
			transform.position = Vector3.Lerp(transform.position, _player.position, FollowSpeed*Time.deltaTime);
		}

		Camera.main.orthographicSize = Zoom;
	}
}
