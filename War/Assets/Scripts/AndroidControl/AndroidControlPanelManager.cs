using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 安卓控制面板管理器.
/// </summary>
public class AndroidControlPanelManager : MonoBehaviour
{
    public static AndroidControlPanelManager Instance;

    private Transform m_Transform;

    private GameObject moveJoystick;            // 角色移动摇杆UI.
    private GameObject runButton;               // 角色奔跑按钮.
    private GameObject jumpButton;              // 角色跳跃按钮.
    private GameObject aimButton;               // 角色瞄准按钮.
    private GameObject shootButton;             // 角色射击按钮.
    private GameObject inventoryButton;         // 背包面板按钮.
    private GameObject rotationTouchPad;        // 角色旋转触摸板.

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        FindAndLoadInit();
    }

    /// <summary>
    /// 查找加载初始化.
    /// </summary>
    private void FindAndLoadInit()
    {
        m_Transform = gameObject.GetComponent<Transform>();

        moveJoystick = m_Transform.Find("Move Joystick").gameObject;
        runButton = m_Transform.Find("Run Button").gameObject;
        jumpButton = m_Transform.Find("Jump Button").gameObject;
        aimButton = m_Transform.Find("Aim Button").gameObject;
        shootButton = m_Transform.Find("Shoot Button").gameObject;
        inventoryButton = m_Transform.Find("Inventory Button").gameObject;
        rotationTouchPad = m_Transform.Find("Rotation TouchPad").gameObject;
    }

    /// <summary>
    /// 背包显示事件..
    /// </summary>
    public void InventoryPanelShow()
    {
        moveJoystick.SetActive(false);
        runButton.SetActive(false);
        jumpButton.SetActive(false);
        aimButton.SetActive(false);
        shootButton.SetActive(false);
        rotationTouchPad.SetActive(false);
    }

    /// <summary>
    /// 背包隐藏事件.
    /// </summary>
    public void InventoryPanelHide()
    {
        moveJoystick.SetActive(true);
        runButton.SetActive(true);
        jumpButton.SetActive(true);
        aimButton.SetActive(true);
        shootButton.SetActive(true);
        rotationTouchPad.SetActive(true);
    }
}
