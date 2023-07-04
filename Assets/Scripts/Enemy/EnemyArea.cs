using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyArea : MonoBehaviour
{
    private Rect _area;

    private void Start()
    {
        BoxCollider2D area = GetComponent<BoxCollider2D>();

        float width = area.bounds.max.x - area.bounds.min.x;
        float height = area.bounds.max.y - area.bounds.min.y;

        _area = new Rect(area.bounds.min.x, area.bounds.min.y, width, height);
        // Destroy(area);
    }

    private void Update()
    {
        if (transform.position.x >= _area.max.x
            || transform.position.x <= _area.min.x
            || transform.position.y >= _area.max.y
            || transform.position.y <= _area.min.y)
        {
            print("out of area");
        }
        else
        {
            print("in area");
        }
    }
}
