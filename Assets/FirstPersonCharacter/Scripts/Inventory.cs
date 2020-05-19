using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    public List<GameObject> activeIcons = new List<GameObject>();
    public List<string> inv = new List<string>();
    public List<string> key = new List<string>();
    public List<Sprite> icons = new List<Sprite>();

    public GameObject blankIcon;
    public Transform canvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(string name) {
        inv.Add(name);
        SetInv();
    }

    public void RemoveItem(string name) {
        inv.Remove(name);
        SetInv();
    }

    public void SetInv() {
        foreach (GameObject thing in activeIcons) {
            Destroy(thing);
        }
        activeIcons = new List<GameObject>();

        foreach (string item in inv) {
            GameObject newIcon = Instantiate(blankIcon, Vector3.zero, Quaternion.identity) as GameObject;
            newIcon.transform.parent = canvas;
            newIcon.transform.localScale = Vector3.one * 1.24f;
            newIcon.transform.localPosition = spawnPoints[activeIcons.Count].transform.localPosition;
            activeIcons.Add(newIcon);
            newIcon.GetComponent<Image>().sprite = icons[key.IndexOf(item)];
        }
    }
}
