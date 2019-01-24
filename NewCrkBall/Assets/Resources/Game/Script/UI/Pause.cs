using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private GameObject UI;
    [SerializeField] private TextMesh point;
    [SerializeField] private GameController gameController;
    private void OnMouseDown()
    {
        point.text = gameController.getPoint().ToString();
        Color buffer = background.color;
        buffer.a = 0.5f;
        background.color = buffer;
        gameObject.GetComponent<Animator>().SetTrigger("Pause");
        GameObject.Find("Click").GetComponent<AudioSource>().Play();
        point.GetComponent<MeshRenderer>().sortingLayerName = "3";
        UI.SetActive(true);
        Time.timeScale = 0;
    }
}