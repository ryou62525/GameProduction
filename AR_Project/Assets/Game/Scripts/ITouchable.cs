using UnityEngine;

/// <summary>
/// 操作可能なオブジェクトを新しく作るときは
/// このクラスを継承させ、オーバーライドさせてください
/// </summary>

public class ITouchable : MonoBehaviour
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
}