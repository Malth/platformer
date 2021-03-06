﻿using UnityEngine;
using System.Collections;

public class GeekoFeel : MonoBehaviour {
	public enum direction{DROITE,HAUT,GAUCHE}

	public direction m_direction;
	public static bool m_isWalkingSideways;

	private Vector3 m_rotato;
	void Start() {
		switch (m_direction) {
		case direction.DROITE:
			m_rotato = new Vector3 (0, 0, 90);
			break;
		case direction.GAUCHE:
			m_rotato = new Vector3 (0, 0, -90);
			break;
		case direction.HAUT:
			m_rotato = new Vector3 (0, 0, 180);
			break;

		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && !m_isWalkingSideways) {
			other.transform.Rotate (m_rotato);
			m_isWalkingSideways = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player" && m_isWalkingSideways) {
			other.transform.Rotate (m_rotato * -1);
			m_isWalkingSideways = false;
		}
	}

	public void HasEnded(){
		if (m_isWalkingSideways) {
			m_isWalkingSideways = false;
			InputController.m_Character.gameObject.transform.Rotate (m_rotato * -1);
			InputController.m_Character.GetComponent<InputController> ().EndClimbing ();
		}
	}
}
