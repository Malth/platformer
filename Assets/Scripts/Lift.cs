using System.Collections;
using UnityEngine;

public class Lift : MonoBehaviour {
	public float m_ThrowingForce = 5f;
	[HideInInspector]
	public static bool m_IsAiming = false;
	public AudioClip m_SoundGrab;
	public AudioClip m_SoundThrow;
	public AudioClip m_SoundDrop;
	public GameObject m_Aim;

	private static GameObject m_LiftedObject = null;
	private static ArrayList m_TrigeredObject = new ArrayList();

	public void LiftThatShit (GameObject other) // Do you even lift bro?
	{
		if (!other.GetComponent<ILiftable> ().CanIGetObjectPls ()) {
			m_TrigeredObject.Remove (other.gameObject);
			return;
		}
		m_LiftedObject = other.GetComponent<ILiftable> ().getObject ();
		m_LiftedObject.GetComponent<Collider2D> ().enabled = false;
		m_LiftedObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		m_LiftedObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		//Changement de parent
		m_LiftedObject.transform.parent = this.gameObject.transform;
		//on élève de 1
		m_LiftedObject.transform.position = m_LiftedObject.transform.parent.position + Vector3.up * 1.25f;
		m_TrigeredObject.Remove(other);

		Vector3 theScale = m_LiftedObject.transform.localScale;
		theScale.y *= -1;
		m_LiftedObject.transform.localScale = theScale;
		SoundMannager.instance.RandomizeSFX (new AudioClip [] {m_SoundGrab});
	}

	public void Throw(){
		GameObject obj = m_LiftedObject;
		Drop ();
		obj.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) * m_ThrowingForce;
		m_IsAiming = false;
		SoundMannager.instance.RandomizeSFX (new AudioClip [] {m_SoundThrow});
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
		if (other.gameObject.tag == "Liftable" && !m_TrigeredObject.Contains(other.gameObject)) 
			m_TrigeredObject.Add(other.gameObject);
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Liftable" && m_TrigeredObject.Contains (other.gameObject)) 
			m_TrigeredObject.Remove(other.gameObject);
	}


	void Update(){
		Vector3 speed;
		if (Input.GetButtonDown ("Grab")) {
			if (m_LiftedObject != null) {
				Drop ();
				SoundMannager.instance.RandomizeSFX (new AudioClip [] {m_SoundDrop});
			}
			else if (m_TrigeredObject.Count != 0)

					
				LiftThatShit ((GameObject) m_TrigeredObject[0]);
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
		m_Aim.SetActive (m_IsAiming);
		if (m_IsAiming) {
			m_Aim.transform.position = this.transform.position + new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		}

	}

	public static bool IsLifting ()	{
		return m_LiftedObject != null;
	}

	public static void removeInstance(GameObject go){
		if (m_TrigeredObject.Contains(go))
			m_TrigeredObject.Remove (go);
	}
}
