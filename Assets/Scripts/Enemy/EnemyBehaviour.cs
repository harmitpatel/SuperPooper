using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class EnemyInfoHolder
{
	public GameObject m_EnemyObj;
	public int m_EnemyID = 0;
	public int m_NumberInGame = 0;
}

[ExecuteInEditMode]
public class EnemyBehaviour : MonoBehaviour 
{
	[SerializeField]
	bool m_isDebug = false;

	[SerializeField]
	private List<EnemyInfoHolder> m_EnemyTypeList = new List<EnemyInfoHolder>();

	[SerializeField]
	private List<GameObject> m_EnemyList ;

	[SerializeField]
	List<GameObject> m_InGameEnemies;

	[SerializeField]
	int m_randomEnemyNumber = 0;

	[SerializeField]
	int m_MaxNumberOfEnemies = 0;

	[SerializeField]
	float m_EnemyBirthTime = 0.0f;

	[SerializeField]
	private bool m_isFirstEnemyCreated = false;

	GameObject m_tempEnemy;
	// Use this for initialization
	void Start () 
	{
		m_InGameEnemies.Clear ();
		m_EnemyList.Clear ();

		for(int l_enemyIndex = 0; l_enemyIndex < m_EnemyTypeList.Count; l_enemyIndex++)
		{
			m_EnemyTypeList[l_enemyIndex].m_EnemyID = l_enemyIndex;
			m_EnemyTypeList[l_enemyIndex].m_NumberInGame = UnityEngine.Random.Range(1, m_EnemyTypeList.Count);
			for(int j = 0; j < m_EnemyTypeList[l_enemyIndex].m_NumberInGame; j++)
			{
				m_tempEnemy = Instantiate(m_EnemyTypeList [l_enemyIndex].m_EnemyObj) as GameObject;
				m_EnemyList.Add(m_tempEnemy);    
				//m_tempEnemy.SetActive(true);
			}
		}

//		for(int i = 0; i < m_EnemyTypeList.Count; i++)
//		{
//			for(int j = 0; j < m_EnemyTypeList[i].m_NumberInGame; j++)
//			{
//				m_EnemyList.Add(m_EnemyTypeList [j].m_EnemyObj);
//			}
//		}


	}
	
	// Update is called once per frame
	void Update () 
	{
		//First enemy alway created after first 5 seconds
		if (!m_isFirstEnemyCreated) 
		{
			if (Time.time > 5.0f) 
			{
				m_randomEnemyNumber = UnityEngine.Random.Range (0, m_EnemyTypeList.Count - 1);
				m_InGameEnemies.Add(m_EnemyList[m_randomEnemyNumber]);
				for(int l_inGameEnemyIndex = 0; l_inGameEnemyIndex < m_InGameEnemies.Count; l_inGameEnemyIndex++)
				{
					m_InGameEnemies[l_inGameEnemyIndex].SetActive(true);
					Debug.Log("setting first --- enemy --- " + m_InGameEnemies[l_inGameEnemyIndex].name);
				}				
				m_EnemyBirthTime = Time.time;
				if (m_isDebug)Debug.Log ("Enemy created " + m_InGameEnemies [m_randomEnemyNumber].name + " at --------- " + m_EnemyBirthTime);
				m_isFirstEnemyCreated = true;
			}
		}

		if(m_isFirstEnemyCreated) 
		{
			if((Time.time - m_EnemyBirthTime) > 2.0f)
			{
				if(m_InGameEnemies.Count < m_EnemyList.Count)
				{
					m_randomEnemyNumber = UnityEngine.Random.Range (0, m_EnemyList.Count);
					m_InGameEnemies.Add(m_EnemyList[m_randomEnemyNumber]);

					for(int l_inGameEnemyIndex = 0; l_inGameEnemyIndex < m_InGameEnemies.Count; l_inGameEnemyIndex++)
					{
						m_InGameEnemies[l_inGameEnemyIndex].SetActive(true);
						//Debug.Log("setting to true--- enemy --- " + m_InGameEnemies[l_inGameEnemyIndex].name);
					}
//					if(m_EnemyTypeList[m_randomEnemyNumber].m_EnemyObj.activeSelf == true)
//					{
//						m_EnemyTypeList[m_randomEnemyNumber].m_EnemyObj = Instantiate(m_EnemyTypeList[m_randomEnemyNumber].m_EnemyObj) as GameObject;
//					}

					m_EnemyBirthTime = Time.time;
					//if(m_isDebug)Debug.Log("Next Enemy created " + m_InGameEnemies[m_randomEnemyNumber].name + " at --------- " + m_EnemyBirthTime);
				}
			}
		}

		//enemy deletion testing code
//		if (Input.GetKeyDown (KeyCode.A)) 
//		{
//			m_InGameEnemies.RemoveAt(2);
//			for(int l_inGameEnemyIndex = 0; l_inGameEnemyIndex < m_InGameEnemies.Count; l_inGameEnemyIndex++)
//			{
//				if(!m_InGameEnemies[l_inGameEnemyIndex].activeSelf)
//				{
//					Debug.Log ("Not active at number ==  " + m_InGameEnemies[l_inGameEnemyIndex]);
//				}
//			}
//		}
	}
}