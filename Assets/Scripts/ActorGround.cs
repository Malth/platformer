using UnityEngine;
using System.Collections;

public class ActorGround : Actor {

	public GameObject m_Mushroom;
	public GameObject m_Ivy;

	protected override void MutateMushroom(BioElement other){
		m_bioElement = other;
		m_Mushroom.transform.localScale = Vector3.one;
	}

	protected override void MutateIvy(BioElement other){
		m_bioElement = other;
		m_Ivy.transform.localScale = Vector3.one;
	}

	public override GameObject getObject(){
		m_Mushroom.transform.localScale = Vector3.zero;
		m_Ivy.transform.localScale = Vector3.zero;
		return base.getObject();
	}


}
