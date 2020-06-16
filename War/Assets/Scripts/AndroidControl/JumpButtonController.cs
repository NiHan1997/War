using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// 跳跃按钮控制.
/// </summary>
public class JumpButtonController : MonoBehaviour
{
    private Button m_Button;
    private FirstPersonController m_FPSController;

    void Start()
    {
        m_Button = gameObject.GetComponent<Button>();
        m_FPSController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();

        m_Button.onClick.AddListener(ButtonClick);
    }

    private void ButtonClick()
    {
        m_FPSController.M_Jump = true;
    }
}
