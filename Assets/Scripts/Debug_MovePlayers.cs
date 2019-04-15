using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_MovePlayers : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			MovePlayer(0);

		if (Input.GetKeyDown(KeyCode.Alpha2))
			MovePlayer(1);

		if (Input.GetKeyDown(KeyCode.Alpha3))
			MovePlayer(2);

	}

	private void MovePlayer(int playerId)
	{
		Player player = GroupManager.Groups[0].GetPlayer(playerId);

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		player.Position = mousePos;
	}
}
