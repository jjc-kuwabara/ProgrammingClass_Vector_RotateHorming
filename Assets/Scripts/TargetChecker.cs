using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_playerObject = GameObject.Find("PlayerObject");
        m_targetObject = GameObject.Find("TargetObject");
        ChangeGreenColor(m_targetObject);
    }

    // Update is called once per frame
    void Update()
    {
        m_distanceDistance = m_targetObject.transform.position - m_playerObject.transform.position;
        if (m_distanceDistance.magnitude < 3.0f)
        {
            ChangeGreenColor(m_targetObject);
        }
        else
        {
            ChangeRedColor(m_targetObject);
        }
    }

    void ChangeRedColor(GameObject obj)
    {
        obj.transform.Find("Model").GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/RedMaterial");
    }

    void ChangeGreenColor(GameObject obj)
    {
        obj.transform.Find("Model").GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/GreenMaterial");
    }

    GameObject m_playerObject;
    GameObject m_targetObject;
    [SerializeField]
    Vector3 m_distanceDistance;
}
