using System.Collections;
using UnityEngine;

public class Lift : MonoBehaviour {
	public float m_ThrowingForce = 2f;
	[HideInInspector]
	public bool m_IsAiming = false;

	private GameObject m_LiftedObject = null;
	private GameObject m_TrigeredObject = null;
	private Rigidbody2D rigid;

	void Start(){
		rigid = this.gameObject.GetComponent<Rigidbody2D> ();
	}

	public void LiftThatShit (GameObject other) // Do you even lift bro?
	{
		m_LiftedObject = other.GetComponent<ILiftable> ().getObject ();
		m_LiftedObject.GetComponent<Collider2D> ().enabled = false;
		m_LiftedObject.transform.parent = this.gameObject.transform;
		m_LiftedObject.transform.position = Vector3.up;
		Vector3 scale = m_LiftedObject.transform.localScale;
		scale.y *= -1;
	}

	public void Throw(){
		Vector3 scale = m_LiftedObject.transform.localScale;
		scale.y *= -1;
		Rigidbody2D liftedRigid = m_LiftedObject.GetComponent<Rigidbody2D>();
		liftedRigid.transform.parent = null;
		liftedRigid.AddForce (Vector2.one * m_ThrowingForce);
		m_IsAiming = false;
		m_LiftedObject.GetComponent<Collider2D> ().enabled = true;

	}

	public void Drop(){
		Vector3 scale = m_LiftedObject.transform.localScale;
		scale.y *= -1;
		m_LiftedObject.transform.parent = null;
		m_LiftedObject.GetComponent<Collider2D> ().enabled = true;
	}

	void OnTriggerEnter2D (Collider2D other){
		Debug.Log ("Enter");
		if (m_TrigeredObject == null && other.gameObject.tag == "Liftable")
			m_TrigeredObject = other.gameObject;
	}

	void OnTriggerExit2D (Collider2D other){
		Debug.Log ("Exit");
		if (m_TrigeredObject != null && other.tag == "Liftable")
			m_LiftedObject = null;
	}

	void Update(){

		/*if (Input.GetAxis ("Throw") != 0 && m_LiftedObject != null) { 		
			m_IsAiming = true; 
			Vector3 speed;
			speed.x = 0;
		} else if (Input.GetAxis ("Throw") == 0 && m_LiftedObject != null && m_IsAiming) {
			Throw ();
			// TODO vector use
		}
		else
			m_IsAiming = false;*/

		if (Input.GetButtonDown ("Drop") && m_LiftedObject != null) {
			Drop ();
		}
	}

}
