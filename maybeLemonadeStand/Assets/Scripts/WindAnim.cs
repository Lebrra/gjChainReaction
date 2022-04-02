using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAnim : MonoBehaviour
{
    public Transform p1, p2;

    public GameObject container;

    public void ChooseNewPos()
    {
        var temp = Random.Range(p1.position.y, p2.position.y);
        container.transform.position = new Vector3(container.transform.position.x, temp, container.transform.position.z);
    }
}
