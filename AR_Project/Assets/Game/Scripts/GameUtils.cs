using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtils : MonoBehaviour
{
    /// <summary>
    /// Rot dir.
    /// 回転情報
    /// </summary>
    public enum RotDir
    {
        NOT = 0,
        RIGHT = 1,
        LEFT = -1,
    }

    /// <summary>
    /// Ises the target angle y.
    /// 現在のY軸の角度が目標の2点の角度の範囲内かどうか調べる
    /// </summary>
    /// <returns><c>true</c>, if target angle y was ised, <c>false</c> otherwise.</returns>
    /// <param name="targetEulerAngleY">Target euler angle y.</param>
    /// <param name="thisTransform">This transform.</param>
    /// <param name="diff">Diff.</param>
    public static bool IsTargetAngleY(float targetEulerAngleY, Transform thisTransform, float diff)
    {
        var from = targetEulerAngleY - diff;
        var to = targetEulerAngleY + diff;
        if (from <= thisTransform.localEulerAngles.y && to >= thisTransform.localEulerAngles.y) return true;
        return false;
    }

	/// <summary>
	/// Ises the which direction.
	/// 現在の回転方向をint型で返します
	/// </summary>
	/// <returns>The which direction.</returns>
	/// <param name="dirVec">Dir vec.</param>
	public static int IsWhichDirection(float dirVec)
    {
        return (int)Mathf.Sign(dirVec);
    }
}
