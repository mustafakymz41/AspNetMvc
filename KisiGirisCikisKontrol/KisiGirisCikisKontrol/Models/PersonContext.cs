using System.Collections.Generic;
using System;
using Microsoft.OData.Edm;

namespace KisiGirisCikisKontrol.Models
{
    public class PersonContext
    {
        public static List<Person> Person = new List<Person>() {
            new Person{Id=1 ,FirstName= "Mustafa", LastName="Kaymaz", TcNo=18568489875, HesKod="a1b5188252", loginTime= "02.10,2021",ExitTime= "02.09,2021" },
            new Person{Id=2 ,FirstName= "Adnan", LastName="Çolak", TcNo=54896254455, HesKod="k1b5188252", loginTime= "04.07,2021",ExitTime= "05.07,2021" }

        };
    }
}
