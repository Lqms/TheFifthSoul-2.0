using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _itemPrefab;

    private List<T> _items = new List<T>();

    protected T GetItem()
    {
        var item = _items.FirstOrDefault(i => i.gameObject.activeSelf == false);

        if (item == null)
        {
            item = Instantiate(_itemPrefab);
            _items.Add(item);
        }

        return item;
    }
}
