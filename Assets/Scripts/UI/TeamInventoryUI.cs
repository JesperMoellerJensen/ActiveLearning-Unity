using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamInventoryUI : MonoBehaviour
{
	public GameObject teamManager;
	public List<GameObject> inventorySlots;

	private TeamBehavior team;

	// Start is called before the first frame update
	void Start()
    {
		team = teamManager.GetComponent<TeamBehavior>();
	}

	// Update is called once per frame
	void Update()
    {
		int invCount = 0;

		foreach(Resource resource in team.inventory)
		{
			inventorySlots[invCount].GetComponent<SpriteRenderer>().sprite = GetSprite(resource);
			invCount++;
		}

		for(int i = invCount; i < TeamBehavior.INV_MAX_SIZE; i++)
		{
			inventorySlots[i].GetComponent<SpriteRenderer>().sprite = GetSprite(Resource.None);
		}
	}

	private Sprite GetSprite(Resource resource)
	{
		string spriteName = "Invis";

		switch(resource)
		{
			case Resource.Stone:
				spriteName = "Stone";
				break;
			case Resource.Wood:
				spriteName = "Wood";
				break;
			case Resource.Food:
				spriteName = "Food";
				break;
			case Resource.Clay:
				spriteName = "Clay";
				break;
		}

		return Resources.Load<Sprite>($"Sprites/Glitch/{spriteName}");
	}
}
