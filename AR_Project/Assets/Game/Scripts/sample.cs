using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
	[SerializeField]
	private float distance = 100;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("is touch");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, distance))
            {
                var obj = hit.collider.gameObject;
                if (obj)
                {
                    obj.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
                }

            }
        }
    }
}
