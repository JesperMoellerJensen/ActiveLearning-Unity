using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
	private double startOffsetX = 55.40386792238677d;
	private double startOffsetY = 10.379884476885422d;

	public double latitude = 0;
	public double longitude = 0;

	public float Multiply = 100;

	private Player _player;

	private void Start()
	{
		_player = GetComponent<Player>();
		StartGPS();
		InvokeRepeating("BeginUpdate", 0, 0.1f);
	}

	private void StartGPS()
	{
		Input.location.Start(1f, 0.1f);
	}

	private void StopGPSService()
	{
		CancelInvoke("BeginUpdate");
		Input.location.Stop();
	}

	private void BeginUpdate()
	{
		if (!Input.location.isEnabledByUser)
		{
			print("GPS not enabled by user");
			return;
		}

		switch (Input.location.status)
		{
			case LocationServiceStatus.Failed:
				StartGPS();
				Debug.Log("GPS Service Failed");
				break;
			case LocationServiceStatus.Initializing:
				Debug.Log("Initializing GPS Service");
				break;
			case LocationServiceStatus.Running:
				UpdateLocation();
				break;
			case LocationServiceStatus.Stopped:
				StartGPS();
				//CancelInvoke("BeginUpdate");
				Debug.Log("GPS Service Stopped");
				break;
		}
	}

	private void UpdateLocation()
	{
		print("Update");

		latitude = (startOffsetX - Input.location.lastData.latitude) * Multiply;
		longitude = (startOffsetY - Input.location.lastData.longitude) * Multiply;

		string lat = string.Format("{0:0.00}", latitude);
		string lon = string.Format("{0:0.00}", longitude);

		_player.TargetPosition = new Vector2((float)latitude, (float)longitude);
	}
}
