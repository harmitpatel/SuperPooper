using UnityEngine;
using System.Collections;
using System;


public enum m_EMoveDirectionCondition
{
	left,
	right,
	none
}

[ExecuteInEditMode]
public class PlayerMovement : MonoBehaviour 
{

	[SerializeField]
	private m_EMoveDirectionCondition m_moveDirectionEnum = m_EMoveDirectionCondition.none;

	[SerializeField]
	private GameObject m_Player;

	[SerializeField]
	private FoodAppearDisappear m_foodAppearDissapearObject = null;

	[SerializeField]
	private Vector3 m_PlayerPosition  = new Vector3(0,0,0);

	[SerializeField]
	private float m_PlayerLeftMoveSpeed = 0.0f;

	[SerializeField]
	private bool m_hasReachedLeft = false;

	[SerializeField]
	private bool m_hasReachedRight = false;

	// Use this for initialization
	void Start () 
	{
		m_PlayerPosition = m_Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_moveDirectionEnum == m_EMoveDirectionCondition.none) 
		{
			if (Input.GetKey(KeyCode.A))
			{
				if(!m_hasReachedLeft)
				{
					m_moveDirectionEnum = m_EMoveDirectionCondition.left;
				}
			}
			
			if (Input.GetKey(KeyCode.D))
			{
				if(!m_hasReachedRight)
				{
					m_moveDirectionEnum = m_EMoveDirectionCondition.right;
				}
			}
		}


		else
		{
			m_moveDirectionEnum = m_EMoveDirectionCondition.none;
		}

		switch (m_moveDirectionEnum) 
		{
		case m_EMoveDirectionCondition.left:
			MoveLeft();
			break;
		case m_EMoveDirectionCondition.right:
			MoveRight();
			break;
		case m_EMoveDirectionCondition.none:
			//Debug.Log("Player must Stay still");
			break;
		}

		m_Player.transform.position = m_PlayerPosition;
	}

	private void MoveLeft()
	{
		m_PlayerPosition.x -= m_PlayerLeftMoveSpeed * Time.deltaTime;
	}

	private void MoveRight()
	{
		m_PlayerPosition.x += m_PlayerLeftMoveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("LeftBoundaryMarker")) 
		{
			m_hasReachedLeft = true;
			m_hasReachedRight = false;
			m_moveDirectionEnum = m_EMoveDirectionCondition.none;
			//Debug.Log ("entered left boundary");
		}

		if (other.CompareTag ("RightBoundaryMarker")) 
		{
			m_hasReachedRight = true;
			m_hasReachedLeft = false;
			m_moveDirectionEnum = m_EMoveDirectionCondition.none;
			//Debug.Log ("entered right boundary");
		}

		if (other.CompareTag ("food")) 
		{
			Debug.Log ("grabbing food");
			m_foodAppearDissapearObject.m_IsGrabbedFood = true;
		}

	} 

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("LeftBoundaryMarker")) 
		{
			m_hasReachedLeft = false;
			//Debug.Log ("exitting left boundary");
		}

		if (other.CompareTag ("RightBoundaryMarker")) 
		{
			m_hasReachedRight = false;
			//Debug.Log ("exitting right boundary");
		}

		if (other.CompareTag ("food")) 
		{
			Debug.Log ("Ungrabbing food");
			m_foodAppearDissapearObject.m_IsGrabbedFood = false;
		}

	}
}