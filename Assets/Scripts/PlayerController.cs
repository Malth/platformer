using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
	{
	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private float m_JumpForce = 7f;                  // Amount of force added when the player jumps.
	[SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
	public AudioClip m_SoundJump;

	private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public static bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.

	private void Awake()
	{
		m_GroundCheck = transform.Find("GroundCheck");
		m_Rigidbody2D = this.GetComponent<Rigidbody2D>();
	}


	private void FixedUpdate()
	{
		m_Grounded = false;

		foreach (Collider2D c in Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround))
		{
			if (c != gameObject)
				m_Grounded = true;
		}
	}


	public void Move(float hori, float verti, bool jump, bool climb)
	{

		if (m_Grounded || m_AirControl) {

			m_Rigidbody2D.velocity = new Vector2 (hori * m_MaxSpeed, climb ? 0 : m_Rigidbody2D.velocity.y);

			if (hori > 0 && !m_FacingRight) {
				// ... flip the player.
				Flip ();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (hori < 0 && m_FacingRight) {
				Flip ();
			}
			if (climb)
				m_Rigidbody2D.velocity = new Vector2 (hori * m_MaxSpeed, verti * m_MaxSpeed);
			else if (m_Grounded && jump) {
				m_Grounded = false;
				m_Rigidbody2D.velocity = new Vector2 (m_Rigidbody2D.velocity.x, m_JumpForce);
				SoundMannager.instance.RandomizeSFX (new AudioClip [] {m_SoundJump});
			}

			if (climb)
				m_Rigidbody2D.velocity = new Vector2 (hori * m_MaxSpeed, verti * m_MaxSpeed);
		}

	}


	public void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

