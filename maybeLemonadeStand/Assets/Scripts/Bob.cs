using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    public Animator anim;
    public GameObject obj;

    public TruckHandler t;

    public void StopBob()
    {
        anim.SetBool("Stop", true);
    }

    public void ResumeBob()
    {
        anim.SetBool("Stop", false);
    }

    public void ResetCustomer()
    {
        t.amountOfCust++;
        obj.GetComponent<SpriteRenderer>().enabled = false;

        if (t.amountOfCust < 3)
        {
            //t.amountOfCust++;
            this.gameObject.GetComponent<Animator>().SetTrigger("Restart");
            Invoke("ShowBob", .31f);
        }
    }

    public void ShowBob()
    {
        obj.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void CustomerLeave()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("Leave");
    }
}
