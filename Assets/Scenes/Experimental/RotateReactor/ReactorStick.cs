using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

/// <summary>
/// リアクター用のスティックはゲームパッドをシミュレーションする。
/// スティックの回転はリアクターと連動する。
/// </summary>
[AddComponentMenu("Input/On-Screen Stick")]
public class ReactorStick : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private GameObject Reactor;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));

        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out Vector2 position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));

        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out var position);
        var deltaPos = position - (Vector2)StartPos;

        deltaPos = Vector2.ClampMagnitude(deltaPos, movementRange);
        ((RectTransform)transform).anchoredPosition = StartPos + (Vector3)deltaPos;

        var newPos = new Vector2(deltaPos.x / movementRange, deltaPos.y / movementRange);
        SendValueToControl(newPos);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ((RectTransform)transform).anchoredPosition = StartPos;
        SendValueToControl(Vector2.zero);
    }

    private void Start()
    {
        StartPos = ((RectTransform)transform).anchoredPosition;
    }

    private void Update()
    {
        transform.localEulerAngles = Reactor.transform.localEulerAngles;
        // TODO: 急に離したら、ゆっくりと元の位置に戻る
    }

    private float MovementRange = 10;

    [field: SerializeField]
    public float movementRange { get; set; } = 10;
    private Vector3 StartPos;
    [field: InputControl(layout = "Vector2")]
    [field: SerializeField]
    protected override string controlPathInternal { get; set; } = "<Gamepad>/leftStick";
}
