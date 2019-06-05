using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
	public LoginScript loginScript;
	public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void onClick()
	{
		if (audio) audio.Play();

		loginScript.ValidateUser();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
