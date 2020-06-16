﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 工具栏模块C层.
/// </summary>
public class ToolBarPanelController : MonoBehaviour
{
    public static ToolBarPanelController Instance;

    private ToolBarPanelView m_ToolBarPanelView;

    private const int slotsNum = 8;                             // 工具栏物品槽数量.
    private List<GameObject> slotsList;                         // 工具栏物品槽集合.

    private GameObject currentActiveSlot;                       // 当前激活的物品槽.
    private GameObject currentWeapon;                           // 当前选中武器.

    private Dictionary<GameObject, GameObject> toolBarDic;      // 工具栏和实例武器对应.
    public GameObject CurrentWeapon { get => currentWeapon; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        FindAndLoadInit();
        CreateAllSlot();
    }

    /// <summary>
    /// 查找加载初始化.
    /// </summary>
    private void FindAndLoadInit()
    {
        m_ToolBarPanelView = gameObject.GetComponent<ToolBarPanelView>();

        slotsList = new List<GameObject>(slotsNum);
        toolBarDic = new Dictionary<GameObject, GameObject>();
    }

    /// <summary>
    /// 创建全部工具栏物品槽.
    /// </summary>
    private void CreateAllSlot()
    {
        for (int i = 0; i < slotsNum; ++i)
        {
            GameObject slot = GameObject.Instantiate<GameObject>(m_ToolBarPanelView.Prefab_Slot,
                m_ToolBarPanelView.Grid_Transform);
            slot.GetComponent<ToolBarSlotController>().InitSlot(i);
            slotsList.Add(slot);
        }
    }

    /// <summary>
    /// 存储当前激活的物品槽.
    /// </summary>
    private void SaveActiveSlot(GameObject activeSlot)
    {
        if (currentActiveSlot != null && currentActiveSlot != activeSlot)
        {
            currentActiveSlot.GetComponent<ToolBarSlotController>().NormalSlot();
        }
        currentActiveSlot = activeSlot;
        CallGunFactory();
    }

    /// <summary>
    /// 通过按键存储激活的物品槽.
    /// </summary>
    public void SaveActiveSlotByKey(int keyIndex)
    {
        if (slotsList[keyIndex].GetComponent<Transform>().Find("InventoryItem") == null)
            return;

        slotsList[keyIndex].GetComponent<ToolBarSlotController>().SlotClick();        
    }

    /// <summary>
    /// 调用枪械工厂生成武器.
    /// </summary>
    private void CallGunFactory()
    {
        Transform weaponTransform = currentActiveSlot.GetComponent<Transform>().Find("InventoryItem");
        StartCoroutine("ChangeWeapon", weaponTransform);
    }

    /// <summary>
    /// 武器切换或者卸载.
    /// </summary>
    private IEnumerator ChangeWeapon(Transform weaponTransform)
    {
        if (weaponTransform != null)
        {
            // 隐藏当前武器.
            if (currentWeapon != null)
            {
                // 建造和采集的动作需要特殊处理.
                if (currentWeapon.tag == "BuildingPlan")
                    currentWeapon.GetComponent<BuildingPlan>().HolsterBuildingPlan();
                else if (currentWeapon.tag == "StoneHatchet")
                    currentWeapon.GetComponent<StoneHatchet>().HolsterStoneHatchet();
                else
                    currentWeapon.GetComponent<GunControllerBase>().HolsterWeapon();                

                yield return new WaitForSeconds(1);
                currentWeapon.SetActive(false);
            }

            // 从字典查找实例.
            GameObject weapon = null;
            toolBarDic.TryGetValue(weaponTransform.gameObject, out weapon);

            // 字典没有, 生成武器.
            if (weapon == null)
            {
                weapon = GunFactory.Instance.CreateGun(weaponTransform.GetComponent<Image>().sprite.name, weaponTransform.gameObject);
                toolBarDic.Add(weaponTransform.gameObject, weapon);
            }

            // 有武器, 直接取数据.
            else
            {
                if (currentActiveSlot.GetComponent<ToolBarSlotController>().IsActiveSlot)
                    weapon.SetActive(true);
            }

            // 更新引用.
            currentWeapon = weapon;
        }
    }
}
