using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
   public float panSpeed = 30f;
   public float panBorderThickness = 10f;
   public float scrollSpeed = 5f;
    public float zoomOut = 38f;
    public float zoomIn = 12f;
    public float panTop = 20f;
    public float panBottom = -20f;
    public float panRight = 35f;
    public float panLeft = -10f;


    void Update()
    {
        if (GameHandler.gameEnded) 
        { 
            this.enabled = false; 
            return; 
        }
        if (Input.GetKeyDown(KeyCode.Escape)){ doMovement = !doMovement;}//Disable Panning
        if (!doMovement) { return; }
        if (Input.GetKey("w")||Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward*panSpeed*Time.deltaTime,Space.World);
        }   
        if (Input.GetKey("s")||Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back*panSpeed*Time.deltaTime,Space.World);
        }   
        if (Input.GetKey("a")||Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left*panSpeed*Time.deltaTime,Space.World);
        }   
        if (Input.GetKey("d")||Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right*panSpeed*Time.deltaTime,Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll*1000 * scrollSpeed*Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, zoomIn, zoomOut);
        pos.z = Mathf.Clamp(pos.z, panBottom, panTop);
        pos.x = Mathf.Clamp(pos.x, panLeft, panRight);
        transform.position = pos;

    }
}
