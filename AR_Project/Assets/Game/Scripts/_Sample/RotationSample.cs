using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSample : MonoBehaviour
{
    public float angle = 1;



    void Update()
    {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		transform.Translate(Quaternion.AngleAxis(angle, Vector3.up) * new Vector3(horizontal, 0, vertical), Space.World );
    }
}