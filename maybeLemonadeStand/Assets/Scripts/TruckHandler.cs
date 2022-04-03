using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckHandler : MonoBehaviour
{
    public Animator cutomerAnim;
    public Animator truckAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TruckEnter()
    {
        truckAnim.gameObject.SetActive(true);
    }

    public void TruckLeave()
    {
        truckAnim.SetTrigger("Leave");
    }
}
