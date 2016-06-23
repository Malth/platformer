using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
	// Use this for initialization
	public Canvas can;
	public Text[] tabText;
	static bool togglePause;
	private bool mustgetBackToCenter;
	private int index;

	void Start () {
		togglePause = false;
		can.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.JoystickButton7)) {
			if (togglePause) {
				Time.timeScale = 0f;
				can.gameObject.SetActive (true);
				tabText [0].color = Color.yellow;
			} else {
				Time.timeScale = 1.0f;
				can.gameObject.SetActive (false);
			}
		}
		//COMMANDES EN MODE PAUSE
		if (togglePause) {
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxisRaw("Vertical") == 1  || Input.GetAxis("Vertical") == -1)
			{
				if (!mustgetBackToCenter) {
					mustgetBackToCenter = true;
					tabText [index].color = Color.white;
					if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetAxis ("Vertical") > 0) {
						if (index <= 0)
							index = 3;
						else
							index--;
						Debug.Log ("index : " + index + "name : " + tabText [index].name);
					}
					if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetAxis ("Vertical") < 0) {
						if (index >= 3)
							index = 0;
						else
							index++;
					}
					tabText[index].color = Color.yellow;
				}
			}

			if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0)) {
				Time.timeScale = 1.0f;
				togglePause = false;
				switch (index) 
				{
				case 0:
					can.gameObject.SetActive (false);
					break;
				case 1:
					Application.LoadLevel ("Level");
					break;
				case 2:
					Application.LoadLevel ("Menu");
					break;
				case 3:
					Application.Quit();
					break;

				}
			}

			if (Input.GetAxisRaw("Vertical") < 0.2f && Input.GetAxisRaw("Vertical") > -0.2f)
			{
				mustgetBackToCenter = false;
			}
		}
	}



}
