using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
	public InputField UsernameInput;
	public InputField PasswordInput;

	public SceneManagerController sceneManagerController;

	// Start is called before the first frame update
	void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

	public void ValidateUser()
	{
		if (UsernameInput.text == "Martin" && PasswordInput.text == "Fabulous" || UsernameInput.text == "Jesper" && PasswordInput.text == "Mauler" || UsernameInput.text == "Benjamin" && PasswordInput.text == "Grandioso")
		{
			PlayerInfoScript.playerName = UsernameInput.text;
			sceneManagerController.ChangeScene("PlayerScreen");
		}
	}
}
