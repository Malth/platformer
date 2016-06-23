using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class TitleSceneScript : MonoBehaviour
{
	public void StartGame()
	{
		// "Stage1" is the name of the first scene we created.
		Debug.Log("Title Scene");

	}
	public void Update()
	{
		if (Input.anyKey) {
			Debug.Log ("A key or mouse click has been detected");
			Application.LoadLevel ("Menu");
		}
	}
}