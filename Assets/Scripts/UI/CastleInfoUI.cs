using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastleInfoUI : MonoBehaviour
{
	public GameObject teamManager;
	public List<GameObject> castleLevels;
	public GameObject stoneCount;
	public GameObject woodCount;
	public GameObject foodCount;
	public GameObject clayCount;

	private TeamBehavior team;
	private TMP_Text stoneCountText;
	private TMP_Text woodCountText;
	private TMP_Text foodCountText;
	private TMP_Text clayCountText;

	private int _currentLevel;
	private int CurrentLevel
	{
		get { return _currentLevel; }
		set
		{
			SetActiveCastleImage(value);
			_currentLevel = value;
		}
	}


	// Start is called before the first frame update
	void Start()
    {
		team = teamManager.GetComponent<TeamBehavior>();

		stoneCountText = stoneCount.GetComponent<TMP_Text>();
		woodCountText = woodCount.GetComponent<TMP_Text>();
		foodCountText = foodCount.GetComponent<TMP_Text>();
		clayCountText = clayCount.GetComponent<TMP_Text>();

		CurrentLevel = team.castle.Level;
	}

    // Update is called once per frame
    void Update()
    {
		Castle teamCastle = team.castle;
		ResourceRequirement resourceRequirement = Castle.REQ_RESOURCES_PER_LEVEL[CurrentLevel];

		if(CurrentLevel != teamCastle.Level)
		{
			CurrentLevel = teamCastle.Level;
		}

		stoneCountText.text = $"{teamCastle.inventory.Stone}/{resourceRequirement.Stone}";
		woodCountText.text = $"{teamCastle.inventory.Wood}/{resourceRequirement.Wood}";
		foodCountText.text = $"{teamCastle.inventory.Food}/{resourceRequirement.Food}";
		clayCountText.text = $"{teamCastle.inventory.Clay}/{resourceRequirement.Clay}";
	}

	private void SetActiveCastleImage(int level)
	{
		foreach(GameObject obj in castleLevels)
		{
			obj.SetActive(false);
		}

		castleLevels[level]?.SetActive(true);
	}
}
