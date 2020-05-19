using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool pointerOver;

    // Start is called before the first frame update
    void Start()
    {
        pointerOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && pointerOver) {
            SceneManager.LoadScene(1);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        pointerOver = true;
        transform.localScale = Vector3.one * 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData) {
        pointerOver = false;
        transform.localScale = Vector3.one;
    }
}
