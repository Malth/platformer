using UnityEngine;
using System.Collections;
using System;

public class ActorSand : Actor {
	public GameObject m_spawnPoint;
	public GameObject[] m_sable;
	public AudioClip m_deathSound;
	public bool m_isNormalSand = false;

	private bool m_canKill = true;

	protected override void MutateBacteria (BioElement other) {
		if (m_isNormalSand)
			return;
		m_bioElement = other;
		m_bioElement.gameObject.SetActive (false);
		m_canKill = false;
		SwitchSandAnim ();
		m_bioAffiche.SetActive (true);
	}

	public override GameObject getObject ()
	{
		m_canKill = true;
		SwitchSandAnim ();
		return base.getObject ();
	}

	protected override void OnTriggerEnter2D (Collider2D other){
		if (m_canKill) {
			if (other.tag == "Player") {
				other.transform.position = m_spawnPoint.transform.position;
				SoundMannager.instance.RandomizeSFX (new AudioClip [] {m_deathSound});
			}
		}
		base.OnTriggerEnter2D (other);
	}

	protected override void MutateGeko (BioElement other)
	{
		if (other.gameObject.GetComponent<BioElement>().m_generator != null)
			other.gameObject.GetComponent<BioElement>().m_generator.m_numberOfInstanceMax++;
		Destroy (other.gameObject);

	}

	protected override void MutateRoot (BioElement other)
	{
		if (other.gameObject.GetComponent<BioElement>().m_generator != null)
			other.gameObject.GetComponent<BioElement>().m_generator.m_numberOfInstanceMax++;
		Destroy (other.gameObject);

	}

	protected override void MutateIvy (BioElement other)
	{
		if (other.gameObject.GetComponent<BioElement>().m_generator != null)
			other.gameObject.GetComponent<BioElement>().m_generator.m_numberOfInstanceMax++;
		Destroy (other.gameObject);

	}

	protected override void MutateMushroom (BioElement other)
	{
		if (other.gameObject.GetComponent<BioElement>().m_generator != null)
			other.gameObject.GetComponent<BioElement>().m_generator.m_numberOfInstanceMax++;
		Destroy (other.gameObject);

	}

	private void SwitchSandAnim(){

		foreach (GameObject go in m_sable) {
			go.GetComponent<Animator> ().SetBool ("Still", !m_canKill);
		}
	}
}
