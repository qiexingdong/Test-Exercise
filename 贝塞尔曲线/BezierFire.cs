using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���ױ���������
/// </summary>
public class BezierFire : MonoBehaviour
{
    public bool result ;
    public Transform target;
    public Bullet bulletPre;
    public float r = 6;
    private void Start()
    {
        result = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            result = !result;
            StartFire();
        }

    }
    private void StartFire() {
        StartCoroutine(Fire());
    }
    private void StopFire() {
        StopAllCoroutines();
    }
    /// <summary>
    /// ��ȡ��һ�������
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRandomPoint(float r) {
        return transform.position + new Vector3(Random.Range(-r,r), Random.Range(-r, r), Random.Range(-r, r));
    }
    public IEnumerator Fire() {
        while (result) {
            Bullet bullet = Instantiate(bulletPre,transform.position,Quaternion.identity);
            StartCoroutine(bullet.Move(bullet.transform.position, GetRandomPoint(r), target));

            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
