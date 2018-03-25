using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    public int cout = 20;
    public List<int> itemDatas = new List<int>();

    public PageItem prefabPageItem;
    List<PageItem> listPageItem = new List<PageItem>();

	// Use this for initialization
	void Start ()
	{
		for(int i=0; i<cout; i++)
        {
            itemDatas.Add(i);
        }

        int pageCount = Mathf.CeilToInt(cout / 6f);
        Debug.Log("pagecount = " + pageCount.ToString());
        for(int i=0; i<pageCount; i++)
        {
            listPageItem.Add(CreatePageItem());
        }

        for (int i = 0; i < pageCount; i++)
        {
            List<int> datas = new List<int>();
            for(int ii=i*6; ii<i*6+6 && ii<itemDatas.Count; ii++)
            {
                datas.Add(itemDatas[ii]);
            }
            listPageItem[i].Init(datas);
        }
    }

    PageItem CreatePageItem()
    {
        PageItem t = GameObject.Instantiate<PageItem>(prefabPageItem);
        t.gameObject.SetActive(true);
        t.transform.SetParent(prefabPageItem.transform.parent);
        t.transform.localScale = Vector3.one;
        t.transform.localPosition = Vector3.zero;
        return t;
    }
}
