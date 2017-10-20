using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtils : MonoBehaviour
{
	/// <summary>
	/// Ises the target angle y.
	/// 現在のY軸の角度が目標の2点の角度の範囲内かどうか調べる
	/// </summary>
	/// <returns><c>true</c>, if target angle y was ised, <c>false</c> otherwise.</returns>
	/// <param name="targetEulerAngleY">Target euler angle y.</param>
	/// <param name="thisTransform">This transform.</param>
	public static bool IsTargetAngleY(float targetEulerAngleY, Transform thisTransform, float diff)
	{
		var from = targetEulerAngleY - diff;
		var to = targetEulerAngleY + diff;
		if (from <= thisTransform.localEulerAngles.y && to >= thisTransform.localEulerAngles.y) return true;
		return false;
	}
}
