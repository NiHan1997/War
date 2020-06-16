using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// 摇杆移动控制器.
/// </summary>
public class MoveJoystickController : MonoBehaviour
{
    public static MoveJoystickController Instance;

    private ETCJoystick m_ETCJoystick;
    private FirstPersonController m_FPSController;

    private Vector2 moveDir = Vector2.zero;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        m_ETCJoystick = gameObject.GetComponent<ETCJoystick>();
        m_FPSController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();

        m_ETCJoystick.onMove.AddListener(OnMoveEvent);
        m_ETCJoystick.onMoveEnd.AddListener(OnMoveEndEvent);
    }

    private void OnMoveEvent(Vector2 dir)
    {
        m_FPSController.GetInputByJoystick(dir, RunButtonController.Instance.IsWakling);
    }

    private void OnMoveEndEvent()
    {
        m_FPSController.GetInputByJoystick(Vector2.zero, RunButtonController.Instance.IsWakling);
    }
}
