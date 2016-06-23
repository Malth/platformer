using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public float m_valueHauteur;
	private GameObject m_player;

	void Start(){
		m_player = InputController.controller.gameObject;
	}

	void Update(){
		Camera.main.transform.position = new Vector3 (m_player.transform.position.x, m_player.transform.position.y + m_valueHauteur, Camera.main.transform.position.z);
	}

}
