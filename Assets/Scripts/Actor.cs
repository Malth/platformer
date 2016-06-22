using UnityEngine;
using System.Collections;

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

	protected void OntriggerEnter2D(Collider2D other){
		if (other.tag == "Liftable") {
			this.Mutate(other.GetComponent<BioElement> () );
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
		element.m_generator.m_numberOfInstanceMax++;
		GameObject objetARetourner = Instantiate (element.m_generator.m_ObjectToGenerate,this.transform.position + Vector3.up, Quaternion.identity) as GameObject;
		return objetARetourner;
	}
}
