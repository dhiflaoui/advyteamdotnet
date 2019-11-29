using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xs = new XmlSerializer(typeof(user));
            user u = new user();
            u.cin = "15545454";
            u.nom = "Salem";
            absence abs = new absence();
            abs.etat = "sssss";
            FileStream fs = new FileStream("Inventory.XML", FileMode.Create, FileAccess.Write);
             xs.Serialize(fs, u);
            Console.Write(xs.ToString());
        }
    }
}
