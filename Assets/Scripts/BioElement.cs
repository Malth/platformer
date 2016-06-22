using UnityEngine;
using System.Collections;

public class BioElement : MonoBehaviour, ILiftable {

	public BioEnum m_BioElement = BioEnum.Geko;
	[HideInInspector]
	public Generator m_generator;

	public GameObject getObject(){
		return this.gameObject;
	}

	public bool CanIGetObjectPls(){
		return true;
	}
}
