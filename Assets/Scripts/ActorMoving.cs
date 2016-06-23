using UnityEngine;
using System.Collections;

public class ActorMoving : Actor {
	public enum MovingBehavior {
		ROTATE,
		SLIDE
	}
	public MovingBehavior m_behavior;
	public float m_speed;
	public GameObject m_pos1;
	public GameObject m_pos2;
	private Vector3 m_switch;
	private bool m_canRun = true;
	private Vector3 m_currentSpeed;

	private Quaternion m_rotationInitiale;

	protected override void Start () {
		base.Start ();
		if (m_behavior == MovingBehavior.ROTATE)
			m_rotationInitiale = transform.rotation;
		m_switch = m_pos1.transform.position;
	}

	protected override void MutateRoot (BioElement other){
		DoShitWithBioElement (other);
		m_bioAffiche.SetActive (true);
		m_canRun = false;
		if (m_behavior == MovingBehavior.ROTATE)
			transform.rotation = m_rotationInitiale ;
	}

	public override GameObject getObject ()
	{
		m_canRun = true;
		m_bioAffiche.SetActive (false);
		return base.getObject ();
	}

	void Update () {
		if (m_canRun) {
			switch (m_behavior) {
			case MovingBehavior.SLIDE:
				transform.position = Vector3.SmoothDamp (transform.position, m_switch,ref m_currentSpeed, 0.2f, m_speed );
				break;
			case MovingBehavior.ROTATE:
				transform.Rotate (new Vector3 (0, 0, 30) * Time.deltaTime * m_speed);
				break;
			}

			if (Vector3.Distance (m_switch, transform.position) < 0.2f) {
				if (m_switch == m_pos1.transform.position)
					m_switch = m_pos2.transform.position;
				else m_switch = m_pos1.transform.position;
			}
		}
	}
}
