using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBehaviorScript : MonoBehaviour {
    // Use this for initialization
    public GameObject text;
    public GameObject ball;
    private float axisY;
    private float axisX;
    private float rigidSpeed;
    private Quaternion quaternion;
    void Start () {
       // Debug.Log(gameObject.name);

    }
    void getMessage(Quaternion str)
    {
        quaternion = str;
        //string[] strs = str.Split(' ');
        //if (float.Parse(strs[0]) <= 0)
        //    rigidSpeed = 0;
        //else
        //    rigidSpeed=float.Parse(strs[0]);
        //axisX = float.Parse(strs[1]);
        //axisY = float.Parse(strs[2]);
        //Debug.Log("text:"+ rigidSpeed);
    }
    private void OnMouseDown()
    {
        Debug.Log("点击了Text");
    }
    // Update is called once per frame
    void Update () {
        //text.transform.RotateAround(ball.transform.localPosition, new Vector3(axisY, axisX, 0), 180*Time.deltaTime);
        text.transform.rotation = quaternion;
        //GameObject gameObject = GameObject.Find("Sphere");
        //EarthBehaviourScript earthScript = gameObject.GetComponent<EarthBehaviourScript>();
        //float i = earthScript.speed;
        //Debug.Log(i);
    }
}
