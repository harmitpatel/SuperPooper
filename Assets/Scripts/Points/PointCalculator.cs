using UnityEngine;
using System.Collections;

public class PointCalculator : MonoBehaviour 
{
	public float m_Score = 0.0f;
	public float M_Score 
	{
		get 
		{
			return m_Score++;
		}
		set 
		{
			m_Score = value;
		}
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
}