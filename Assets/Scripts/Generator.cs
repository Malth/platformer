using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour, ILiftable{
	public int m_numberOfInstanceMax = 5;
	public GameObject m_ObjectToGenerate;
	public GameObject m_adnAnim;

	void Start(){
		m_ObjectToGenerate.GetComponent<BioElement> ().m_generator = this;
	}

	public GameObject getObject(){
		--m_numberOfInstanceMax;
		GameObject trucARetourner = Instantiate (m_ObjectToGenerate);
		trucARetourner.transform.position = this.transform.position + Vector3.up;
		return trucARetourner;
	}

	public bool CanIGetObjectPls(){
		if (m_numberOfInstanceMax == 0)
			return false;
		return true;
	}

	void Update(){
		if (m_numberOfInstanceMax == 0)
			m_adnAnim.SetActive (false);
		else
			m_adnAnim.SetActive (true);
	}

}
