using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�����л�
using UnityEngine.UI;
using UnityEngine.EventSystems;//��ȡugui��ť����

public class ButtonHandler : MonoBehaviour
{
    private Controller controller;
    public static Transform birth;
    private void Start()
    {
        controller = FindObjectOfType<Controller>();
        birth = this.transform;
        for (int i = 0; i < controller.transform.childCount; i++)
        {
            controller.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }
    }
    private void OnButtonClick()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;
        var arr = buttonName.Split('_');
        var func = arr[1];//���ܵ�����
        var goName = arr[2];//��Դ������
        switch (func)
        {
            case "act":
                controller.ChangeAnima(goName);
                break;
            case "mon":
                controller.ChangeChacator(goName);
                break;
            case "wp":
                controller.ChangeWeapon(goName);
                break;
            case "col":
                controller.ChangeClothes(goName);
                break;
        }
    }
}
