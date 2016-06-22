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
		DoShitWithBioElement (other);
		m_Mushroom.SetActive (true);
	}

	protected override void MutateIvy(BioElement other){
		DoShitWithBioElement (other);
		m_Ivy.SetActive (true);
	}

	public override GameObject getObject(){
		m_Mushroom.SetActive (false);
		InputController.controller.EndClimbing ();
		m_Ivy.SetActive (false);
		return base.getObject();
	}


}
