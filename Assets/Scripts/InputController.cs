﻿using System.Collections;
using UnityEngine;

public class InputController : MonoBehaviour	{

	private PlayerController m_Character;
	private bool m_Jump;
	private bool m_Climb;

	private GameObject m_surfaceToClimb = null;

	private void Awake(){
		m_Character = GetComponent<PlayerController>();
	}

	private void Update()
	{
		if (!m_Jump){
			m_Jump = Input.GetButtonDown("Jump");
		}

		if (Input.GetAxis("Vertical") <= 0)
			{
			if (m_surfaceToClimb != null)
				m_Climb = true;
			}
		if (Input.GetButtonUp("Vertical"))
		{
			if (m_surfaceToClimb != null)
				m_Climb = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		
		if (m_surfaceToClimb == null && other.gameObject.tag == "Climbable") {
			m_surfaceToClimb = other.gameObject;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (m_surfaceToClimb != null && other.gameObject.tag == "Climbable") {
			m_surfaceToClimb = null;
			m_Climb = false;

		}
	}


	private void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
		if (!Lift.m_IsAiming)
			m_Character.Move(h, v, m_Jump, m_Climb);
		else 
			m_Character.Move(0, v, m_Jump, m_Climb);
		m_Jump = false;
	}
}