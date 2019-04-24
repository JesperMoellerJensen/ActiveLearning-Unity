using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(TMP_Text))]
public class Landmark : MonoBehaviour
{
	[Range(1, 10)] public float Radius = 3f;
	[Range(1, 100)] public float Cooldown;
	public float CurrentCooldown;
	public bool IsOnCooldown { get { return CurrentCooldown > 0; } }

	public Resource LandmarkResource;

	private List<Group> ActiveGroups = new List<Group>();
	private CircleCollider2D _triggerArea;
	private TMP_Text timerText;
	private MeshRenderer timerMesh;

	private void Awake()
	{
		_triggerArea = GetComponent<CircleCollider2D>();
		InitializeLandmark();

		timerText = GetComponentInChildren<TMP_Text>();
		timerMesh = GetComponentInChildren<MeshRenderer>();
	}

	private void InitializeLandmark()
	{
		LandmarkResource = (Resource)Random.Range(0, System.Enum.GetValues(typeof(Resource)).Length-1);
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Glitch/" + LandmarkResource.ToString());
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
		if (IsOnCooldown)
		{
			return;
		}

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
		CurrentCooldown = Cooldown-0.001f;
		timerMesh.enabled = true;
		UpdateTimer();
		InvokeRepeating("UpdateCooldown", 1, 1);
		timerText.text = Cooldown.ToString();
	}

	private void UpdateCooldown()
	{
		CurrentCooldown = Mathf.Round(CurrentCooldown-1);
		UpdateTimer();
		if (CurrentCooldown <= 0)
			OffCooldown();
	}

	private void OffCooldown()
	{
		InitializeLandmark();
		CancelInvoke("UpdateCooldown");
		timerText.text = "";
		timerMesh.enabled = false;

	}

	private void UpdateTimer()
	{
		timerText.text = CurrentCooldown.ToString();
		timerMesh.material.SetFloat("_Cutoff", (1 - CurrentCooldown / Cooldown));
	}
}
