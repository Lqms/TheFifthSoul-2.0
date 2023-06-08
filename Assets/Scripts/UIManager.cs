using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static Stack<GameObject> _opennedModals;

    private void Start()
    {
        _opennedModals = new Stack<GameObject>();
    }

    private void Update()
    {
        if (PlayerInput.CheckCloseActiveModalKeyDown() && _opennedModals.Count != 0)
        {
            var lastOpennedModal = _opennedModals.Pop();
            lastOpennedModal.gameObject.SetActive(false);

            if (_opennedModals.Count == 0)
                Time.timeScale = 1;
        }
    }

    public static void AddNewOpennedModal(GameObject modal)
    {
        _opennedModals.Push(modal);
    }
}
