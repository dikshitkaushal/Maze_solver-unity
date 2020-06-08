using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA 
{
    List<int> genes = new List<int>();
    public int dnalength;
    public int maxvalues;
    public DNA(int l,int v)
    {
        dnalength = l;
        maxvalues = v;
        setrandom();
    }
    public void setrandom()
    {
        for(int i=0;i<dnalength;i++)
        {
            genes.Add(UnityEngine.Random.Range(0, maxvalues));
        }
    }
    public void setgene(int pos,int value)
    {
        genes[pos] = value;
    }
    public int getgene(int pos)
    {
        return genes[pos];
    }
    public void combine(DNA dna1,DNA dna2)
    {
        for(int i=0;i<dnalength;i++)
        {
            if(i<dnalength/2)
            {
                genes[i] = dna1.getgene(i);
            }
            else
            {
                genes[i] = dna2.getgene(i);
            }
        }
    }
    public void mutate()
    {
        genes[UnityEngine.Random.Range(0, dnalength)] = UnityEngine.Random.Range(0, maxvalues);
    }
}
