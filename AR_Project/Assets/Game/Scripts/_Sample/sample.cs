using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sample : MonoBehaviour
{
    [SerializeField]
    private Vector3 _targetAngle;

    [SerializeField]
    private Text _text = null;

    [SerializeField]
    private Vector3 _fromAngle,
                    _toAngle;

    void Start()
    {
        _fromAngle.y = _targetAngle.y + 10;
        _toAngle.y = _targetAngle.y + 20;
	}

    void Update()
    {
        _text.text = this.transform.localEulerAngles.ToString();

        if(isTargetAngleY(_fromAngle.y, _toAngle.y, this.transform.eulerAngles.y))
        {
            Debug.Log("目的の角度です");
        }
        else
        {
            Debug.Log("目的の角度の範囲外です");
        }

		if (Input.GetKey("right")){ transform.Rotate(0f, 1f, 0f); }
        if (Input.GetKey("left")){ transform.Rotate(0f, -1f, 0f); }

	}

	/// <summary>
	/// Ises the target angle y.
	/// 現在のY軸の角度が目標の2点の角度の範囲内かどうか調べる
	/// </summary>
	/// <returns><c>true</c>, if target angle y was ised, <c>false</c> otherwise.</returns>
	/// <param name="fromY">From y.</param>
	/// <param name="toY">To y.</param>
	/// <param name="targetEulerAngleY">Target euler angle y.</param>
	bool isTargetAngleY(float fromY, float toY, float targetEulerAngleY)
    {
        if( fromY <= targetEulerAngleY && toY >= targetEulerAngleY )return true;
        return false;
    }
}
