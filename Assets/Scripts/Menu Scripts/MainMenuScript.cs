using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	public Text[] tabButton;
	private int index = 0;
	private bool mustgetBackToCenter = false;

	// Use this for initialization
	void Start () {
		tabButton [0].color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxisRaw("Vertical") == 1  || Input.GetAxis("Vertical") == -1)
		{
			if (!mustgetBackToCenter) {
				mustgetBackToCenter = true;
				tabButton [index].color = Color.black;
				if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetAxis ("Vertical") > 0) {
					if (index <= 0)
						index = 2;
					else
						index--;
					Debug.Log ("index : " + index + "name : " + tabButton [index].name);
				}
				if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetAxis ("Vertical") < 0) {
					if (index >= 2)
						index = 0;
					else
						index++;
				}
				tabButton [index].color = Color.white;
			}
		}

		if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0)) {

			switch (index) 
			{
			case 0:
				Application.LoadLevel ("Level");
				break;
			case 1:
				Application.LoadLevel ("Credits");
				break;
			case 2:
				Application.Quit();
				break;

			}
		}

		if (Input.GetAxisRaw("Vertical") < 0.4f && Input.GetAxisRaw("Vertical") > -0.4f)
		{
			mustgetBackToCenter = false;
		}
	}
}
