﻿using UnityEngine;
using System.Collections;

public class HookController : MonoBehaviour {
	
	public bool side = false;
	public bool checkUp=true;
	public int speed;
	public bool stop=true;
	public bool controll=true;
	Rigidbody rb = new Rigidbody();
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update()
	{

		if (!stop) 
		{
			if (side) 
			{
				transform.Translate (new Vector3 (0, -speed, 0) * Time.deltaTime);
			} else 
			{
				transform.Translate (new Vector3 (0, speed, 0) * Time.deltaTime);
			}
		}
	}
	public void HookUp()
	{
		if (checkUp == false) {
			stop = false;
			side = false;
		}
	}
	public void HookDown()
	{
		if(controll==true)
		{
			stop=false;
			side=true;
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.name == "upWall") 
		{
			stop = true;
			controll=true;
			checkUp=true;
		}
		if (col.name == "downWall") 
		{
			controll=false;
			side=!side;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.name == "upWall")
		{
			checkUp=false;
		}

	}
}
