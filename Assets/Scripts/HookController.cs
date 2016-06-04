﻿using UnityEngine;
using System.Collections;

public class HookController : MonoBehaviour {
	
	public bool side = false;
	public bool checkUp=true;
	public int speed;
	public bool stop=true;
	public bool controll=true;
    public bool isUsed;

    private const int speedUp = 20;
    private int oldSpeed;

    private GameObject currentfish;
    public Sprite sprite;

	Rigidbody rb = new Rigidbody();
	void Start () {
		rb = GetComponent<Rigidbody> ();
        isUsed = false;
        oldSpeed = speed;
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
        if (checkUp == false)
        {
            controll = false;
            stop = false;
            side = false;
        }
    }
    public void hookIn()
	{
        
            speed = speedUp;
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
            isUsed = false;
            speed = oldSpeed;
        }
		if (col.name == "downWall") 
		{
			controll=false;
			side=!side;
		}
  
	}
	void OnTriggerExit(Collider col)
	{
   
        if (col.name == "upWall")
		{
			checkUp=false;
        }

	}

	public GameObject getCurrentFish(){
		return currentfish;
	}

	public void setCurrentFish(GameObject fish){
		this.currentfish = fish;
	}

	public void removeCurrentFish(){
		currentfish = null;
	}



}
