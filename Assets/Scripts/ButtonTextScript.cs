﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_Text))]
[RequireComponent(typeof(BoxCollider2D))]
public class ButtonTextScript : MonoBehaviour
{
	public float hoverSize = 84;
	public GameObject toggleObject;
	public UnityEvent onClick;
		
	private TMP_Text _text;
	private Color _textcolor;
	private BoxCollider2D _collider;
	private float fontSize;

	private void Awake()
	{
		if (onClick == null)
		{
			onClick = new UnityEvent();
		}

		_text = GetComponent<TMP_Text>();
		_collider = GetComponent<BoxCollider2D>();
	}

	
	void Start()
    {
		fontSize = _text.fontSize;
		_textcolor = _text.color;
		_collider.size = _text.rectTransform.sizeDelta;

    }

	private void OnMouseOver()
	{
		if(hoverSize > 0)
		{
			_text.fontSize = hoverSize;
		}
	}

	private void OnMouseExit()
	{
		if (hoverSize > 0)
		{
			_text.fontSize = fontSize;
		}
	}

	private void OnMouseDown()
	{
		onClick.Invoke();
	}

	public void SetText(string text)
	{
		_text.text = text;
	}

	public string GetText()
	{
		return _text.text;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
