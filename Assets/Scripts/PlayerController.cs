using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public TMP_Text playerName;
    // Start is called before the first frame update
    void Start()
    {
		playerName.text = PlayerInfoScript.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
