using UnityEngine;
using System.Collections;

public class Champignon : MonoBehaviour {

	public float m_puissance; 

	private Animator m_animator;

	void Start(){
		m_animator = this.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && other.GetComponent<Rigidbody2D>().velocity.y != 0)
			FaireDesTrucs (other.gameObject);
	}

	void FaireDesTrucs(GameObject other){
		other.GetComponent<Rigidbody2D> ().velocity = Vector2.up * m_puissance;
		m_animator.SetTrigger ("Bounce");
	}
}
