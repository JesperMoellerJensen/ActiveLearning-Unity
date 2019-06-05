using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(TMP_Text))]
public class Landmark : MonoBehaviour, IInteractable
{
	[Range(1, 10)] public float Radius = 3f;
	[Range(1, 100)] public float Cooldown;
	public float CurrentCooldown;
	public bool IsOnCooldown { get { return CurrentCooldown > 0; } }

	public Resource LandmarkResource;
	public List<TeamBehavior> TeamsOnLandmark = new List<TeamBehavior>();

	private SpriteRenderer _sprite;

	private TeamBehavior _activeTeam;
	private CircleCollider2D _triggerArea;
	private TMP_Text _timerText;
	private MeshRenderer _timerMesh;

	private QuestionUI _question;

	private void Awake()
	{
		_sprite = GetComponentsInChildren<SpriteRenderer>()[0];
		_triggerArea = GetComponent<CircleCollider2D>();
		InitializeLandmark();

		_timerText = GetComponentInChildren<TMP_Text>();
		_timerMesh = GetComponentInChildren<MeshRenderer>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		Player player = collision.gameObject.GetComponent<Player>();

		List<Player> playersNotOnPoint = GetPlayersNotInRadius(transform.position, Radius, player.Team);
		if (playersNotOnPoint.Count == 0)
		{
			TeamOnPoint(player.Team);
		}
		else
		{
			GroupNotOnPoint(playersNotOnPoint);
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		Player player = collision.gameObject.GetComponent<Player>();
		TeamsOnLandmark.Remove(player.Team);

		if (_activeTeam == player.Team)
		{
			GroupMemberLeavingActiveArea(player.Team, player);
		}
	}


	private void InitializeLandmark()
	{
		LandmarkResource = (Resource)Random.Range(0, System.Enum.GetValues(typeof(Resource)).Length-1);
		_sprite.sprite = Resources.Load<Sprite>("Sprites/Glitch/" + LandmarkResource.ToString());
	}

	private void TeamOnPoint(TeamBehavior team)
	{
		TeamsOnLandmark.Add(team);
	}

	private void GroupNotOnPoint(List<Player> players)
	{
		foreach (Player player in players)
		{
			Debug.Log(string.Format("Player {0} is missing", player.Name));
		}
	}

	private void GroupMemberLeavingActiveArea(TeamBehavior team, Player player)
	{
		//TODO: Implement Popup when players are leaving landmark while active.
	}

	public List<Player> GetPlayersNotInRadius(Vector2 pointPos, float radius, TeamBehavior team)
	{
		List<Player> _players = team.Players;
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

	private void OnCooldown()
	{
		CurrentCooldown = Cooldown-0.001f;
		_timerMesh.enabled = true;
		UpdateTimer();
		InvokeRepeating("UpdateCooldown", 1, 1);
		_sprite.sprite = null;
		_timerText.text = Cooldown.ToString();
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
		_timerText.text = "";
		_timerMesh.enabled = false;

	}

	private void UpdateTimer()
	{
		_timerText.text = CurrentCooldown.ToString();
		_timerMesh.material.SetFloat("_Cutoff", (1 - CurrentCooldown / Cooldown));
	}

	public void Interact(Player player)
	{
		if (TeamsOnLandmark.Contains(player.Team) && _activeTeam == null && IsOnCooldown == false)
		{
			_activeTeam = player.Team;
			StartQuestion();
		}
	}

	public void StartQuestion()
	{
		_activeTeam.CanMove = false;

		QuestionUI question = Instantiate(Resources.Load<GameObject>("Prefabs/Question"), GameObject.FindGameObjectWithTag("Canvas").transform).GetComponent<QuestionUI>();

		question.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
		question.resourceType = LandmarkResource;

		question.onCorrectAnswer.AddListener(delegate ()
		{
			_activeTeam.AddResource(LandmarkResource);
		});

		question.onDone.AddListener(delegate ()
		{
			_activeTeam.CanMove = true;
			_activeTeam = null;
			OnCooldown();
			Destroy(question.gameObject);
		});

	}
}
