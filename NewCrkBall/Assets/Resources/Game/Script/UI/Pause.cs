using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private GameObject UI;
    [SerializeField] private TextMesh point;

    private void OnMouseDown()
    {
        Color buffer = background.color;
        buffer.a = 0.5f;
        background.color = buffer;
        point.GetComponent<MeshRenderer>().sortingLayerName = "3";
        UI.SetActive(true);
        Time.timeScale = 0;
    }
}