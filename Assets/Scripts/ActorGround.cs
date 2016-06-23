using UnityEngine;
using System.Collections;

public class ActorGround : Actor {

	public GameObject m_Mushroom;
	public GameObject m_Ivy;
	public GameObject m_bioAffiche2;

	protected override void Start(){
		base.Start ();
		m_Mushroom.SetActive (false);
		m_Ivy.SetActive (false);
		m_bioAffiche2.SetActive (false);
	}

	protected override void MutateMushroom(BioElement other){
		
		DoShitWithBioElement (other);
		m_bioAffiche.SetActive (true);
		m_Mushroom.SetActive (true);
	}

	protected override void MutateIvy(BioElement other){
		DoShitWithBioElement (other);
		m_bioAffiche2.SetActive (true);
		m_Ivy.SetActive (true);
	}

	public override GameObject getObject(){
		m_bioAffiche2.SetActive (false);
		m_Mushroom.SetActive (false);
		InputController.controller.EndClimbing ();
		m_Ivy.SetActive (false);
		return base.getObject();
	}


}
