using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckHandler : MonoBehaviour
{
    public Animator customerHolderAnim;
    public Animator truckAnim;

    public GameObject customer;

    public int amountOfCust = 0;

    public bool customerOn = false;

    void Start()
    {
        customerHolderAnim.gameObject.SetActive(false);
        amountOfCust = 0;
    }

    public void TruckEnter()
    {
        truckAnim.gameObject.SetActive(true);
    }

    public void TruckLeave()
    {
        truckAnim.SetTrigger("Leave");
        amountOfCust = -1;
    }

    public void CustomerEnter()
    {
        customerHolderAnim.gameObject.SetActive(true);
    }

    public void TurnOnCustomer()
    {
        if (!customerOn)
        {
            customer.SetActive(true);
            customerOn = true;
        }

        else if (customerOn)
        {
            customer.GetComponent<Bob>().ResetCustomer();
        }
    }
    
    public void TruckReset()
    {
        truckAnim.gameObject.SetActive(false);
        truckAnim.gameObject.SetActive(true);
    }

    public void BringBackCust()
    {
        if(customerOn)
            customer.GetComponent<Bob>().ResetCustomer();
    }
}
