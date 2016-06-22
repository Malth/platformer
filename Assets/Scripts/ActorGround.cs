using UnityEngine;
using System.Collections;

public class ActorGround : Actor {

	public GameObject m_Mushroom;
	public GameObject m_Ivy;

	void Start(){
		m_Mushroom.SetActive (false);
		m_Ivy.SetActive (false);
	}

	protected override void MutateMushroom(BioElement other){
		m_bioElement = other;
		other.gameObject.SetActive (false);
		m_Mushroom.SetActive (true);
	}

	protected override void MutateIvy(BioElement other){
		m_bioElement = other;
		other.gameObject.SetActive (false);
		m_Ivy.SetActive (true);
	}

	public override GameObject getObject(){
		m_Mushroom.SetActive (false);
		m_Ivy.SetActive (false);
		return base.getObject();
	}


}
