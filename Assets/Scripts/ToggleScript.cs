using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
	public Toggle BakeryToggle;
	public Toggle CastleToggle;
	public Toggle NotebookToggle;
	public Toggle Starburst;
	public Slider StarSlider;
	public GameObject BakeryLane;
	public GameObject Castle;
	public GameObject Notebook;
	public GameObject StarBlue;
	public GameObject StarGreen;
	public GameObject StarOrange;
	public GameObject StarPurple;
	public GameObject StarRed;

	// Start is called before the first frame update
	private void OnEnable()
	{
		BakeryToggle.onValueChanged.AddListener(delegate
		{
			ToggleAction(BakeryToggle);
		});

		CastleToggle.onValueChanged.AddListener(delegate
		{
			ToggleAction(CastleToggle);
		});

		NotebookToggle.onValueChanged.AddListener(delegate
		{
			ToggleAction(NotebookToggle);
		});

		Starburst.onValueChanged.AddListener(delegate
		{
			ToggleAction(Starburst);
			StarSlider.gameObject.SetActive(Starburst.isOn);
		});

		StarSlider.onValueChanged.AddListener(delegate
		{
			DisableBackgrounds();
			GetSliderBackground()?.SetActive(true);
		});
	}

	private void OnDisable()
	{
		BakeryToggle.onValueChanged.RemoveListener(delegate
		{
			ToggleAction(BakeryToggle);
		});

		CastleToggle.onValueChanged.RemoveListener(delegate
		{
			ToggleAction(CastleToggle);
		});

		NotebookToggle.onValueChanged.RemoveListener(delegate
		{
			ToggleAction(NotebookToggle);
		});

		Starburst.onValueChanged.RemoveListener(delegate
		{
			ToggleAction(Starburst);
			StarSlider.gameObject.SetActive(Starburst.isOn);
		});

		StarSlider.onValueChanged.RemoveListener(delegate
		{
			DisableBackgrounds();
			GetSliderBackground()?.SetActive(true);
		});
	}
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void ToggleAction(Toggle toggle)
	{
		DisableBackgrounds();
		if (toggle.isOn)
		{
			UntoggleAll(toggle);
		}
		GetBackground(toggle)?.SetActive(toggle.isOn);
	}

	private GameObject GetBackground(Toggle toggle)
	{
		if (BakeryToggle == toggle)
		{
			return BakeryLane;
		}

		if (CastleToggle == toggle)
		{
			return Castle;
		}

		if (NotebookToggle == toggle)
		{
			return Notebook;
		}

		if (Starburst == toggle)
		{
			return GetSliderBackground();
		}

		return null;
	}

	private void DisableBackgrounds()
	{
		BakeryLane.SetActive(false);
		Castle.SetActive(false);
		Notebook.SetActive(false);
		StarBlue.SetActive(false);
		StarGreen.SetActive(false);
		StarOrange.SetActive(false);
		StarPurple.SetActive(false);
		StarRed.SetActive(false);
	}

	private void UntoggleAll(Toggle active)
	{
		if (active == BakeryToggle)
		{
			CastleToggle.isOn = false;
			NotebookToggle.isOn = false;
			Starburst.isOn = false;
		}

		if (active == CastleToggle)
		{
			BakeryToggle.isOn = false;
			NotebookToggle.isOn = false;
			Starburst.isOn = false;
		}

		if (active == NotebookToggle)
		{
			BakeryToggle.isOn = false;
			CastleToggle.isOn = false;
			Starburst.isOn = false;
		}

		if (active == Starburst)
		{
			BakeryToggle.isOn = false;
			CastleToggle.isOn = false;
			NotebookToggle.isOn = false;
		}
	}

	private GameObject GetSliderBackground()
	{

		if (StarSlider.value <= 0.2)
		{
			return StarBlue;
		}

		else if (StarSlider.value >= 0.201 && StarSlider.value <= 0.4)
		{
			return StarGreen;
		}

		else if (StarSlider.value >= 0.401 && StarSlider.value <= 0.6)
		{
			return StarOrange;
		}

		else if (StarSlider.value >= 0.601 && StarSlider.value <= 0.8)
		{
			return StarPurple;
		}

		else if (StarSlider.value >= 0.801 && StarSlider.value <= 1.0)
		{
			return StarRed;
		}

		return null;
	}
}
