using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestObject : ITouchable
{
    [SerializeField]
    private float _rate = 1;
    private float _rot = -90;

    [SerializeField]
    private float _difference = 0;      //補正する値

    private Vector2 _startLocation;     //タップ開始時のポジション
    private Quaternion _startRotation;  //タップ開始時の回転角度

    private Vector2 _velocity;          //移動量
    private Vector2 _ScreenSize;        //スクリーンサイズ

    // debug
    [SerializeField]
    private Text _text = null;

    private GameObject _childObj = null;

    void Start()
    {

    }

    void Update()
    {
        _text.GetComponent<Text>().text = transform.localRotation.eulerAngles.ToString();
        //Debug.Log("ワールド角度" + transform.eulerAngles);
        //Debug.Log("ローカル角度" + transform.localEulerAngles);
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

        var obj = gameObject.GetComponentInChildren<Transform>();
        Debug.Log("回転角度" + obj.rotation);

        _ScreenSize = screenSize;
        _startLocation = touch.position;
        _startRotation = this.transform.rotation;
        Debug.Log("StartRotation" + _startRotation.eulerAngles);
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
        var isTargetAngle = GameUtils.IsTargetAngleY(_targetAngle.y, this.transform, _difference);

        Debug.Log("回転方向" + GameUtils.IsWhichDirection(_velocity.x));

        if ( GameUtils.IsWhichDirection(_velocity.x) == (int)GameUtils.RotDir.RIGHT && isTargetAngle )
        {
            Debug.Log("ロック解除");
            this.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.5f);
        }
        else
        {
            Debug.Log("ロック中");
        }

        _velocity.x = (touch.position.x - _startLocation.x) / _ScreenSize.x;
        _velocity.y = (touch.position.y - _startLocation.y) / _ScreenSize.y;
        this.transform.rotation = _startRotation;
        this.transform.Rotate(new Vector3(0, (_rot * _rate) * _velocity.x, 0), Space.World);
        Debug.Log("X" + _velocity.x);
    }

    /// <summary>
    /// Touchs the ended.
    /// </summary>
    /// <param name="touch">Touch.</param>
	public override void TouchEnded(Touch touch)
    {
        base.TouchEnded(touch);
        Debug.Log("TouchEnded");
        //_startRotation = Quaternion.identity;
    }
}