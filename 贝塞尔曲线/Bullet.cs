using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100000f;
    public void Start()
    {
        GameObject.Destroy(gameObject, 15);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    /// <summary>
    /// �ڵ��ƶ��켣
    /// </summary>
    /// <returns></returns>
    public IEnumerator Move(Vector3 start, Vector3 midPoint, Transform target)
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            Vector3 p1 = Vector3.Lerp(start, midPoint, i);
            Vector3 p2 = Vector3.Lerp(midPoint, target.position, i);
            Vector3 p = Vector3.Lerp(p1, p2, i);
            yield return StartCoroutine(MoveToPoint(p));//�ڵ��ƶ���p��
        }
        yield return StartCoroutine(MoveToTarget(target));
    }
    /// <summary>
    /// �ڵ��ƶ�
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    public IEnumerator MoveToPoint(Vector3 point)
    {
        yield return null;
        while (Vector3.Distance(transform.position, point) > 0.1f)
        {
            Vector3 dir = point - transform.position;//����
            transform.up = dir;
            transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime);
            yield return null;
        }
    }
    /// <summary>
    /// �ڵ�����Ŀ����
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public IEnumerator MoveToTarget(Transform target) {
        yield return null;
        while (Vector3.Distance(transform.position,target.position)>0.1f) {
            Vector3 dir = target.position - transform.position;//����
            transform.up = dir;
            transform.position = Vector3.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
            yield return null;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name=="target") {
            //�˺�����
            Destroy(gameObject);
        }
    }
}
