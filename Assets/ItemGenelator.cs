using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenelator : MonoBehaviour {
    public GameObject carPrehab;
    public GameObject conePrehab;
    public GameObject coinPrehab;
    public GameObject unitychan;
    private float lastItemGeneratedPositionZ;
    public float itemGenerationInterval = 40f;
    private int startPos=-160; 
    private int goalPos = 120;
    private float posRange = 3.4f;
	// Use this for initialization
	void Start () {
		
        this.unitychan = GameObject.Find("unitychan");
        this.lastItemGeneratedPositionZ = unitychan.transform.position.z;
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (unitychan.transform.position.z+10 > lastItemGeneratedPositionZ + itemGenerationInterval)
        {
            if ((lastItemGeneratedPositionZ + itemGenerationInterval) < goalPos)
            {
                lastItemGeneratedPositionZ = unitychan.transform.position.z;
                GenelatorItem();
            }
                //lastItemGeneratedPositionZ = unitychan.transform.position.z+20;
        }
        
    }
    void GenelatorItem()
    {
        

            for (float i = unitychan.transform.position.z+20; i < lastItemGeneratedPositionZ+itemGenerationInterval; i += 15)
            {

                int num = Random.Range(0, 10);
                if (num <= 1)
                {
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrehab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    }
                }
                else
                {
                    for (int j = -1; j < 2; j++)
                    {
                        int item = Random.Range(1, 11);
                        int offsetZ = Random.Range(-5, 6);
                        if (1 <= item && item <= 6)
                        {
                            GameObject coin = Instantiate(coinPrehab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            GameObject car = Instantiate(carPrehab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }
                    }
                }
            }
        
        
    }

}
