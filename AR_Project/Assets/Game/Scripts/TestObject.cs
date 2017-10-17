using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestObject : ObjectBase
{
    [SerializeField]
    private float _rate = 1;
    private float _rot = -90;

    private Vector2 _startLocation;     //タップ開始時にのポジション
    private Quaternion _startRotation;  //タップ開始時の回転角度

    private Vector2 _velocity;          //移動量
    private Vector2 _ScreenSize;        //スクリーンサイズ

    // debug
    [SerializeField]
    private Text _text = null;

    void Start()
    {
       
    }

    void Update()
    {
		StartCoroutine(UnlockObject());
        _text.GetComponent<Text>().text = transform.localRotation.eulerAngles.ToString();
        Debug.Log("ワールド角度" + transform.eulerAngles);
        Debug.Log("ローカル角度" + transform.localEulerAngles);
    }

    IEnumerator UnlockObject()
    {
        var startAngle = transform.localRotation.eulerAngles.y;

        while (true)
        {
            if (startAngle >= startAngle + 180)
            {
                Debug.Log("解除されました");
                yield break;
            }
            yield return null;
        }
    }

    /// <summary>
    /// Touchs the began.
    /// </summary>
    /// <param name="touch">Touch.</param>
    /// <param name="screenSize">Screen size.</param>
	public override void TouchBegan(Touch touch, Vector2 screenSize)
    {
        base.TouchBegan(touch, screenSize);
        Debug.Log(this.name);
        Debug.Log("タッチしました");

        _ScreenSize = screenSize;

        _startLocation = touch.position;
        _startRotation = this.transform.rotation;
    }

    /// <summary>
    /// Mouses the button down.
    /// </summary>
	public override void MouseButtonDown()
    {
        base.MouseButtonDown();
    }

    /// <summary>
    /// Touchs the move.
    /// </summary>
    /// <param name="touch">Touch.</param>
	public override void TouchMove(Touch touch)
    {
        base.TouchMove(touch);

        _velocity.x = (touch.position.x - _startLocation.x) / _ScreenSize.x;
        _velocity.y = (touch.position.y - _startLocation.y) / _ScreenSize.y;
        this.transform.rotation = _startRotation;
        this.transform.Rotate(new Vector3(0, (_rot * _rate) * _velocity.x, 0), Space.World);
    }

    /// <summary>
    /// Touchs the ended.
    /// </summary>
    /// <param name="touch">Touch.</param>
	public override void TouchEnded(Touch touch)
    {
        base.TouchEnded(touch);
        Debug.Log("TouchEnded");
    }
}