using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class EnemyMover : MonoBehaviour
{
	[SerializeField]
	private GameObject m_enemyObject;

	[SerializeField]
	private Vector3 m_scenePosition = Vector3.zero;

	[SerializeField]
	private float m_speedOfEnemy = 0.0f;

	// Use this for initialization
	void Start () 
	{
		//m_enemyObject.SetActive(true);
		m_scenePosition = m_enemyObject.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (m_enemyObject.activeSelf) 
		{
			m_scenePosition.x -= m_speedOfEnemy *  Time.deltaTime;
			m_enemyObject.gameObject.transform.position = m_scenePosition;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("House")) 
		{
			Debug.Log("Enemy " + m_enemyObject.name + " hit the house");
			m_enemyObject.SetActive(false);
		}
	}
}