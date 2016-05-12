using UnityEngine;
using System.Collections;

public class TestWall : MonoBehaviour {

    GameObject []testWall = new GameObject[5];
	// Use this for initialization
	void Start () {
        /*for(int i=0; i < 4; i++) { 
        testWall[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (i % 2 == 0)
            {
                
            }
            else
            { 
                testWall[i].transform.localScale = new Vector3(0.01F, 2, 2);
                testWall[i].transform.position = new Vector3(i, 1, 1);
            }
            }
            */
        testWall[0] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        testWall[0].transform.localScale = new Vector3(2, 2, 0.01F);
        testWall[0].transform.position = new Vector3(1, 1, 0);
        testWall[0].transform.eulerAngles = new Vector3(0, 90, 0);

        testWall[1] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        testWall[1].transform.localScale = new Vector3(2, 2, 0.01F);
        testWall[1].transform.position = new Vector3(-1, 1, 0);
        testWall[1].transform.eulerAngles = new Vector3(0, -45, 0);

        testWall[2] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        testWall[2].transform.localScale = new Vector3(2, 2, 0.01F);
        testWall[2].transform.position = new Vector3(0, 1, 1);
        //testWall[2].transform.eulerAngles = new Vector3(0, -45, 0);

        testWall[3] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        testWall[3].transform.localScale = new Vector3(2, 2, 0.01F);
        testWall[3].transform.position = new Vector3(0, 1, -1);
        //testWall[3].transform.eulerAngles = new Vector3(0, -45, 0);

        testWall[4] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        testWall[4].transform.localScale = new Vector3(0.01F, 2, 2);
        testWall[4].transform.position = new Vector3(-1, 1, 0);
        //testWall[4].transform.eulerAngles = new Vector3(0, -45, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
