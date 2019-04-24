using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_InitializeGame : MonoBehaviour
{
	public GameObject PlayerPrefab;
	public TeamsController TeamManager;
	private void Start()
	{
		TeamBehavior team1 = FindObjectOfType<TeamBehavior>();
		print(team1);
		AddPlayerToGame("Benny", 0, team1);


		TeamManager.AddTeam(team1);
	}

	private void AddPlayerToGame(string name, int playerId, TeamBehavior team)
	{
		GameObject go = Instantiate(PlayerPrefab) as GameObject;
		Player p1 = go.GetComponent<Player>();
		p1.PlayerId = playerId;
		p1.Name = name;
		p1.Team = team;
		p1.Radius = 0.5f;

		team.AddPlayer(p1.GetComponent<Player>());
	}
}
