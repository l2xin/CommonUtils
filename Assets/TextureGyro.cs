using UnityEngine;using System.Collections;

public class TextureGyro : MonoBehaviour 
{
    //陀螺仪是否存在
    private bool gyroBool;
    //陀螺仪
    private Gyroscope gyro;
    //X轴方向移动的速度参数
    private float xSpeed =200;
    //移动方向的三维向量
    private Vector3 directionV3;
    //陀螺仪x轴的取值
    private float gyrosParameter;
    void Awake()
    {
        //设置APP屏幕的方向
        Screen.orientation = ScreenOrientation.AutoRotation;;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        //判断是否支持陀螺仪
        gyroBool = SystemInfo.supportsGyroscope;
        if (gyroBool)
        {
            //给陀螺仪复制
            gyro = Input.gyro;
            gyro.enabled = true;
            //安卓平台预判
            #if UNITY_
            if (Screen.orientation == ScreenOrientation.LandscapeLeft)
            {
                directionV3 = new Vector3(1, 0, 0);
            }
            if (Screen.orientation == ScreenOrientation.LandscapeRight)
            {
                directionV3 = new Vector3(-1, 0, 0);
            }
            #endif
            //IOS平台预判
            #if UNITY_IPHON
            if (Screen.orientation==ScreenOrientation.LandscapeLeft)
            {
                directionV3 = new Vector3(1, 0, 0);
            }
            if (Screen.orientation == ScreenOrientation.LandscapeRight)
            {
                directionV3 = new Vector3(-1, 0, 0);
            }


            #endif
            //设置屏幕长亮
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
// Use this for initialization
void Start () 
    {

}

// Update is called once per frame
void Update () {
        //位置随着陀螺仪重力感应的X轴变化而变化
        if (gyroBool)
        {
            #if UNITY_IPHON
    gyrosParameter = gyro.gravity.x;
            #endif
            #if UNITY_ANDROID
            gyrosParameter = gyro.gravity.x;
            #endif
            transform.localPosition = gyrosParameter * directionV3 * xSpeed;
        }
}
}
