using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownAvatarScript : MonoBehaviour
{
	public GameObject Sharkdude;
	public GameObject Knight;
	public GameObject Astronaut;
	public TMP_Dropdown dropdown;
	// Start is called before the first frame update
	private void OnEnable()
	{
		dropdown = GetComponent<TMP_Dropdown>();
		dropdown.onValueChanged.AddListener(delegate
		{
			ChangeAvatar(dropdown);
		});
	}

	private void OnDisable()
	{
		dropdown = GetComponent<TMP_Dropdown>();
		dropdown.onValueChanged.RemoveListener(delegate
		{
			ChangeAvatar(dropdown);
		});


	}
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ChangeAvatar(TMP_Dropdown change)
	{
		string avatarname = change.captionText.text;

		if (avatarname == "Sharkdude")
		{
			Sharkdude.SetActive(true);
			Knight.SetActive(false);
			Astronaut.SetActive(false);
		}

		else if(avatarname == "Knight")
		{
			Knight.SetActive(true);
			Astronaut.SetActive(false);
			Sharkdude.SetActive(false);
		}

		else if(avatarname == "Astronaut")
		{
			Astronaut.SetActive(true);
			Knight.SetActive(false);
			Sharkdude.SetActive(false);
		}
	}
}
