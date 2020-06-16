using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// 奔跑、行走按钮控制.
/// </summary>
public class RunButtonController : MonoBehaviour
{
    public static RunButtonController Instance;

    private Button m_Button;
    private Image m_Image;

    /// <summary>
    /// 行走显示的图片.
    /// </summary>
    [SerializeField]
    private Sprite walkingSprite;

    /// <summary>
    /// 奔跑显示的图片.
    /// </summary>
    [SerializeField]
    private Sprite runningSprite;

    /// <summary>
    /// 状态确认.
    /// </summary>
    private bool isWakling = true;

    public bool IsWakling { get => isWakling; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        m_Button = gameObject.GetComponent<Button>();
        m_Image = gameObject.GetComponent<Image>();

        m_Button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if(IsWakling)
        {
            m_Image.sprite = runningSprite;
        }
        else
        {
            m_Image.sprite = walkingSprite;
        }

        isWakling = !isWakling;
    }
}
