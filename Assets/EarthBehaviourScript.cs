using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBehaviourScript : MonoBehaviour {
   
    private float speed=3f, tempSpeed, cXY;
    public GameObject earth;
    public GameObject text;
    private bool onDrag=false;
    private float axisX;
    private float axisY;
    private float oldRotate;
    private float newRotate;
    // Use this for initialization
    void Start () {
		
	}

    private void OnMouseDown()
    {
        axisX = 0;
        axisY = 0;
        oldRotate = 0;
        Debug.Log("点击了球");
    }
    private void OnMouseDrag()
    {
                
        axisX = -Input.GetAxis("Mouse X");
        axisY = Input.GetAxis("Mouse Y");
        //Debug.Log(axisX + "--" + axisY);
        System.Console.WriteLine(axisX+"--"+axisY);
        cXY = Mathf.Sqrt(axisX * axisX + axisY * axisY);
        onDrag = true;
    }

    float Rigid()
    {
        if (onDrag)
        {
            tempSpeed = speed;
        }
        else
        {
            if (tempSpeed > 0)
            {
                //通过除以鼠标移动长度实现拖拽越长速度减缓越慢    
                if (cXY != 0)
                {
                    tempSpeed -= speed * 2 * Time.deltaTime / cXY;
                }
            }
            else
            {
                tempSpeed = 0;
            }
        }
        return tempSpeed;
    }

    // Update is called once per frame
    void Update () {
        
        float rigidSpeed = Rigid();
        gameObject.transform.Rotate(new Vector3(axisY,axisX,0)* rigidSpeed, Space.World);
        if (rigidSpeed >= 0)
        {
            text.SendMessage("getMessage", gameObject.transform.rotation);
        }
        if (!Input.GetMouseButton(0))
        {
            onDrag = false;
        }
       
    }
}
