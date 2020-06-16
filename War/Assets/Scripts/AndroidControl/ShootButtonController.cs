using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 射击按钮控制.
/// </summary>
public class ShootButtonController : MonoBehaviour
{
    public static ShootButtonController Instance;

    private Button m_Button;

    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        m_Button = gameObject.GetComponent<Button>();
        m_Button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GameObject currentWeapon = ToolBarPanelController.Instance.CurrentWeapon;

        if (currentWeapon != null)
        {
            currentWeapon.GetComponent<GunControllerBase>().LeftMouseButtonDown();
        }
    }
}
