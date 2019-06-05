using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private Transform _player;
	public bool Follow = true;
	public float ZoomMin = 5;
	public float ZoomMax = 25;
	public float FollowSpeed = 5f;

	private Vector3 _touchStart;
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
		else
		{
			if (Input.GetMouseButtonDown(0))
			{
				_touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}

			if(Input.touchCount == 2)
			{
				Touch touchZero = Input.GetTouch(0);
				Touch touchOne = Input.GetTouch(1);

				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

				float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

				float difference = currentMagnitude - prevMagnitude;

				Zoom(difference * 0.02f);
			}else if (Input.GetMouseButton(0))
			{
				Vector3 direction = _touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Camera.main.transform.position += direction;
			}
		}
		if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 3 && Input.GetTouch(0).phase == TouchPhase.Ended) 
		{
			Follow = !Follow;
		}
	}

	private void Zoom(float increment)
	{
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, ZoomMin, ZoomMax);
	}
}
