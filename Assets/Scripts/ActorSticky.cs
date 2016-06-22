using UnityEngine;
using System.Collections;

public class ActorSticky : Actor {
	public GameObject m_stickyZone;

	protected override void MutateGeko (BioElement other)
	{
		m_bioElement = other;
		other.gameObject.SetActive (false);
		m_stickyZone.SetActive (true);
	}

	public override GameObject getObject ()
	{
		m_stickyZone.SetActive (false);
		return base.getObject ();
	}
}
