using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Landmark : MonoBehaviour
{
	public float Radius = 3f;

	private List<Group> ActiveGroups = new List<Group>();

	private CircleCollider2D _triggerArea;
	private void Awake()
	{
		_triggerArea = GetComponent<CircleCollider2D>();
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

	private void GroupOnPoint(Group group)
	{
		Debug.Log(string.Format("Everyone from group {0} is here", group.GroupId));
		ActiveGroups.Add(group);

		//TODO: Implement Questions
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

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, Radius);
	}
}
