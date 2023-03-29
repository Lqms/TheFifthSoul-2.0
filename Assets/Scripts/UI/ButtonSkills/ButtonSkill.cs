using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonSkill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ButtonSkillData _data;
    [SerializeField] private ButtonSkill[] _openningSkills;
    [SerializeField] private Image[] _openningLinks;

    [Header("Components")]
    [SerializeField] private Image _infoPanel;
    [SerializeField] private Image _levelPanel;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _currentLevel;

    [Header("Settings")]
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _header;
    [SerializeField] private TMP_Text _description;

    private int _currentSkillLevel = 0;
    private int _maxLevel;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void Start()
    {
        _icon.sprite = _data.Icon;
        _header.text = _data.Header;
        _description.text = _data.Description;
        _currentLevel.text = _currentSkillLevel.ToString();
        _maxLevel = _data.MaxLevel;
        _infoPanel.gameObject.SetActive(false);
    }

    private void OnButtonClicked()
    {
        _currentSkillLevel++;

        if (_currentSkillLevel == _maxLevel)
        {
            foreach (var skill in _openningSkills)
                skill.Activate();

            foreach (var link in _openningLinks)
                link.color = Color.yellow;

            _button.interactable = false;
        }

        _currentLevel.text = _currentSkillLevel.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _infoPanel.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _infoPanel.gameObject.SetActive(false);
    }

    public void Activate()
    {
        _button.interactable = true;
        _icon.color = Color.white;
        _levelPanel.gameObject.SetActive(true);
    }
}
