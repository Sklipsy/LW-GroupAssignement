// See https://aka.ms/new-console-template for more information

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
// enkelt tänkesätt get set -> till list<> -> slutresultat i Output
// . är att man kan nå klasserna i varandra. Träna på obj orientering, list, class function, linq

namespace LWSite
{
    public enum Typeofprop 
    {
        el,bensin
    }

        
    public class LawnMower
    {
        public Typeofprop Typ { get; set; } 
        public double Petrol { get; set; }
        public double Battery1 { get; set; }
        public double Battery2 { get; set; }
        public decimal pris {  get; set; }
        public string? Model { get; set; }  // 2 klasser 1 klasser med data. 2 klasser med funktioner.
        public bool Avaiable { get; set; } //globala variablar. = get set.
    }
    public enum KundData//enum är i en egen klass
    {
        basic, prime,   //global behöver ej göra "new"
    }
    public class Primebonus 
    {
       public int Sek { get; set; }    
        
       public string ?Sekpoint { get; set; } 
    }
        public class Kund 
        {
            public KundData kundData { get; set; }// kunddata 2 gånger. för att få in enum i get set
            public string? Namn { get; set; } 
            public string? KontaktDetaljer { get; set; } 
            public bool Discount { get; set; } 
        }
        public class hire//Uthyrnings lista
        {
            public Kund? Kund { get; set; }
            public LawnMower? LawnMower { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime ReturnDate { get; set; }
        }

    //stoppar in get set grejjerna till en list<>
    public class Uthyrning
    {
        private List<LawnMower> lawnMowers = new List<LawnMower>();//private = enbart för den nuvarande klassen 
        private List<Kund> kunder = new List<Kund>();
        private List<hire> hire = new List<hire>();

        // ->TRYCKTE NER FUNKTIONERNA I GRÄSKLIPPARLISTAN IST MED 15 GRÄSKLIPPARE ISTÄLLET<-

        public void Primefunc()
        {
            Primebonus x = new Primebonus(); x.Sek = 1;
            x.Sekpoint = " SEK:- + PRIMEPOIMTS";
           

            foreach (var c in hire)
            {
                if (c.Kund.kundData == KundData.prime)
                {
                    Console.WriteLine($"{x.Sekpoint}{c.LawnMower.pris}");
                }
                else
                {
                    Console.WriteLine("No Money, No Prime. (^_^)");
                }
            }
        }
        public void Costcount()
        {
            foreach(var f in kunder) 
            {
                var uthyrningperkund = hire.Where(x => x.Kund == f);

            } 
            foreach (var c in hire) //man behöver ej göra "new"
            {

                Console.WriteLine($"kund {c.Kund.Namn}");//loopar igenom
                Console.WriteLine($"har hyrt gräsklippare{c.LawnMower.Model}");

                if (c.Kund.kundData == KundData.basic) 
                {
                    var pris = (double)c.LawnMower.pris * 0.75;
                    Console.WriteLine($"KUNDENS PRIS +  25% rabatt {pris}");
                }
                else
                {
                   
                    Console.WriteLine($"KUNDENS PRIS {c.LawnMower.pris}");
                }
            }
        }
        public void Createlawnmowers()
        {
            
            lawnMowers.Add(new LawnMower { Model = "Yamaha 1",Typ= Typeofprop.bensin, Avaiable = true, pris = 1245M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 2", Typ = Typeofprop.bensin, Avaiable = true, pris = 4444M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 3", Typ = Typeofprop.bensin, Avaiable = true, pris = 101M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 4", Typ = Typeofprop.bensin, Avaiable = true, pris = 404M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 5", Typ = Typeofprop.bensin, Avaiable = true, pris = 650M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 6", Typ = Typeofprop.bensin, Avaiable = true, pris = 1824M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 7", Typ = Typeofprop.bensin, Avaiable = true, pris = 312M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 8", Typ = Typeofprop.bensin, Avaiable = true, pris = 123M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 9", Typ = Typeofprop.el, Avaiable = true, pris = 125M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 10", Typ = Typeofprop.el, Avaiable = true, pris = 126M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 11", Typ = Typeofprop.el, Avaiable = true, pris = 125M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 12", Typ = Typeofprop.el, Avaiable = true, pris = 1222M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 13", Typ = Typeofprop.el, Avaiable = true, pris = 1233M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 14", Typ = Typeofprop.el, Avaiable = false, pris = 1244M });
            lawnMowers.Add(new LawnMower { Model = "Yamaha 15", Typ = Typeofprop.el, Avaiable = false, pris = 1245M });    
        }
        public void Lwlist()
        {
            foreach (var x in lawnMowers.Where(x=>x.Typ == Typeofprop.bensin)) 
            {
                //petrol
                
                double gram = 862; double watt = 1000;// petrol engine
                TimeSpan q = new TimeSpan(1, 0, 0);
                x.Petrol = gram * watt * q.TotalSeconds;

                Console.WriteLine($"Modell {x.Model} Petrol: {x.Petrol} Pris {x.pris}");
                    
            }
            foreach (var x in lawnMowers.Where(x => x.Typ == Typeofprop.el))
            {
                double e = 75.6;
                TimeSpan f = new TimeSpan(1, 0, 0); x.Battery1 = e * f.TotalSeconds;
                double pw2 = 146; x.Battery2 = pw2 * f.TotalSeconds; string d = " Units "; string r = " 75,6 W/H "; string t = " 146 W/H ";

                Console.WriteLine($"Modell {x.Model} batt1 {x.Battery1} batt2 {x.Battery2} Pris {x.pris}");
            }
        }
    public void Reggaklippare(string typ,decimal pris)
    {
        lawnMowers.Add(new LawnMower { Model = typ, Avaiable = true, pris =123});//aviable = true 
    }
    public void printdate() //skriv en metod i klassen som man behöver behåll all logik i klassen som där det passar bäst. 
    {
        foreach (var x in hire) 
        {
            Console.WriteLine(x.LawnMower);
            Console.WriteLine(x.Kund);
            Console.WriteLine(x.StartDate);
        }
    }
    public void RegKunds(string namn, string kontaktDetaljer, KundData typ)
    {
        if (kunder.Any(x => x.Namn == namn))
        {
            return;
        }
    kunder.Add(new Kund { kundData = typ, Namn = namn, KontaktDetaljer = kontaktDetaljer });
    }
    public void RegLawn(string kundNamn, string lawnMowerModel, DateTime startDate, DateTime? returnDate = null) //gör helt nya variabel samt en if
    {

        if (lawnMowers.Count(x => x.Model == lawnMowerModel && x.Avaiable) <= 0)
        {
            Console.WriteLine("finns ingen tillgänglig gräsklippare");
            return;
        }
        Kund kund = kunder.Find(x => x.Namn == kundNamn);
        if (kund == null)
        {
            Console.WriteLine("kunden kunde ej hittas(^_^)"); 
            return;
        }
        LawnMower lawnMower = lawnMowers.Find(x => x.Model == lawnMowerModel && x.Avaiable);// x.Avaible 
        if (lawnMower == null)
        {
            Console.WriteLine("kunde ej hitta gräsklippare"); 
            return;
        }
        if (kund.kundData == KundData.basic)
        {//kontrollerar om kunden är basic. "if formeln igen."
        //    if (returnDate - startDate < TimeSpan.FromDays(7))
        //    {
        //        Console.WriteLine("upp till 7 dagar.");
        //        return;
        //    }
            }

        hire.Add(new hire
        {
            Kund = kund,
            LawnMower = lawnMower,
            StartDate = startDate,
            ReturnDate = returnDate.Value// value för det ska funka     
        });

        lawnMower.Avaiable = false;
        Console.WriteLine("Uthyrning av gräsklippare SUCCESS");
    }
}
    public class Output
{
    public static void Main(string[] args) 
    { 
        Uthyrning uthyrning = new Uthyrning();//initiating bara en initializering behövs
        uthyrning.Createlawnmowers();//call

        //uthyrning.RegKunds("asfasf", "asf");
        //uthyrning.RegLawn("asf", "asfasf", DateTime.Now, DateTime.Now.AddDays(7));

        Console.Title = "Gräsklippar uthyrning";
        Console.ForegroundColor = ConsoleColor.White; 

        Console.WriteLine("Välkommen till uthyrning av 17 gräsklippare"); 
       // Console.WriteLine("Kundnamn"); 

        int response = 0;//svar ifrån tryparse 
        while (response != 7)
        {//while loop för att programmet ska snurra runt. kolla sen när man lägger till fler val att ändra numret  efter behov.
            Console.WriteLine("VÄLJ ETT AV 6 FÖLJANDE MENYVAL NEDANFÖR ");
            Console.WriteLine("register KUND(1)");//1,2,3,4 valalternativ inom parameter
            Console.WriteLine("• Register a lawn mower rental (2)");
            Console.WriteLine("• Keep track of lawn mowers in store and in rental(3)");
            Console.WriteLine("• regga klippare(4)");
            Console.WriteLine("*beräkna pris(5)");
            Console.WriteLine("*se gräsklippare(6)"); 


                var alt = Console.ReadLine();  

            int.TryParse(alt, out response); 
            if (response == 1)
            {
                Console.WriteLine("kundnamn"); 
                var kundnamn = Console.ReadLine(); 
                Console.WriteLine("kundinfo"); 
                var kundinfo = Console.ReadLine(); 
                uthyrning.RegKunds(kundnamn, kundinfo, KundData.basic);  
            }
            else if (response == 2) 
            {
                Console.WriteLine("KundNamn");
                var kundnamn = Console.ReadLine();//stannar för att skriva ner ifrån tangentbordet
                Console.WriteLine("skriv in gräsklipparmodell"); 
                var lawnmodel = Console.ReadLine();
                Console.WriteLine("startdatum ");
                var datum = Console.ReadLine();
                Console.WriteLine("slutdatum");
                var slutdatum = Console.ReadLine();
                DateTime endsDate;
                DateTime.TryParse(slutdatum, out endsDate);
                DateTime dateTime;
                DateTime.TryParse(datum, out dateTime);
                uthyrning.RegLawn(kundnamn, lawnmodel, dateTime, endsDate);

            }//håll på paranteserna och se vad för innehåll som ska stå innanför dom som hjälp

            else if (response == 3) 
            {
                Console.WriteLine("uthyrda gräsklippare");
                uthyrning.printdate(); 
            }
            else if (response == 4) 
            {
                Console.WriteLine("regga klippare");

                    uthyrning.Primefunc();

                var Model = Console.ReadLine(); 
                Console.WriteLine("pris"); 
                var pris = Console.ReadLine();
                uthyrning.Reggaklippare(Model, Convert.ToDecimal(pris)); 

                           
            }
            else if (response == 5)
            {
                uthyrning.Costcount();
                    
                    
            }
            else if (response ==6) 
            {
                    uthyrning.Lwlist();
            }
            else
            {
                Console.WriteLine("FEL VAL FÖRSÖK IGEN MELLAN ALTERNATIVERNA 1 - 6");
            }
        }
        Console.ReadLine();
    }
}
}

// virtual overeride base:pas
//bas klass. 