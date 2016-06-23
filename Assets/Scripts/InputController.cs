using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour	{
	public static InputController controller;
	public AudioClip m_SoundWalk1;
	public AudioClip m_SoundWalk2;

	private GameObject m_movingPlatform;

	public static PlayerController m_Character;
	private bool m_Jump;
	private bool m_Climb;
	private Animator m_Anim;
	private float timerFootSound;

	private GameObject movingPlatform;

	private void Awake(){
		controller = this;
		m_Character = GetComponent<PlayerController>();
		m_Anim = GetComponent<Animator>();
	}


	private void Update()
	{
		if (!m_Jump){
			m_Jump = Input.GetButtonDown("Jump");
		}

		if (PlayerController.m_Grounded && m_movingPlatform != null) {
			this.gameObject.transform.parent = m_movingPlatform.transform;
		} else {
			this.gameObject.transform.parent = null;
		}

	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "Climbable") {
			m_Climb = true;
		}
		if (other.gameObject.GetComponent <ActorMoving>() && m_movingPlatform == null ) {
			if (other.gameObject.GetComponent  <ActorMoving> ().m_behavior == ActorMoving.MovingBehavior.SLIDE) {
				m_movingPlatform = other.gameObject;
			}
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Climbable") {
			EndClimbing ();
		}
		if (other.gameObject.GetComponent ("ActorMoving") && m_movingPlatform != null) {
			m_movingPlatform = null;
			Debug.Log ("No More Platform !");
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

		m_Anim.SetBool ("Walking", h != 0);
		m_Anim.SetBool ("Lifting", Lift.IsLifting ());
		m_Anim.SetBool ("Jump", !PlayerController.m_Grounded);
		m_Jump = false;

		timerFootSound += Time.fixedDeltaTime;
		if (timerFootSound > 0.2f && h != 0 && PlayerController.m_Grounded) {
			SoundMannager.instance.RandomizeSFX (new AudioClip[] { m_SoundWalk1, m_SoundWalk2 });
			timerFootSound = 0;
		}
	}

	public void EndClimbing(){
		this.m_Climb = false;
	}
}