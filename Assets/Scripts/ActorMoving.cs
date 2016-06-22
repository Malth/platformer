using UnityEngine;
using System.Collections;

public class ActorMoving : Actor {
	public enum MovingBehavior {
		ROTATE,
		SLIDE
	}
	public MovingBehavior m_behavior;
	public float m_speed;
	public GameObject m_plateform;
	public Vector3 m_pos1;
	public Vector3 m_pos2;

	private Vector3 m_switch;
	private bool m_canRun = true;
	private Vector3 m_currentSpeed;

	private Vector3 m_positionInitiale;
	private Quaternion m_rotationInitiale;

	void Start () {
		if (m_behavior == MovingBehavior.ROTATE)
			m_rotationInitiale = m_plateform.transform.rotation;
		else
			m_positionInitiale = m_plateform.transform.position;
	}

	protected override void MutateRoot (BioElement other){
		m_bioElement = other;
		m_canRun = false;
		if (m_behavior == MovingBehavior.ROTATE)
			m_plateform.transform.rotation = m_rotationInitiale ;
		else
			m_plateform.transform.position = m_positionInitiale ;
	}

	public override GameObject getObject ()
	{
		m_canRun = true;
		return base.getObject ();
	}

	void Update () {
		if (m_canRun) {
			switch (m_behavior) {
			case MovingBehavior.SLIDE:
				m_plateform.transform.position = Vector3.SmoothDamp (m_plateform.transform.position, m_switch,ref m_currentSpeed, 0.2f, m_speed );
				break;
			case MovingBehavior.ROTATE:
				m_bioElement.gameObject.transform.Rotate (new Vector3 (0, 0, 30) * Time.deltaTime * m_speed);
				break;
			}

			if (Vector3.Distance (m_switch, m_plateform.transform.position) < 0.2f) {
				if (m_switch == m_pos1)
					m_switch = m_pos2;
				else m_switch = m_pos1;
			}
		}
	}
}
