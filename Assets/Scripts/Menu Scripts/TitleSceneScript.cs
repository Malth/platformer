using UnityEngine;

public class TitleSceneScript : MonoBehaviour
{
	public void Update()
	{
		if (Input.anyKey) {
			Application.LoadLevel ("Menu");
		}
	}
}