using System;
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

	public UnityAction submitAnswer1;
	public UnityAction submitAnswer2;
	public UnityAction submitAnswer3;
	public UnityAction submitAnswer4;

	public string correctAnswer = "";

	public UnityEvent onDone;
	public UnityEvent onCorrectAnswer;

	private void OnEnable()
	{
		submitAnswer1 = delegate
		{
			SubmitAnswer(answer1.GetText());
		};
		submitAnswer2 = delegate
		{
			SubmitAnswer(answer2.GetText());
		};
		submitAnswer3 = delegate
		{
			SubmitAnswer(answer3.GetText());
		};
		submitAnswer4 = delegate
		{
			SubmitAnswer(answer4.GetText());
		};

		answer1.onClick.AddListener(submitAnswer1);
		answer2.onClick.AddListener(submitAnswer2);
		answer3.onClick.AddListener(submitAnswer3);
		answer4.onClick.AddListener(submitAnswer4);
	}

	private void OnDisable()
	{
		answer1.onClick.RemoveListener(submitAnswer1);
		answer2.onClick.RemoveListener(submitAnswer2);
		answer3.onClick.RemoveListener(submitAnswer3);
		answer4.onClick.RemoveListener(submitAnswer4);
	}

	// Start is called before the first frame update
	void Start()
    {
		//TODO: Get random question
		Question q = QuestionDb.GetRandomQuestion();
		subjectType.text = q.subject;
		questionText.text = q.question;
		answer1.SetText(q.answer1);
		answer2.SetText(q.answer2);
		answer3.SetText(q.answer3);
		answer4.SetText(q.answer4);
		correctAnswer = q.correctAnswer;

		if (onDone == null)
		{
			onDone = new UnityEvent();
		}

		if (onCorrectAnswer == null)
		{
			onCorrectAnswer = new UnityEvent();
		}
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

	public static QuestionUI CreateQuestion()
	{
		QuestionUI question = Instantiate(Resources.Load<GameObject>("Prefabs/Question"), GameObject.FindGameObjectWithTag("Canvas").transform).GetComponent<QuestionUI>();
		question.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));

		return question;
	}
}
