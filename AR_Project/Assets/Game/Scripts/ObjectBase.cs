
using UnityEngine;

/// <summary>
/// 操作可能なオブジェクトを新しく作るときは
/// このクラスを継承させ、オーバーライドさせる。
/// </summary>

public class ObjectBase : MonoBehaviour
{
    [SerializeField]
    public Vector3 _targetAngle;

    /// <summary>
    /// Touchs the began.
    /// </summary>
    /// <param name="touch">Touch.</param>
    /// <param name="screenSize">Screen size.</param>
    public virtual void TouchBegan(Touch touch, Vector2 screenSize)
    {
        Debug.Log("Override TouchBegan");
    }

    /// <summary>
    /// Touchs the move.
    /// </summary>
    /// <param name="touch">Touch.</param>
	public virtual void TouchMove(Touch touch)
	{
        Debug.Log("Override TouchMove");
	}

    /// <summary>
    /// Touchs the ended.
    /// </summary>
    /// <param name="touch">Touch.</param>
    public virtual void TouchEnded(Touch touch)
    {
		Debug.Log("Override TouchEnded");
	}

    /// <summary>
    /// Mouses the button down.
    /// </summary>
    public virtual void MouseButtonDown()
    {
        Debug.Log("MouseButtonDown");
    }

	/// <summary>
	/// Ises the target angle y.
	/// 現在のY軸の角度が目標の2点の角度の範囲内かどうか調べる
	/// </summary>
	/// <returns><c>true</c>, if target angle y was ised, <c>false</c> otherwise.</returns>
	/// <param name="targetEulerAngleY">Target euler angle y.</param>
	/// <param name="thisTransform">This transform.</param>
	public bool IsTargetAngleY(float targetEulerAngleY, Transform thisTransform, float diff)
	{
        var from = targetEulerAngleY - diff;
        var to = targetEulerAngleY + diff;
		if (from <= thisTransform.localEulerAngles.y && to >= thisTransform.localEulerAngles.y) return true;
		return false;
	}
}