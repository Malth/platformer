using UnityEngine;
using System.Collections;
using System;

public abstract class Actor : MonoBehaviour, ILiftable {
	public BioElement m_bioElement;

	public void Mutate (BioElement other){
		if (m_bioElement == null) {
			switch (other.m_BioElement) {
			case BioEnum.Bacteria:
				MutateBacteria (other);
				break;
			case BioEnum.Geko:
				MutateGeko (other);
				break;
			case BioEnum.Ivy:
				MutateIvy (other);
				break;
			case BioEnum.Mushroom:
				MutateMushroom (other);
				break;
			case BioEnum.Root:
				MutateRoot (other);
				break;
			}
		}
	}

	protected virtual void OnTriggerEnter2D(Collider2D other){
		try {
			if (other.tag == "Liftable") {
				this.Mutate(other.GetComponent<BioElement> () );
			}
		} catch (NullReferenceException  e){
		}
	}

	protected virtual void MutateBacteria(BioElement other)
	{
		//TODO Solidifie un sol
	}

	protected virtual void MutateGeko(BioElement other)
	{
		//TODO Rends un mur grimpable (plafond aussi)
	}

	protected virtual void MutateIvy(BioElement other)
	{
		//TODO Crée des lières
	}

	protected virtual void MutateMushroom(BioElement other)
	{
		//TODO crée un trampoline
	}

	protected virtual void MutateRoot(BioElement other)
	{
		//TODO empèche le truc de bouger
	}

	public virtual bool CanIGetObjectPls(){
		if (m_bioElement == null)
			return false;
		return true;
	}

	public virtual GameObject getObject(){
		BioElement element = m_bioElement.GetComponent<BioElement> ();
		if (element.m_generator != null)
			element.m_generator.m_numberOfInstanceMax++;
		m_bioElement.gameObject.SetActive (true);
		return m_bioElement.gameObject;
	}
}
