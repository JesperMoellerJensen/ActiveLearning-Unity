using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestionUI : MonoBehaviour
{
	public Resource resourceType;
	public TMP_Text subjectType;
	public TMP_Text questionText;

	public ButtonTextScript answer1;
	public ButtonTextScript answer2;
	public ButtonTextScript answer3;
	public ButtonTextScript answer4;

	public string correctAnswer = "";

	public UnityEvent onDone;
	public UnityEvent onCorrectAnswer;

	private void OnEnable()
	{
		answer1.onClick.AddListener(delegate
		{
			SubmitAnswer(answer1.GetText());
		});
		answer2.onClick.AddListener(delegate
		{
			SubmitAnswer(answer2.GetText());
		});
		answer3.onClick.AddListener(delegate
		{
			SubmitAnswer(answer3.GetText());
		});
		answer4.onClick.AddListener(delegate
		{
			SubmitAnswer(answer4.GetText());
		});
	}

	private void OnDisable()
	{
		answer1.onClick.RemoveListener(delegate
		{
			SubmitAnswer(answer1.GetText());
		});
		answer2.onClick.RemoveListener(delegate
		{
			SubmitAnswer(answer2.GetText());
		});
		answer3.onClick.RemoveListener(delegate
		{
			SubmitAnswer(answer3.GetText());
		});
		answer4.onClick.RemoveListener(delegate
		{
			SubmitAnswer(answer4.GetText());
		});
	}

	// Start is called before the first frame update
	void Start()
    {
		if(onDone == null)
		{
			onDone = new UnityEvent();
		}

		if (onCorrectAnswer == null)
		{
			onCorrectAnswer = new UnityEvent();
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void SubmitAnswer(string answer)
	{
		if(answer == correctAnswer)
		{
			//Reward points
			onCorrectAnswer.Invoke();
		}

		onDone.Invoke();
		gameObject.SetActive(false);
	}
}
