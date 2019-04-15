using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ResourceRequirement
{
	public int Stone { get; set; }
	public int Wood { get; set; }
	public int Food { get; set; }
	public int Clay { get; set; }

	public ResourceRequirement(int stone, int wood, int food, int clay)
	{
		Stone = stone;
		Wood = wood;
		Food = food;
		Clay = clay;
	}
}

public class Castle
{
	public static readonly ResourceRequirement[] REQ_RESOURCES_PER_LEVEL =
	{
		new ResourceRequirement(2, 3, 2, 0), // Req at level 1
		new ResourceRequirement(3, 3, 3, 0), // Req at level 2
		new ResourceRequirement(4, 0, 4, 2), // Req at level 3
	};

	private int requirementIndex;
	public int Level
	{
		get { return requirementIndex; }
		set
		{
			requirementIndex = Mathf.Clamp(value, 0, REQ_RESOURCES_PER_LEVEL.Length - 1); // Clamp level between possible levels
		}
	}

	public ResourceRequirement inventory;

	public Castle(int level = 0)
	{
		Level = level;

		inventory = new ResourceRequirement();
	}

	private void AddResource(Resource resource)
	{
		switch (resource)
		{
			case Resource.Stone:
				inventory.Stone++;
				break;
			case Resource.Wood:
				inventory.Wood++;
				break;
			case Resource.Food:
				inventory.Food++;
				break;
			case Resource.Clay:
				inventory.Clay++;
				break;
		}
	}

	/// <summary>
	/// Returns true if the added resources completes the required resources for next level.
	/// </summary>
	/// <param name="resources">Resource to add</param>
	/// <returns></returns>
	public bool AddResources(Resource[] resources)
	{
		foreach (Resource resource in resources)
		{
			AddResource(resource);
		}

		return UpdateRequirement();
	}

	/// <summary>
	/// Returns true if the added resources completes the required resources for next level.
	/// </summary>
	/// <returns></returns>
	private bool UpdateRequirement()
	{
		var requiredResources = REQ_RESOURCES_PER_LEVEL[Level];

		// if the added resources completes the required resources for next level, then use resources and advance level.
		if (inventory.Stone >= requiredResources.Stone &&
					inventory.Wood >= requiredResources.Wood &&
					inventory.Food >= requiredResources.Food &&
					inventory.Clay >= requiredResources.Clay)
		{
			inventory.Stone -= requiredResources.Stone;
			inventory.Wood -= requiredResources.Wood;
			inventory.Food -= requiredResources.Food;
			inventory.Clay -= requiredResources.Clay;

			Level++;

			return true;
		}

		return false;
	}

	public override string ToString()
	{
		string result = "Castle resources:" + Environment.NewLine;
		result += $"Stone: {inventory.Stone} / {REQ_RESOURCES_PER_LEVEL[Level].Stone}" + Environment.NewLine;
		result += $"Wood: {inventory.Wood} / {REQ_RESOURCES_PER_LEVEL[Level].Wood}" + Environment.NewLine;
		result += $"Food: {inventory.Food} / {REQ_RESOURCES_PER_LEVEL[Level].Food}" + Environment.NewLine;
		result += $"Clay: {inventory.Clay} / {REQ_RESOURCES_PER_LEVEL[Level].Clay}" + Environment.NewLine;

		return result;
	}
}