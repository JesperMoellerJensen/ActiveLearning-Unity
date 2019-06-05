using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_MovePlayers : MonoBehaviour
{
	public TeamsController TeamsController;

	private TeamBehavior _teamToMove;

	private void Start()
	{
		_teamToMove = TeamsController.Teams[0];
	}

	private void Update()
	{
		if (_teamToMove.CanMove && Input.GetKeyDown(KeyCode.Alpha1))
		{
			MovePlayer(0);
			
		}
	}

	private void MovePlayer(int playerId)
	{
		Player player = _teamToMove.GetPlayer(0);

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		player.TargetPosition = mousePos;
	}
}
