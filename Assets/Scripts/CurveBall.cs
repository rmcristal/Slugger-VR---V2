using System.Collections;
using UnityEngine;

class CurveBall : MonoBehaviour
{
    Rigidbody rigidBody;

    private float amountOfCurve = 300f;
    private float startTime;

    public Transform pitcher;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime < 1.1f)
        {
            rigidBody.AddForce(((-amountOfCurve) * (pitcher.forward))*Time.deltaTime);
            rigidBody.AddForce(((-amountOfCurve) * (pitcher.up))*Time.deltaTime);
        }
    }
    
    //IEnumerator CurveBallMovement()
    //{
    //    float startTime = Time.time;
    //    while (Time.time - startTime < 1.3f)
    //    {
    //        rigidBody.AddForce(((-amountOfCurve) * (pitcher.forward)));
    //        rigidBody.AddForce(((-amountOfCurve) * (pitcher.up)));
    //        yield return null;
    //    }
    //}

}