using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DivineForge : MonoBehaviour, IInteractive
{
    [Header("Buttons")]
    [SerializeField] private Button _armorPanelButton;
    [SerializeField] private Button _swordPanelButton;

    [Header("Panels")]
    [SerializeField] private GameObject _upgradesPanel;
    [SerializeField] private GameObject _swordUpgradePanel;
    [SerializeField] private GameObject _armorUpgradePanel;

    private void Start()
    {
        _upgradesPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _armorPanelButton.onClick.AddListener(OnArmorPanelButtonClicked);
        _swordPanelButton.onClick.AddListener(OnSwordPanelButtonClicked);
    }

    private void OnDisable()
    {
        _armorPanelButton.onClick.RemoveListener(OnArmorPanelButtonClicked);
        _swordPanelButton.onClick.RemoveListener(OnSwordPanelButtonClicked);
    }

    private void OnArmorPanelButtonClicked()
    {
        _swordUpgradePanel.SetActive(false);
        _armorUpgradePanel.SetActive(true);
    }

    private void OnSwordPanelButtonClicked()
    {
        _swordUpgradePanel.SetActive(true);
        _armorUpgradePanel.SetActive(false);
    }

    public void Use()
    {
        Time.timeScale = 0;
        _upgradesPanel.gameObject.SetActive(true);
        UIManager.AddNewOpennedModal(_upgradesPanel);

        _swordUpgradePanel.gameObject.SetActive(true);
    }
}
