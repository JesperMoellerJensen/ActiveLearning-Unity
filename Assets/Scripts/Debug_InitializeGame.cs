using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_InitializeGame : MonoBehaviour
{
	public GameObject PlayerPrefab;
	private void Start()
	{
		Group g1 = new Group { GroupId = 0 };
		AddPlayerToGame("Benny", 0, g1);


		GroupManager.AddGroup(g1);
	}

	private void AddPlayerToGame(string name, int playerId, Group group)
	{
		GameObject go = Instantiate(PlayerPrefab) as GameObject;
		Player p1 = go.GetComponent<Player>();
		p1.PlayerId = playerId;
		p1.Name = name;
		p1.GroupId = group.GroupId;
		p1.Radius = 0.5f;

		group.AddPlayer(p1.GetComponent<Player>());
	}
}
