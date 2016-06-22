using System.Collections;
using UnityEngine;

public class Lift : MonoBehaviour {
	public float m_ThrowingForce = 300f;
	[HideInInspector]
	public bool m_IsAiming = false;

	private GameObject m_LiftedObject = null;
	private GameObject m_TrigeredObject = null;
	private Rigidbody2D rigid;

	void Start(){
		rigid = this.gameObject.GetComponent<Rigidbody2D> ();
	}


	void cusToString(GameObject obj) {
		Debug.Log ("Pouet String");
		if (obj != null) {
			string str = obj.name;
			Debug.Log (str);
		} else {
			Debug.Log ("objet vide");
		}
	}

	public void LiftThatShit (GameObject other) // Do you even lift bro?
	{
		m_LiftedObject = other.GetComponent<ILiftable> ().getObject ();
		m_LiftedObject.GetComponent<Collider2D> ().enabled = false;
		m_LiftedObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		m_LiftedObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		Debug.Log ("lift : "+ m_LiftedObject.gameObject.transform.position);
		Debug.Log ("player : "+ this.gameObject.transform.position);
		//Changement de parent
		m_LiftedObject.transform.parent = this.gameObject.transform;
		//on élève de 1
		m_LiftedObject.transform.position = m_LiftedObject.transform.parent.position + 2*Vector3.up;
		//

		Vector3 theScale = m_LiftedObject.transform.localScale;
		theScale.y *= -1;
		m_LiftedObject.transform.localScale = theScale;

		m_TrigeredObject = null;
	}

	public void Throw(){
		Debug.Log ("Entering Throw");
		/*
		Vector3 theScale = m_LiftedObject.transform.localScale;
		theScale.y *= -1;
		m_LiftedObject.transform.localScale = theScale;


		m_LiftedObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		m_LiftedObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		Rigidbody2D liftedRigid = m_LiftedObject.GetComponent<Rigidbody2D>();
		liftedRigid.transform.parent = null;
		if (m_IsAiming) {
			float x = Input.GetAxis ("AimHorizontal");
			float y = Input.GetAxis ("AimVertical");
			Vector2 aim = new Vector2 (1, 1);

			Debug.Log ("aim : " + aim.x + "," + aim.y);
			liftedRigid.AddForce (aim * m_ThrowingForce);
		} else {
			liftedRigid.AddForce (Vector2.one * m_ThrowingForce);
		}
		m_IsAiming = false;
		m_LiftedObject.GetComponent<Collider2D> ().enabled = true;
		m_LiftedObject = null;*/
		GameObject obj = m_LiftedObject;
		Drop ();

		/*if (!m_IsAiming) {
			float x = Input.GetAxis ("AimHorizontal");
			float y = Input.GetAxis ("AimVertical");
			Vector2 aim = new Vector2 (x, y);

			Debug.Log ("aim : " + aim.x + "," + aim.y);
			obj.GetComponent<Rigidbody2D> ().AddForce (aim * m_ThrowingForce);
		} else {*/
		Debug.Log(this.gameObject.transform.localScale.x);
		if (this.gameObject.transform.localScale.x > 0) {
			Debug.Log ("x>0");
			obj.GetComponent<Rigidbody2D> ().AddForce (Vector2.one * 200);
		} else {
			Debug.Log ("x<0");
			obj.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-1, 1) * 200);
		}
		//}

		//obj.GetComponent<Rigidbody2D> ().AddForce (Vector2.one * 200);

		m_LiftedObject = null;
		m_IsAiming = false;


	}

	public void Drop(){
		cusToString (m_LiftedObject);
		Vector3 theScale = m_LiftedObject.transform.localScale;
		theScale.y *= -1;
		m_LiftedObject.transform.localScale = theScale;

		m_LiftedObject.transform.parent = null;
		m_LiftedObject.GetComponent<Collider2D> ().enabled = true;
		m_LiftedObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
		m_LiftedObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		m_LiftedObject = null;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (m_TrigeredObject == null && other.gameObject.tag == "Liftable") {
			m_TrigeredObject = other.gameObject;

			Debug.Log ("Enter");
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (m_TrigeredObject != null && other.tag == "Liftable") {
			m_LiftedObject = null;
			Debug.Log ("Exit");
		}
	}

	void useTheForceLuke()
	{
		Debug.Log ("Entering the Force !");
	}


	void Update(){
		Vector3 speed;
		if (m_LiftedObject == null) {
			if (Input.GetButtonDown ("Grab") && m_TrigeredObject != null) {
				cusToString (m_TrigeredObject);
				LiftThatShit (m_TrigeredObject);
				Debug.Log ("Pouet Grab");
			}
		} 
		else {
			if (Input.GetButtonDown ("Grab")) {
				Debug.Log ("Pouet Drop");
				Drop();
			}
		}

		if (Input.GetButtonDown ("Throw") && m_LiftedObject != null) { 
			Debug.Log ("Pouet Throw Down");
			m_IsAiming = true; 
			speed.x = 0;
		} 
		if (Input.GetButtonUp("Throw"))
		{
			Debug.Log ("up up and away ! ");
			if (/*Input.GetButtonUp ("Throw") &&*/ m_LiftedObject != null && m_IsAiming) {
				Debug.Log ("Pouet Throw Up");
				Throw ();
			} else
				{
				m_IsAiming = false;
				}

		}

		if (Input.GetButtonDown ("Force"))
			useTheForceLuke ();
	}
}
