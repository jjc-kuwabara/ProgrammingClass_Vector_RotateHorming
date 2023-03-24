using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        m_bulletParent = GameObject.Find("BulletParent");
    }

    // Update is called once per frame
    void Update()
    {
        m_targetObject = GetTargetObject();

        this.transform.LookAt(m_targetObject.transform, new Vector3( 0, 0,- 1.0f));

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot_3Way();
        }
    }

    GameObject GetTargetObject()
    {
        return GameObject.Find("TargetObject");
    }

    void Shoot(){
        GameObject bulletInstance = Instantiate(m_bulletPrefab);
        bulletInstance.transform.position = this.transform.position;
        bulletInstance.transform.SetParent(m_bulletParent.transform);
        bulletInstance.GetComponent<Bullet>().Targeting(m_targetObject, Vector3.zero);
    }

    void Shoot_3Way(){
        // まっすぐ.
        GameObject bulletInstance = Instantiate(m_bulletPrefab);
        bulletInstance.transform.position = this.transform.position;
        bulletInstance.transform.SetParent(m_bulletParent.transform);

        Vector3 targetDirection = m_targetObject.transform.position - bulletInstance.transform.position;
        bulletInstance.GetComponent<Bullet>().Targeting(m_targetObject, targetDirection);

        // ひだり.
        bulletInstance = Instantiate(m_bulletPrefab);
        bulletInstance.transform.position = this.transform.position;
        bulletInstance.transform.SetParent(m_bulletParent.transform);

        Vector3 targetDirection_Left = Quaternion.Euler(0, 0, 30.0f) * targetDirection;
        bulletInstance.GetComponent<Bullet>().Targeting(m_targetObject, targetDirection_Left);

        // みぎ.
        bulletInstance = Instantiate(m_bulletPrefab);
        bulletInstance.transform.position = this.transform.position;
        bulletInstance.transform.SetParent(m_bulletParent.transform);

        Vector3 targetDirection_Right = Quaternion.Euler(0, 0, -30.0f) * targetDirection;
        bulletInstance.GetComponent<Bullet>().Targeting(m_targetObject, targetDirection_Right);
    }

    GameObject m_bulletPrefab;
    GameObject m_bulletParent;
    GameObject m_targetObject;
}
