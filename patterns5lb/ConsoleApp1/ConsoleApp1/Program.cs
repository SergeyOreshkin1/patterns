using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Apartment apartment = new Apartment();
            TownHouse townHouse = new TownHouse();
            Cottage cottage = new Cottage();

            HouseFacade hf = new HouseFacade(apartment, townHouse, cottage);

            Client client = new Client();
            client.StartApplication(hf);

            Console.Read();
        }
    }

    class Apartment : House
    {
        public void Premium(int insuranceSumma, int insuranceTerm)
        {
            double premium;
            premium = insuranceSumma * 0.45 * insuranceTerm;
            Console.WriteLine("Сумма страхования {0}, срок страхования {1}, cтраховой взнос для квартиры составляет: {2}", insuranceSumma, insuranceTerm, premium);
        }
        
    }
    class TownHouse : House
    {
        public void Premium(int insuranceSumma, int insuranceTerm)
        {
            double premium;
            premium = insuranceSumma * 0.6 * insuranceTerm;
            Console.WriteLine("Сумма страхования {0}; срок страхования {1}; cтраховой взнос для таун-хауса составляет: {2}", insuranceSumma, insuranceTerm, premium);
        }
        
    }
    class Cottage : House
    {
        public void Premium(int insuranceSumma, int insuranceTerm)
        {
            double premium;
            premium = insuranceSumma * 0.7 * insuranceTerm;
            Console.WriteLine("Сумма страхования {0}; срок страхования {1}; cтраховой взнос для коттеджа составляет: {2}", insuranceSumma, insuranceTerm, premium);
        }
       
    }

    class HouseFacade
    {
        Apartment apartment;
        TownHouse townHouse;
        Cottage cottage;

        public HouseFacade(Apartment apartment, TownHouse townHouse, Cottage cottage)
        {
            this.apartment = apartment;
            this.townHouse = townHouse;
            this.cottage = cottage;
        }

        static int InsuranceSum() //сумма по страхованию
        {
            Console.WriteLine("Площадь(м2):");
            int square = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Число проживающих:");
            int residentsAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Год постройки здания:");
            int yearOfConstruction = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("износ здания (%):");
            int buildingDeterioration = Convert.ToInt32(Console.ReadLine());

            int sumSquare = 2, sumResidents = 200;
            if (yearOfConstruction > 1950)
            {
                int sum = sumSquare * square + sumResidents * residentsAmount;
                if (buildingDeterioration > 20 )
                {
                    sum = sum + sum *10/100;
                }
               
                return sum;
            }
            else
            {
                int sum = sumSquare * square + sumResidents * residentsAmount + (sumSquare * square + sumResidents * residentsAmount) *20/100;
                if (buildingDeterioration > 20)
                {
                    sum = sum + sum * 10 / 100;
                }

                return sum;

            }
                
        }

        public void InsurancePremium() // страховой взнос
        {
            Console.WriteLine("Расчет страхового взноса для квартиры:");
            int sumApartment = InsuranceSum();
            apartment.Premium(sumApartment, 2);

            Console.WriteLine("Расчет страхового взноса для таун-хауса:");
            int sumTownHouse = InsuranceSum();
            townHouse.Premium(sumTownHouse, 1);

            Console.WriteLine("Расчет страхового взноса для коттеджа:");
            int sumCottage = InsuranceSum();
            cottage.Premium(sumCottage, 3);
        }
    }

    class Client
    {
        public void StartApplication(HouseFacade facade)
        {
            facade.InsurancePremium();
        }
    }

    interface House
    {
        void Premium(int insuranceSumma,int insuranceTerm);
    }
}
