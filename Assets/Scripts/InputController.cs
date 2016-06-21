﻿using System.Collections;
using UnityEngine;

public class InputController : MonoBehaviour	{

	private PlayerController m_Character;
	private bool m_Jump;

	private void Awake(){
		m_Character = GetComponent<PlayerController>();
	}


	private void Update()
	{
		if (!m_Jump)
		{
			m_Jump = Input.GetButtonDown("Jump");
		}
	}


	private void FixedUpdate()
	{
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		float h = Input.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		m_Character.Move(h, crouch, m_Jump);
		m_Jump = false;
	}
}