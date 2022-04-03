using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckHandler : MonoBehaviour
{
    public Animator customerHolderAnim;
    public Animator truckAnim;

    public GameObject customer;

    public int amountOfCust = 0;

    void Start()
    {
        customerHolderAnim.gameObject.SetActive(false);
        amountOfCust = 0;
    }

    private void Update()
    {
        if (amountOfCust >= 3)
            TruckLeave();
    }

    public void TruckEnter()
    {
        truckAnim.gameObject.SetActive(true);
    }

    public void TruckLeave()
    {
        truckAnim.SetTrigger("Leave");
    }

    public void CustomerEnter()
    {
        customerHolderAnim.gameObject.SetActive(true);
    }

    public void TurnOnCustomer()
    {
        customer.SetActive(true);
    }
}
