using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{

	public static GPS Instance { get; set; }

	private double startOffsetX = 55.40386792238677d;
	private double startOffsetY = 10.379884476885422d;

	public double latitude = 0;
	public double longitude = 0;

	public float GPSPositionMultiplier = 1;
	public bool isUnityRemote;

	private Player _player;
	private Vector2 startOffset;

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

	private void BeginUpdate()
	{
		if (!Input.location.isEnabledByUser)
		{
			print("GPS not enabled by user");
			return;
		}
	}

		switch (Input.location.status)
		{
			case LocationServiceStatus.Failed:
				StartGPS();
				print("Restarting");
				break;
			case LocationServiceStatus.Initializing:
				print("Initializing...");
				break;
			case LocationServiceStatus.Running:
				UpdateLocation();
				break;
			case LocationServiceStatus.Stopped:
				StartGPS();
				//CancelInvoke("BeginUpdate");
				print("Location service stopped");
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

		_player.Position = new Vector2((float)latitude, (float)longitude);
	}
}
