using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour, ILiftable{
	public int m_numberOfInstanceMax = 5;
	public GameObject m_ObjectToGenerate;

	public GameObject getObject(){
		if (m_numberOfInstanceMax > 0)
			return AwwwwYis();
		else return Nope ();
	}

	private GameObject AwwwwYis (){	//	Pour intégerer des changements dans le futur
		--m_numberOfInstanceMax;
		GameObject trucARetourner = Instantiate (m_ObjectToGenerate);
		trucARetourner.transform.position = this.transform.position + Vector3.up;
		return trucARetourner;
	}

	private GameObject Nope() {		//	Pour intégrere des feedbacks dans le futur
		return null;
	}

}
