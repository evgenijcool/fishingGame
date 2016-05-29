using UnityEngine;
using System.Collections;
using Classes;
using Classes.FishFactories;
using Assets.Classes;

public class fishController : MonoBehaviour {

    private Fish fish;
    private IFishFactory ff;
    public bool angry;
    private bool direction = false;
    private bool hooked;
    private float y;

    public Sprite[] sprites;
    
	// Use this for initialization
	void Start () {
        if (angry) ff = new AngryFishFactory(); else ff = new GoodFishFactory();
        fish = ff.generateFish();
        GetComponent<SpriteRenderer>().sprite = sprites[fish.SpriteNumber];
        y = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
            transform.Translate(new Vector3(fish.Speed, 0, 0) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "leftWall") 
        {
            transform.Rotate(Vector3.up, 180);
            direction = !direction;
        }
        if (col.name == "rightWall")
        {
            transform.Rotate(Vector3.up, 180);
            direction = !direction;
        }
        if (col.name == "hook")
        {
            HookController hook = ((HookController)FindObjectOfType(typeof(HookController)));

			if (!hook.isUsed)
            {
                hooked = true;
				transform.position = hook.transform.position;
                transform.Rotate(Vector3.forward, 90);

                hook.isUsed = true;
                hook.stop = false;
                hook.side = false;
                fish.Speed = ((HookController)FindObjectOfType(typeof(HookController))).speed;
            }
        }
        if (col.name == "upWall")
        {
            transform.Rotate(Vector3.forward, -90);
            transform.position = new Vector3(-55.4F, y, 9.3F);
            fish.updateStats();
            fish = ff.generateFish();
            GetComponent<SpriteRenderer>().color = Color.white;
            GetComponent<SpriteRenderer>().sprite = sprites[fish.SpriteNumber]; 
            hooked = false;
            direction = true;
        }
        if (col.name == "upWallEffect")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
