using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class tilo
{
    public til data = new til();
   

    public void storedata(int E,int T)
    {
        data.timeEntered = E;
        data.threat = T;

    }

    public void loadData()
    {

    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

}

public class til
{
    [XmlElement("TimesEntered")]
    public int timeEntered;

    [XmlElement("Threat")]
    public int threat;
}
