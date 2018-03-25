using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour
{
    public Text txt;

	public void Init(int data)
    {
        txt.text = data.ToString();
    }
}
