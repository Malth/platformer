using System.Collections;
using UnityEngine;

public class Lift : MonoBehaviour {
	public float m_ThrowingForce = 5f;
	[HideInInspector]
	public static bool m_IsAiming = false;

	private static GameObject m_LiftedObject = null;
	private GameObject m_TrigeredObject = null;

	public void LiftThatShit (GameObject other) // Do you even lift bro?
	{
		if (!other.GetComponent<ILiftable> ().CanIGetObjectPls())
			return;
		m_LiftedObject = other.GetComponent<ILiftable> ().getObject ();
		m_LiftedObject.GetComponent<Collider2D> ().enabled = false;
		m_LiftedObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		m_LiftedObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		//Changement de parent
		m_LiftedObject.transform.parent = this.gameObject.transform;
		//on élève de 1
		m_LiftedObject.transform.position = m_LiftedObject.transform.parent.position + Vector3.up * 1.25f;
		m_TrigeredObject = null;

		Vector3 theScale = m_LiftedObject.transform.localScale;
		theScale.y *= -1;
		m_LiftedObject.transform.localScale = theScale;

		m_TrigeredObject = null;
	}

	public void Throw(){
		GameObject obj = m_LiftedObject;
		Drop ();
		/*if (this.gameObject.transform.localScale.x > 0)
			obj.GetComponent<Rigidbody2D> ().velocity =  Vector2.one * m_ThrowingForce;
		else 
			obj.GetComponent<Rigidbody2D> ().velocity =  new Vector2(-1, 1) * m_ThrowingForce;
		*/
		obj.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) * m_ThrowingForce;
		m_IsAiming = false;
	}

	public void Drop(){
		Vector3 theScale = m_LiftedObject.transform.localScale;
		theScale.y *= -1;

		m_LiftedObject.transform.parent = null;
		m_LiftedObject.GetComponent<Collider2D> ().enabled = true;
		m_LiftedObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
		m_LiftedObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		m_LiftedObject = null;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Liftable") 
			m_TrigeredObject = other.gameObject;
	}

	void OnTriggerExit2D (Collider2D other){
		if (m_TrigeredObject != null && other.tag == "Liftable") 
			m_TrigeredObject = null;
	}


	void Update(){
		Vector3 speed;
		if (Input.GetButtonDown ("Grab")) {
			if (m_LiftedObject != null)
				Drop ();
			else if (m_TrigeredObject != null)
				LiftThatShit (m_TrigeredObject);
		}

		if (Input.GetButtonDown ("Throw") && m_LiftedObject != null) { 
			m_IsAiming = true; 
			speed.x = 0;
		} 
		if (Input.GetButtonUp("Throw"))
		{
			if (m_LiftedObject != null && m_IsAiming) {
				Throw ();
			} else
				m_IsAiming = false;
		}
	}

	public static bool IsLifting ()	{
		return m_LiftedObject != null;
	}
}
