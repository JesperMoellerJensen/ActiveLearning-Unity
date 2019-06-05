using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{
	public ButtonTextScript Background;
	public ButtonTextScript Avatar;
	public GameObject Toggle;
	public GameObject Dropdown;
	// Start is called before the first frame update
	private void OnEnable()
	{
		Background.onClick.AddListener(delegate
		{
			ToggleMenu(Background);
		});

		Avatar.onClick.AddListener(delegate
		{
			ToggleMenu(Avatar);
		});
	}

	private void OnDisable()
	{
		Background.onClick.RemoveListener(delegate
		{
			ToggleMenu(Background);
		});

		Avatar.onClick.RemoveListener(delegate
		{
			ToggleMenu(Avatar);
		});
	}
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ToggleMenu(ButtonTextScript buttonText)
	{
		if (buttonText == Background)
		{
			Toggle.gameObject.SetActive(!Toggle.activeSelf);
			Dropdown.gameObject.SetActive(false);
		}

		if (buttonText == Avatar)
		{
			Toggle.gameObject.SetActive(false);
			Dropdown.gameObject.SetActive(!Dropdown.activeSelf);
		}
	}
}
