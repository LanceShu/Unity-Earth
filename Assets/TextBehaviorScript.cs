using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBehaviorScript : MonoBehaviour {
    // Use this for initialization
    public GameObject text;
    public GameObject ball;
    public GameObject camera;
    private float axisY;
    private float axisX;
    private float rigidSpeed;
    private Quaternion quaternion;
    private float angle;
    private bool touch = false;

    void Start () {
       // Debug.Log(gameObject.name);

    }
    void getMessage(Quaternion str)
    {
        quaternion = str;
        
    }
    private void OnMouseDown()
    {
        Debug.Log("text");
        touch = true;
        

    }
    // Update is called once per frame
    void Update () {
        //text.transform.RotateAround(ball.transform.localPosition, new Vector3(axisY, axisX, 0), 180*Time.deltaTime);
        text.transform.rotation = quaternion;
        angle = Vector3.Angle(text.transform.forward, camera.transform.forward);
        if (touch)
        {
            Vector3 targetDir = text.transform.position - ball.transform.position;
            // 圆心到摄像机的向量  
            Vector3 cameraDir = -Vector3.forward;
            // 求出两个向量的旋转角度  
            Quaternion rotation = Quaternion.FromToRotation(targetDir, cameraDir) * transform.rotation;
            // 大球旋转插值旋转这个角度  
            ball.transform.rotation = Quaternion.Slerp(ball.transform.rotation, rotation, Time.deltaTime * 3f);

            if (targetDir == -cameraDir)
                touch = false;
        }

       
        //GameObject gameObject = GameObject.Find("Sphere");
        //EarthBehaviourScript earthScript = gameObject.GetComponent<EarthBehaviourScript>();
        //float i = earthScript.speed;
        //Debug.Log(i);
    }
}
