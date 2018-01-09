using System;
using UnityEngine;

[Serializable]
public class SetUp
{
    [Tooltip("���ж�")]
    public float sensitivity = 15f;   //���ж�

    [Tooltip("���ˮƽ�ƶ��ٶ�")]
    public float maxturnSpeed = 35f;    // ����ƶ��ٶ�

    [Tooltip("���ֱ�Aб���ƶ��ٶ�")]
    public float maxTilt = 35f;    // �����б��

    [Tooltip("λ�Ƽӳ�����")]
    public float posRate = 1.5f;    
}

public class MobileScreenOrientation : MonoBehaviour
{

    public enum MotionAxial
    {
        All = 1,  //ȫ����
        None = 2,   
        x = 3,   
        y = 4,
        z = 5
    }

    public enum MotionMode
    {
        Postion = 1,   //ֻ��λ�ñ绤
        Rotation = 2,   
        All = 3    //ȫ���仯
    }

    //��������Ƚϱ��ˡ�����ʹ��UnityEditor���Ķ�ѡ���ܡ����������ⲻ֧���ƶ�ƽ̨��
    public MotionAxial motionAxial1 = MotionAxial.y;     
    public MotionAxial motionAxial2 = MotionAxial.None;

    public MotionMode motionMode = MotionMode.Rotation;   //�˶�ģʽ

    public SetUp setUp;

    public GameObject tager;     //���ƶ��Ķ���

    Vector3 m_MobileOrientation;   //�ֻ������Ǳ仯��ֵ

    Vector3 m_tagerTransform;
    Vector3 m_tagerPos;
    public Vector3 ReversePosition = Vector3.one; //���������Ƿ����ȡ��

    void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        m_tagerTransform = Vector3.zero;
        m_tagerPos = Vector3.zero;

    }

    void LateUpdate()
    {
        if (tager == null)
            return;

        m_MobileOrientation = Input.acceleration;



        if (motionAxial1 == MotionAxial.None && motionAxial2 == MotionAxial.None)   //�������κ���
            return;
        else if (motionAxial1 == MotionAxial.x && motionAxial2 == MotionAxial.None)   // X��
        {
            m_tagerTransform.x = Mathf.Lerp(m_tagerTransform.x, m_MobileOrientation.y * setUp.maxTilt * ReversePosition.x, 0.2f);
        }
        else if (motionAxial1 == MotionAxial.y && motionAxial2 == MotionAxial.None)   //Y ��
        {
            m_tagerTransform.y = Mathf.Lerp(m_tagerTransform.y, -m_MobileOrientation.x * setUp.maxturnSpeed * ReversePosition.y, 0.2f);
        }
        else if (motionAxial1 == MotionAxial.z && motionAxial2 == MotionAxial.None)   // z��
        {
            m_tagerTransform.z = Mathf.Lerp(m_tagerTransform.z, -m_MobileOrientation.z * setUp.maxTilt * ReversePosition.z, 0.2f);
        }
        else if (motionAxial1 == MotionAxial.x && motionAxial2 == MotionAxial.y)   // X��Y��
        {
            m_tagerTransform.y = Mathf.Lerp(m_tagerTransform.y, -m_MobileOrientation.x * setUp.maxturnSpeed * ReversePosition.y, 0.2f);
            m_tagerTransform.x = Mathf.Lerp(m_tagerTransform.x, m_MobileOrientation.y * setUp.maxTilt * ReversePosition.x, 0.2f);
        }
        else if (motionAxial1 == MotionAxial.y && motionAxial2 == MotionAxial.x) // Y��X��
        {
            m_tagerTransform.y = Mathf.Lerp(m_tagerTransform.y, -m_MobileOrientation.x * setUp.maxturnSpeed * ReversePosition.y, 0.2f);
            m_tagerTransform.x = Mathf.Lerp(m_tagerTransform.x, m_MobileOrientation.y * setUp.maxTilt * ReversePosition.x, 0.2f);
        }
        else if (motionAxial1 == MotionAxial.x && motionAxial2 == MotionAxial.z)  // x �� Z ��
        {
            m_tagerTransform.x = Mathf.Lerp(m_tagerTransform.x, m_MobileOrientation.y * setUp.maxTilt * ReversePosition.x, 0.2f);
            m_tagerTransform.z = Mathf.Lerp(m_tagerTransform.z, -m_MobileOrientation.z * setUp.maxTilt * ReversePosition.z, 0.2f);
        }
        else if (motionAxial1 == MotionAxial.z && motionAxial2 == MotionAxial.x)  // Z �� X ��
        {
            m_tagerTransform.x = Mathf.Lerp(m_tagerTransform.x, m_MobileOrientation.y * setUp.maxTilt * ReversePosition.x, 0.2f);
            m_tagerTransform.z = Mathf.Lerp(m_tagerTransform.z, -m_MobileOrientation.z * setUp.maxTilt * ReversePosition.z, 0.2f);
        }
        else if (motionAxial1 == MotionAxial.y && motionAxial2 == MotionAxial.z)   // Y��Z ��
        {
            m_tagerTransform.y = Mathf.Lerp(m_tagerTransform.y, -m_MobileOrientation.x * setUp.maxturnSpeed * ReversePosition.y, 0.2f);
            m_tagerTransform.z = Mathf.Lerp(m_tagerTransform.z, -m_MobileOrientation.z * setUp.maxTilt * ReversePosition.z, 0.2f);
        }
        else if (motionAxial1 == MotionAxial.z && motionAxial2 == MotionAxial.y)   // Z�� Y��
        {
            m_tagerTransform.y = Mathf.Lerp(m_tagerTransform.y, -m_MobileOrientation.x * setUp.maxturnSpeed * ReversePosition.y, 0.2f);
            m_tagerTransform.z = Mathf.Lerp(m_tagerTransform.z, -m_MobileOrientation.z * setUp.maxTilt * ReversePosition.z, 0.2f);
        }
        else if (motionAxial1 == MotionAxial.All && motionAxial2 == MotionAxial.All)   // ���������˶�
        {
            m_tagerTransform.y = Mathf.Lerp(m_tagerTransform.y, -m_MobileOrientation.x * setUp.maxturnSpeed * ReversePosition.y, 0.2f);
            m_tagerTransform.x = Mathf.Lerp(m_tagerTransform.x, m_MobileOrientation.y * setUp.maxTilt * ReversePosition.x, 0.2f);
            m_tagerTransform.z = Mathf.Lerp(m_tagerTransform.z, m_MobileOrientation.z * setUp.maxTilt * ReversePosition.z, 0.2f);
        }

        m_tagerPos.x = m_tagerTransform.y;
        m_tagerPos.y = -m_tagerTransform.x;
        m_tagerPos.z = m_tagerTransform.z;

        if (motionMode == MotionMode.Postion)
        {
            tager.transform.localPosition = Vector3.Lerp(tager.transform.localPosition, m_tagerPos * setUp.posRate, Time.deltaTime * setUp.sensitivity);
        }
        else if (motionMode == MotionMode.Rotation)
        {
            tager.transform.localRotation = Quaternion.Lerp(tager.transform.localRotation, Quaternion.Euler(m_tagerTransform), Time.deltaTime * setUp.sensitivity);
        }
        else
        {
            tager.transform.localPosition = Vector3.Lerp(tager.transform.localPosition, m_tagerPos * setUp.posRate, Time.deltaTime * setUp.sensitivity);
            tager.transform.localRotation = Quaternion.Lerp(tager.transform.localRotation, Quaternion.Euler(m_tagerTransform), Time.deltaTime * setUp.sensitivity);
        }
    }

}