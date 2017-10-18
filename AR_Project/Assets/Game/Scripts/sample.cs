using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sample : MonoBehaviour
{
	[SerializeField]
	private float distance = 100;

    [SerializeField]
    private Vector3 _targetAngle;

    [SerializeField]
    private Text _text = null;

    void Start()
    {
        
    }

    void Update()
    {
        _text.text = this.transform.localEulerAngles.ToString();
            
		if (Mathf.DeltaAngle(transform.localEulerAngles.y, _targetAngle.y) < -0.1f)
		{
            transform.Rotate(new Vector3(0f, -5f, 0f),Space.World);
		}
    }
}
