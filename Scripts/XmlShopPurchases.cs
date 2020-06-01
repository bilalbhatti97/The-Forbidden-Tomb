using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Root")]
public class XmlShopPurchases 
{
    // Start is called before the first frame update
    [XmlArray("ButtonsPress")]
    [XmlArrayItem("Value")]
    public List<int> btns_pressd = new List<int>();

    [XmlArray("LinesACtivated")]
    [XmlArrayItem("Value")]
    public List<int> lino_act = new List<int>();

    public static XmlShopPurchases Load(string path)
    {
        var serializer = new XmlSerializer(typeof(XmlShopPurchases));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as XmlShopPurchases;
        }
    }

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(XmlShopPurchases));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
