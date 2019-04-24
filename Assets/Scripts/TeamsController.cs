using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TeamsController : MonoBehaviour
{
	public List<TeamBehavior> Teams;

	private void Awake()
	{
		Teams = new List<TeamBehavior>();
	}
	public void AddTeam(TeamBehavior team)
	{
		Teams.Add(team);
	}

	public TeamBehavior GetTeamById(int teamId)
	{
		return Teams.First(t => t.TeamId == teamId);
	}
}
