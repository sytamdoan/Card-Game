using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public GameObject DisplayArea;

    private GameObject zoomCard;
    // Start is called before the first frame update
    void Start()
    {
        DisplayArea = GameObject.Find("DisplayArea");
    }

    // Update is called once per frame
    public void onHoverEnter()
    {
       if(transform.childCount !=0)
        {
            foreach (Transform child in transform)
            {
                zoomCard = Instantiate(child.gameObject, new Vector3(0, 0), Quaternion.identity);
                zoomCard.layer = LayerMask.NameToLayer("Zoom");
                zoomCard.transform.SetParent(DisplayArea.transform, false);

                RectTransform rect = zoomCard.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(240, 344);
            }
        }
    }

    public void onHoverExt()
    {
        if(DisplayArea.transform.childCount != 0)
        {
            foreach(Transform child in DisplayArea.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
