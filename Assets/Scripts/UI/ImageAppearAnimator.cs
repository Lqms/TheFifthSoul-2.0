using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageAppearAnimator : MonoBehaviour
{
    [SerializeField] private float _animationSpeed = 3;
    [SerializeField] private float _startDelay;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();

        StartCoroutine(Appearing());
    }

    private IEnumerator Appearing()
    {
        yield return new WaitForSeconds(_startDelay);

        float alpha = _image.color.a;

        while (alpha <= 1)
        {
            yield return null;
            alpha += Time.deltaTime * _animationSpeed;
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, alpha);
        }
    }
}
