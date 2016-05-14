using UnityEngine;
using System.Collections;

public class cube : MonoBehaviour
{

    // Use this for initialization
    GameObject cube1;
    public float rotateSpeed = 5;

    public float minAngle = 60;
    public float maxAngle = 280;

    int speed;
    float friction;
    float lerpSpeed;
    float xDeg;
    float yDeg;
    Quaternion fromRotation;
    Quaternion toRotation;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
