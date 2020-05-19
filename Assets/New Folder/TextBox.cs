using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public Text name;
    public Text text;
    public bool typing;

    // Start is called before the first frame update
    void Start()
    {
        typing = false;
        transform.localPosition = new Vector3(0f, -200f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Display(string nameA, string textA) {
        typing = true;

        name.text = nameA;
        text.text = "";
        transform.localPosition = new Vector3(0f, 85f, 0f);

        int character = 0;

        while (text.text.Length < textA.Length) {
            text.text = textA.Substring(0, character);
            character += 1;
            yield return null;
        }

        while (!Input.GetMouseButtonDown(0)) {
            yield return null;
        }
        typing = false;
        transform.localPosition = new Vector3(0f, -200f, 0f);
    }
}
