using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Start()
    {
        StartCoroutine(Following());
    }

    private IEnumerator Following()
    {
        while (true)
        {
            transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
            yield return null;
        }
    }
}
