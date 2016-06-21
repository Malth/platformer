using UnityEngine;
using System.Collections;

public class BioElement : MonoBehaviour, ILiftable {

	public BioEnum m_BioElement = BioEnum.Geko;

	public GameObject getObject(){
		return this.gameObject;
	}

	void OntriggerEnter2D(Collider2D other){
		if (other.tag == "Acteur") {
			other.GetComponent<Actor> ().Mutate (this);
		}
	}
}
