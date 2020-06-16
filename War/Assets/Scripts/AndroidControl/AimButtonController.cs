using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 开镜瞄准按键控制.
/// </summary>
public class AimButtonController : MonoBehaviour
{
    public static AimButtonController Instance;

    private Button m_Button;
    private Image m_Image;

    /// <summary>
    /// 按钮默认状态的图片.
    /// </summary>
    [SerializeField]
    private Sprite normalSprite;

    /// <summary>
    /// 按钮按下后显示的图片.
    /// </summary>
    [SerializeField]
    private Sprite downSprite;

    /// <summary>
    /// 当前是否是瞄准状态.
    /// </summary>
    private bool isAim = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        m_Button = gameObject.GetComponent<Button>();
        m_Image = gameObject.GetComponent<Image>();

        m_Button.onClick.AddListener(ButtonClick);
    }

    private void ButtonClick()
    {
        GameObject currentWeapon = ToolBarPanelController.Instance.CurrentWeapon;
        if (currentWeapon == null) return;

        if (isAim)
        {
            m_Image.sprite = normalSprite;

            if (currentWeapon.tag !=  "BuildingPlan" && currentWeapon.tag != "StoneHatchet")
            {
                currentWeapon.GetComponent<GunControllerBase>().RightMouseButtonDown();
            }
        }
        else
        {
            m_Image.sprite = downSprite;
            if (currentWeapon.tag != "BuildingPlan" && currentWeapon.tag != "StoneHatchet")
            {
                currentWeapon.GetComponent<GunControllerBase>().RightMouseButtonUp();
            }
        }

        isAim = !isAim;
    }
}
