using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Group
{
	public int GroupId;
	private List<Player> _players = new List<Player>();
	public Color GroupColor;

	public void AddPlayer(Player player)
	{
		_players.Add(player);
	}

	public Player GetPlayer(int playerId)
	{
		return _players.First(p => p.PlayerId == playerId);
	}

	public List<Player> GetPlayersNotInRadius(Vector2 pointPos, float radius)
	{
		List<Player> playersNotInRadius = new List<Player>();

		foreach (var player in _players)
		{
			if (Vector2.Distance(player.Position, pointPos) > radius + player.Radius)
			{
				playersNotInRadius.Add(player);
			}
		}

		return playersNotInRadius;
	}
}
