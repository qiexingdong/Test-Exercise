using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameObject currentObj;
    private GameObject currentWp;
    private Factory factory;
    private void Start()
    {
        factory = new Factory();
    }
    /// <summary>
    /// �ı䶯��
    /// </summary>
    /// <param name="goName"></param>
    public void ChangeAnima(string goName)
    {
        if (currentObj == null)
            return;
        currentObj.GetComponent<Animation>().Play(goName);
    }
    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="goName"></param>
    public void ChangeChacator(string goName)
    {
        GameObject obj = factory.LoadChacator(goName);//�õ�ģ��
        if (currentObj != null && obj.name != currentObj.name)
            currentObj.SetActive(false);
        currentObj = obj;
        currentObj.SetActive(true);
    }
    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="goName"></param>
    public void ChangeWeapon(string goName)
    { 
        if (currentObj == null)
            return;
        GameObject obj = factory.LoadWeapon(goName);//�õ�����
        if (currentWp != null && obj.name != currentWp.name)
            currentWp.SetActive(false);
        var hand = TransformHelper.GetChild(currentObj.transform, "Bip001 Weapon");//�ҵ���
        obj.transform.SetParent(hand);
        obj.transform.localEulerAngles = new Vector3(0, 0, 0);
        obj.transform.localPosition = Vector3.zero;
        currentWp = obj;
        currentWp.SetActive(true);
    }
    /// <summary>
    /// ������װ
    /// </summary>
    /// <param name="goName"></param>
    public void ChangeClothes(string goName)
    {
        if (currentObj == null)
            return;
        var obj = factory.LoadClothes(currentObj.name + "_" + goName);
        currentObj.GetComponentInChildren<SkinnedMeshRenderer>().material.mainTexture = obj;
    }
}
