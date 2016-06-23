using UnityEngine;
using System.Collections;

public class ActorSticky : Actor {
	public GameObject m_stickyZone;

	protected override void MutateGeko (BioElement other)
	{
		m_bioAffiche.SetActive (true);
		m_bioElement = other;
		other.gameObject.SetActive (false);
		m_stickyZone.SetActive (true);
	}

	protected override void Start ()
	{
		base.Start ();
		m_stickyZone.SetActive (false);
	}

	public override GameObject getObject ()
	{
		CallSon ();
		GeekoFeel.m_isWalkingSideways = false;
		m_stickyZone.SetActive (false);
		return base.getObject ();
	}

	void CallSon(){
		m_stickyZone.GetComponent<GeekoFeel> ().HasEnded ();
	}
}
