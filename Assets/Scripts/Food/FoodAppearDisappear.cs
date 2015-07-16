using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class FoodPositionSetter
{
	public GameObject m_FoodItem;
	public int m_FoodPositionNumber = 0;
	public bool m_isFoodSet = false;
	public bool m_isFoodGrabbed = false;
	public int m_FoodEatenCount = 0;
}

[ExecuteInEditMode]
public class FoodAppearDisappear : MonoBehaviour 
{
	[SerializeField]
	private List<FoodPositionSetter> m_ListOfFoodPositions = new List<FoodPositionSetter>();

	[SerializeField]
	float m_currentTime = 0.0f;

	[SerializeField]
	private int m_RandomPositionNumber = 0;

	[SerializeField]
	private bool m_isAnyFoodCreated = false;

	public bool m_IsGrabbedFood = false;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < m_ListOfFoodPositions.Count; i++)
		{
			m_ListOfFoodPositions[i].m_FoodItem.SetActive(false);
			//Debug.Log ("Setting all to false before start");
		}

		m_RandomPositionNumber = UnityEngine.Random.Range(1,5);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if (Input.GetKeyDown (KeyCode.G)) 
		{
			if(!m_isAnyFoodCreated)
			{
				m_RandomPositionNumber = UnityEngine.Random.Range(0,(m_ListOfFoodPositions.Count - 1));
				//Debug.Log("random number generated is --- " + m_RandomPositionNumber);
				m_ListOfFoodPositions[m_RandomPositionNumber].m_FoodItem.SetActive(true);
				m_ListOfFoodPositions[m_RandomPositionNumber].m_FoodEatenCount++;
				m_ListOfFoodPositions[m_RandomPositionNumber].m_isFoodSet = true;
				m_currentTime = Time.time;
				//Debug.Log("time at which made visible --- " + m_currentTime);
				//Debug.Log("visible GO -- " + m_ListOfFoodPositions[m_RandomPositionNumber].m_FoodItem.name);
			}
		}

		for (int i = 0; i < m_ListOfFoodPositions.Count; i++)
		{
			if(m_ListOfFoodPositions[i].m_FoodItem.activeSelf)
			{
				m_isAnyFoodCreated = true;
			}
		}

		if(m_isAnyFoodCreated)
		{
			if ((Time.time - m_currentTime) >= 2.0f) 
			{
				m_ListOfFoodPositions[m_RandomPositionNumber].m_FoodItem.SetActive(false);
				m_ListOfFoodPositions[m_RandomPositionNumber].m_isFoodSet = false;
				//Debug.Log("Setting false -- " + m_ListOfFoodPositions[m_RandomPositionNumber].m_FoodItem.name);
				m_isAnyFoodCreated = false;
			}
		}

		if (m_IsGrabbedFood) 
		{
			Debug.Log("You just grabbed a food item" + m_ListOfFoodPositions[m_RandomPositionNumber].m_FoodItem.name);
			m_ListOfFoodPositions[m_RandomPositionNumber].m_isFoodGrabbed = true;
		}

		if (!m_IsGrabbedFood) 
		{
			m_ListOfFoodPositions[m_RandomPositionNumber].m_isFoodGrabbed = false;
		}
	}
}