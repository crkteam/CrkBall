using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background, centerImage;
    [SerializeField] private TextMesh point;

    private void OnMouseDown()
    {
        Color buffer = background.color;
        buffer.a = 0.5f;
        background.color = buffer;
        Time.timeScale = 0;
    }
}