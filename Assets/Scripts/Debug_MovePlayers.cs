using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_MovePlayers : MonoBehaviour
{
	public TeamsController TeamsController;
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			MovePlayer(0);


	}

	private void MovePlayer(int playerId)
	{
		Player player = TeamsController.Teams[0].GetPlayer(playerId);

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		player.Position = mousePos;
	}
}
