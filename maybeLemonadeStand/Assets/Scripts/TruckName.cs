using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TruckName : MonoBehaviour
{
    TextMeshPro truckName;

    public void SetTruckName()
    {
        truckName = GetComponent<TextMeshPro>();
        truckName.text = GameManager.instance.truckName;
    }
}
