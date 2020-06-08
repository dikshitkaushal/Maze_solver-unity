using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRAIN : MonoBehaviour
{
    public GameObject eyes;
    Vector3 startingpos;
    public float distancetravelled;
    public bool alive;
    public bool can_see;
    public DNA dna;
    public int dnalength = 2;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="dead")
        {
            alive = false;
        }
    }

    public void init()
    {
        //360 so that we can visualise multiple rotation angles and we can get perfect angle rotation
        dna = new DNA(dnalength, 360);
        alive = true;
        distancetravelled = 0;
        startingpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!alive)
        {
            return;
        }
        can_see = false;
        Debug.DrawRay(eyes.transform.position, eyes.transform.forward * 0.5f, Color.red);
        RaycastHit hit;
        if(Physics.SphereCast(eyes.transform.position,0.1f,eyes.transform.forward,out hit,0.5f))
        {
            if(hit.transform.tag=="wall")
            {
                can_see = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if(!alive)
        {
            return;
        }
        //read dna
        int v = dna.getgene(0);
        int h=0;
        if(can_see)
        {
            h = dna.getgene(1);
        }
        this.transform.Translate(0, 0, v * 0.001f);
        this.transform.Rotate(0, h, 0);
        distancetravelled = Vector3.Distance(startingpos, this.transform.position);
    }
}
