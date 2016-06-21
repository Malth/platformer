using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
	public GameObject[] m_elements ;

	//public BioElement

	public void Mutate (BioElement other){
		switch (other.m_BioElement) {
		case BioEnum.Bacteria:
			MuteBacteria (other);
			break;
		case BioEnum.Geko:
			MuteGeko (other);
			break;
		case BioEnum.Ivy:
			MuteIvy (other);
			break;
		case BioEnum.Mushroom:
			MuteMushroom (other);
			break;
		case BioEnum.Root:
			MuteRoot (other);
			break;
		}

	}

	private void MuteBacteria(BioElement other)
	{
		//TODO Solidifie un sol
	}

	private void MuteGeko(BioElement other)
	{
		//TODO Rends un mur grimpable (plafond aussi)
	}

	private void MuteIvy(BioElement other)
	{
		//TODO Crée des lières
	}

	private void MuteMushroom(BioElement other)
	{
		//TODO crée un trampoline
	}

	private void MuteRoot(BioElement other)
	{
		//TODO empèche le truc de bouger
	}
}
