using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeamBehavior : MonoBehaviour
{
	public static readonly int INV_MAX_SIZE = 6;

	public Castle castle;
	public List<Resource> inventory;

	public int TeamId;
	public bool CanMove = true;

	public int nextQuestionIndex = 0;

	public List<Player> Players { get; private set; }

	void Awake()
    {
		Players =  new List<Player>();
		castle = new Castle();
		inventory = new List<Resource>();
    }

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.E))
		{
			AddInventoryToCastle();
		}
	}

	public void AddPlayer(Player player)
	{
		Players.Add(player);
	}

	public Player GetPlayer(int playerId)
	{
		return Players.First(p => p.PlayerId == playerId);
	}

	public void AddResource(Resource resource)
	{
		if(inventory.Count < INV_MAX_SIZE)
		{
			inventory.Add(resource);
		}
	}

	public void AddInventoryToCastle()
	{
		if(castle.AddResources(inventory.ToArray()))
		{
			Debug.Log($"New level! ({castle.Level})");
		}
		inventory.Clear();
	}
}