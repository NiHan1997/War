using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 背包按钮控制.
/// </summary>
public class InventoryButtonController : MonoBehaviour
{
    public static InventoryButtonController Instance;

    private Button m_Button;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        m_Button = gameObject.GetComponent<Button>();
        m_Button.onClick.AddListener(ButtonClick);
    }

    private void ButtonClick()
    {
        InputManager.Instance.InventoryPanelKey();
    }
}
