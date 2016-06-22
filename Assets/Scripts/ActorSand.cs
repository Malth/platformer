using UnityEngine;
using System.Collections;

public class ActorSand : Actor {
	public Vector3 m_spawnPoint;
	private bool m_canKill = true;

	protected override void MutateBacteria (BioElement other) {
		m_bioElement = other;
		m_canKill = false;
	}

	public override GameObject getObject ()
	{
		m_canKill = true;
		return base.getObject ();
	}

	protected void OnTriggerEnter2D (Collider2D other){
		if (m_canKill)
			if (other.tag == "Player")
				other.transform.position = m_spawnPoint;
		base.OnTriggerEnter2D (other);
	}
}
