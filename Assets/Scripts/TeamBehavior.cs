using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeamBehavior : MonoBehaviour
{
	public static readonly int INV_MAX_SIZE = 6;

	public Castle castle;
	public List<Resource> inventory;

    // Start is called before the first frame update
    void Awake()
    {
		castle = new Castle();
		inventory = new List<Resource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			AddResource(Resource.Stone);
		}

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			AddResource(Resource.Wood);
		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			AddResource(Resource.Food);
		}

		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			AddResource(Resource.Clay);
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			AddInventoryToCastle();
		}
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

	//void OnGUI()
	//{
	//	string printInfo = $"Level: {castle.Level}" + Environment.NewLine;
	//	printInfo += "Team Inventory:" + Environment.NewLine;
	//	for (int i = 0; i < inventory.Count; i++)
	//	{
	//		printInfo += $"{inventory[i].ToString()}" + Environment.NewLine;
	//	}

	//	printInfo += castle.ToString();

	//	GUI.Label(new Rect(10, 10, 500, 500), printInfo);
	//}
}