using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 单个工具栏物品槽控制器.
/// </summary>
public class ToolBarSlotController : MonoBehaviour
{
    private Transform m_Transform;
    private Image m_Image;
    private Button m_Button;
    private Text m_KeyText;                         // 编号文字.

    private int index = -1;

    private bool isActiveSlot = false;              // 当前物品槽是否激活.

    public bool IsActiveSlot { get => isActiveSlot; }

    void Awake()
    {
        FindAndLoadInit();
    }

    /// <summary>
    /// 查找加载初始化.
    /// </summary>
    private void FindAndLoadInit()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Image = gameObject.GetComponent<Image>();
        m_Button = gameObject.GetComponent<Button>();
        m_KeyText = m_Transform.Find("Key").GetComponent<Text>();

        m_Button.onClick.AddListener(SlotButtonClick);
    }

    /// <summary>
    /// 初始化背包物品槽.
    /// </summary>
    public void InitSlot(int index)
    {
        gameObject.name = "Slot_" + index;
        this.index = index;
        m_KeyText.text = (index + 1).ToString();
    }

    private void SlotButtonClick()
    {
        // 背包面板打开, 不能使用武器.
        if (InputManager.Instance.InventoryState)
            return;

        SendMessageUpwards("SaveActiveSlotByKey", index);
    }

    /// <summary>
    /// 物品槽单击事件.
    /// </summary>
    public void SlotClick()
    {
        if (isActiveSlot)
            NormalSlot();
        else
            ActiveSlot();

        SendMessageUpwards("SaveActiveSlot", gameObject);
    }

    /// <summary>
    /// 物品槽默认状态.
    /// </summary>
    public void NormalSlot()
    {
        m_Image.color = Color.white;
        isActiveSlot = false;
    }

    /// <summary>
    /// 物品槽激活状态.
    /// </summary>
    private void ActiveSlot()
    {
        m_Image.color = Color.red;
        isActiveSlot = true;
    }
}
