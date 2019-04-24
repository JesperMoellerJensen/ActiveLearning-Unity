using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{

	public static GPS Instance { get; set; }

	public Vector2 startOffset;

	public float latitude = 0;
	public float longitude = 0;

	public float Multiply = 100;
	public bool isUnityRemote;

	private Player _player;

	private void Start()
	{
		_player = GetComponent<Player>();
		InvokeRepeating("StartRotine", 0, 1);
	}

	private void StartRotine()
	{
		StartCoroutine(StartLocationService());
	}

	private IEnumerator StartLocationService()
	{
		// Wait until the editor and unity remote are connected before starting a location service
		if (isUnityRemote)
		{
			yield return new WaitForSeconds(3);
		}

		if (!Input.location.isEnabledByUser)
		{
			Debug.Log("User has not enabled GPS");
			yield break;
		}

		Input.location.Start();
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		if (maxWait <= 0)
		{
			Debug.Log("Timed Out");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed)
		{
			Debug.Log("Unable to get device location");
			yield break;
		}

		if (startOffset.magnitude == 0)
		{
			startOffset = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
		}
		else
		{
			UpdateLocation();
		}

	}


	private void UpdateLocation()
	{
		if (Input.location.isEnabledByUser && Input.location.status == LocationServiceStatus.Running)
		{
			latitude = (startOffset.x - Input.location.lastData.latitude) * Multiply;
			longitude = (startOffset.y - Input.location.lastData.longitude) * Multiply;

			_player.Position = new Vector2(latitude, longitude);
			print(latitude + "," + longitude + "  |  " + startOffset);
		}
		else
		{
			Debug.Log("No");
		}
	}
}
