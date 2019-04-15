using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Landmark : MonoBehaviour
{
	public float Radius = 3f;
	public float Cooldown = 15f;
	public float CurrentCooldown;

	public Resource LandmarkResource;

	private List<Group> ActiveGroups = new List<Group>();

	private CircleCollider2D _triggerArea;
	private void Awake()
	{
		_triggerArea = GetComponent<CircleCollider2D>();
		InitializeLandmark();
	}

	private void InitializeLandmark()
	{
		LandmarkResource = (Resource)Random.Range(0, System.Enum.GetValues(typeof(Resource)).Length);
		Debug.Log(LandmarkResource.ToString());
	}

	private void GroupOnPoint(Group group)
	{
		Debug.Log(string.Format("Everyone from group {0} is here", group.GroupId));
		ActiveGroups.Add(group);

		//TODO: Implement Questions
		ActiveGroups.Remove(group);
		Debug.Log("You got 1 " + LandmarkResource.ToString());
		OnCooldown();
	}

	private void GroupNotOnPoint(List<Player> players)
	{
		foreach (Player player in players)
		{
			Debug.Log(string.Format("Player {0} is missing", player.Name));
		}
	}

	private void GroupMemberLeavingActiveArea(Group group, Player player)
	{
		Debug.Log(string.Format("Player {0} from group {1} has left the area, please return", player.Name, group.GroupId));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Player player = collision.gameObject.GetComponent<Player>();
		Group group = GroupManager.GetGroupById(player.GroupId);

		List<Player> playersNotOnPoint = group.GetPlayersNotInRadius(transform.position, Radius);
		if (playersNotOnPoint.Count == 0)
		{
			GroupOnPoint(group);
		}
		else
		{
			GroupNotOnPoint(playersNotOnPoint);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Player player = collision.gameObject.GetComponent<Player>();
		Group group = GroupManager.GetGroupById(player.GroupId);

		if (ActiveGroups.Contains(group))
		{
			GroupMemberLeavingActiveArea(group, player);
		}
	}

	private void OnCooldown()
	{
		CurrentCooldown = Cooldown;
		InvokeRepeating("UpdateCooldown", 1, 1);
		Debug.Log("Landmark going on cooldown");
	}

	private void UpdateCooldown()
	{
		CurrentCooldown--;
		UpdateTimer();
		Debug.Log("Cooldown left: " + CurrentCooldown);
		if (CurrentCooldown <= 0)
			OffCooldown();
	}
	private void OffCooldown()
	{
		CancelInvoke("UpdateCooldown");
		Debug.Log("Landmark not longer on cooldown");

	}

	private void UpdateTimer()
	{
		MeshRenderer TimerRendere = GetComponentInChildren<MeshRenderer>();
		TextMeshPro textMeshPro = GetComponentInChildren<TextMeshPro>();
		textMeshPro.text = CurrentCooldown.ToString();
		TimerRendere.material.SetFloat("_Cutoff", (1 - CurrentCooldown / Cooldown));
		Debug.Log("asjdhakjhdkajshd " + (1 - CurrentCooldown / Cooldown));
	}
}
