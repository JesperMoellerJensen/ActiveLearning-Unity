using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
[RequireComponent(typeof(BoxCollider2D))]
public class ButtonText : MonoBehaviour
{
	public Color HoverColor = Color.blue;
	public bool useUnderline;

	private TMP_Text _text;
	private Color _textColor;
	private BoxCollider2D _collider;

	// Start is called before the first frame update
	void Start()
    {
		_text = GetComponent<TMP_Text>();
		_collider = GetComponent<BoxCollider2D>();

		_textColor = _text.color;
		_collider.size = _text.rectTransform.sizeDelta;
	}

	void OnMouseOver()
	{
		Debug.Log("Hejhej");
		_text.fontSize = 100;
		_text.color = HoverColor;
	}

	void OnMouseExit()
	{
		_text.fontSize = 50;
		_text.color = _textColor;
	}

	void OnMouseDown()
	{
		
	}

}
