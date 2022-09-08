using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DragDrop : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject Canvas;
    public GameObject DropZone;
    public PlayerManager PlayerManager; 

    private bool isDragging = false;
    private bool isOverDropZone = false;
    private bool isDraggable = true;
    private GameObject startParent;
    private GameObject dropZone;
    private Vector2 startPosition;

    public void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        DropZone = GameObject.Find("DropZone");
        if (!hasAuthority)
        {
            isDraggable = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        if (!isDraggable) return;
        startPosition = transform.position;
        startParent = transform.parent.gameObject;
        isDragging = true;
    }

    public void EndDrag()
    {
        if (!isDraggable) return;
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            isDraggable = false;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<PlayerManager>();
            PlayerManager.PlayCard(gameObject);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}