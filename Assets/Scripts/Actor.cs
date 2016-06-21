using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
	public GameObject[] m_elements ;

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
		//TODO
	}

	private void MuteGeko(BioElement other)
	{
		//TODO
	}

	private void MuteIvy(BioElement other)
	{
		//TODO
	}

	private void MuteMushroom(BioElement other)
	{
		//TODO
	}

	private void MuteRoot(BioElement other)
	{
		//TODO
	}
}
