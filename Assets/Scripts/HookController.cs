using UnityEngine;

public class HookController : MonoBehaviour {
	public bool side = false;
	public int speed;
	public bool stop=true;
	public bool controll=true;
    public bool isUsed;
    public Sprite sprite;

    private const int speedUp = 20;
    private int oldSpeed;
    private bool checkUp = true;
    
	void Start () {
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
}
