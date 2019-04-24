using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_MovePlayers : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
			MovePlayer(0);

	}

	private void MovePlayer(int playerId)
	{
		Player player = GroupManager.Groups[0].GetPlayer(playerId);

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		player.Position = mousePos;
	}
}
