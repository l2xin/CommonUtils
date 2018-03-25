using UnityEngine;
using System.Collections.Generic;

public class PageItem : MonoBehaviour
{
    public Item prefabItem;
    List<Item> listItem = new List<Item>();
	
	public void Init(List<int> datas)
    {
        int count = datas.Count;
        for (int i = 0; i < count; i++)
        {
            listItem.Add(CreateItem(datas[i]));
        }
    }

    Item CreateItem(int data)
    {
        Item t = GameObject.Instantiate<Item>(prefabItem);
        t.gameObject.SetActive(true);
        t.transform.SetParent(prefabItem.transform.parent);
        t.transform.localScale = Vector3.one;
        t.transform.localPosition = Vector3.zero;
        t.Init(data);
        return t;
    }
}
