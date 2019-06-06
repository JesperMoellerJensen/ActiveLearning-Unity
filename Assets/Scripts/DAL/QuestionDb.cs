using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Question
{
	public string subject;
	public string question;
	public string answer1;
	public string answer2;
	public string answer3;
	public string answer4;
	public string correctAnswer;

	public Question(string subject, string question, string answer1, string answer2, string answer3, string answer4, string correctAnswer)
	{
		this.subject = subject;
		this.question = question;
		this.answer1 = answer1;
		this.answer2 = answer2;
		this.answer3 = answer3;
		this.answer4 = answer4;
		this.correctAnswer = correctAnswer;
	}
}

public static class QuestionDb
{
	private static List<Question> _questions = new List<Question>()
	{
		new Question("Dansk", "Hvilket af disse ord er IKKE et tillægsord?", "Lækker", "Sej", "Grim", "Vakler", "Vakler"),
		new Question("Dansk", "Hvilket af disse ord er et udsagnsord?", "Danse", "Flotte", "Falke", "Jeres", "Danse"),
		new Question("Engelsk", "Hvordan staves det danske ord \"næsehorn\" på engelsk?", "Rinocerus", "Rhinoceros", "Rhinocerous", "Raynosserus", "Rhinoceros"),
		new Question("Engelsk", "What does the word \"platypus\" mean in Danish?", "Kongeørn", "Svane", "Næbdyr", "Rensdyr", "Næbdyr"),
		new Question("Matematik", "Hvad er resultatet af 13+26?", "29", "39", "33", "41", "39"),
		new Question("Matematik", "Hvilket af følgende tal er ikke i 7-tabellen?", "35", "49", "84", "27", "27"),
		new Question("Matematik", "Hvis du har 48 vingummier og skal dele dem ligeligt mellem dig selv og dine tre venner, hvor mange stykker vingummi får I så hverisær?", "8", "12", "15", "7", "12")
	};


	public static Question GetRandomQuestion()
	{
		int randomIndex = Random.Range(0, _questions.Count);
		return _questions[randomIndex];
	}
	
	public static Question GetQuestion(int index)
	{
		if(index >= _questions.Count)
		{
			index -= 0;
		}

		return _questions[index];
	}
}