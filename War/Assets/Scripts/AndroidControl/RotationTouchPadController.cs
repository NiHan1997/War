using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// 触摸板旋转视角控制.
/// </summary>
public class RotationTouchPadController : MonoBehaviour
{
    public static RotationTouchPadController Instance;

    private ETCTouchPad m_ETCTouchPad;
    private FirstPersonController m_FPSController;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        m_ETCTouchPad = gameObject.GetComponent<ETCTouchPad>();
        m_FPSController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();

        m_ETCTouchPad.onMove.AddListener(OnMove);
        m_ETCTouchPad.onMoveEnd.AddListener(OnMoveEnd);
    }

    private void OnMove(Vector2 dir)
    {
        m_FPSController.m_MouseLook.XRotaion = dir.x;
        m_FPSController.m_MouseLook.YRotaion = dir.y;
    }

    private void OnMoveEnd()
    {
        m_FPSController.m_MouseLook.XRotaion = 0;
        m_FPSController.m_MouseLook.YRotaion = 0;
    }
}
