using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private Dictionary<string, GameObject> dic = new Dictionary<string, GameObject>();
    public GameObject LoadChacator(string goName)
    {
        if (!dic.ContainsKey(goName))
        {
            GameObject obj = Resources.Load<GameObject>("Chacator/mon_" + goName);
            obj = Instantiate<GameObject>(obj, ButtonHandler.birth.position, Quaternion.Euler(0, 180, 0));//创建人物
            obj.name = obj.name.Replace("(Clone)", "");
            dic.Add(goName, obj);
        }
        return dic[goName];
    }

    public GameObject LoadWeapon(string goName)
    {
        if (!dic.ContainsKey(goName))
        {
            GameObject obj = Resources.Load<GameObject>("Weapon/wp_" + goName);
            obj = Instantiate<GameObject>(obj);//创建武器
            obj.name = obj.name.Replace("(Clone)", "");
            dic.Add(goName, obj);
        }
        return dic[goName];
    }

    public Texture LoadClothes(string goName)
    {
        Texture obj = Resources.Load<Texture>("Clothes/" + goName);
        return obj;
    }
}
