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
        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(0, 0.5F, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            xDeg -= Input.GetAxis("Mouse X") * speed * friction;
            yDeg += Input.GetAxis("Mouse Y") * speed * friction;
            fromRotation = transform.rotation;
            toRotation = Quaternion.Euler(yDeg, xDeg, 0);
            cube1.transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
        }
    }
}
