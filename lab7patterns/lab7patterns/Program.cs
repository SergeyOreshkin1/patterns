using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Elevator elevator = new Elevator(new RestElevator());
            elevator.Put();
            elevator.Put();
            elevator.MoveUp();
            elevator.Put();
            elevator.Rest();
            elevator.PowerSupply();
            elevator.TakeOut();


            Console.Read();
        }
    }

    class Elevator
    {
        public IElevatorState State { get; set; }

        public Elevator(IElevatorState es)
        {
            State = es;
        }

        public void MoveDown()
        {
            State.MoveDown(this);
        }
        public void MoveUp()
        {
            State.MoveUp(this);
        }
        public void Rest()
        {
            State.Rest(this);
        }
        public void Put()
        {
            State.Put(this);
        }
        public void TakeOut()
        {
            State.TakeOut(this);
        }
        public void PowerSupply()
        {
            State.PowerSupply(this);
        }
    }

    interface IElevatorState
    {
        void MoveDown(Elevator elevator);
        void MoveUp(Elevator elevator);
        void Rest(Elevator elevator);
        void Put(Elevator elevator);
        void TakeOut(Elevator elevator);
        void PowerSupply(Elevator elevator);
    }

    class RestElevator : IElevatorState
    {
        public void MoveDown(Elevator elevator)
        {
            Console.WriteLine("Лифт поехал вниз");
            elevator.State = new MoveElevator();
        }

        public void MoveUp(Elevator elevator)
        {
            Console.WriteLine("Лифт поехал вверх");
            elevator.State = new MoveElevator();
        }

        public void Put(Elevator elevator)
        {
            Console.WriteLine("Лифт загружен");
            elevator.State = new LoadedElevator();
        }

        public void Rest(Elevator eleavator)
        {
            Console.WriteLine("Лифт продолжает стоять");
        }

        public void PowerSupply(Elevator elevator)
        {
            Random rand = new Random();
            int checkPower = rand.Next(0, 4);

            if (checkPower == 0)
            {
                Console.WriteLine("Необходимо восстановить подачу питания");
                elevator.State = new NoPowerSupplyElevator();
            }
            else
            {
                Console.WriteLine("Лифт исправен");
            }
            
        }

        public void TakeOut(Elevator elevator)
        {
            Console.WriteLine("Происходит разгрузка лифта");
        }
    }
    class MoveElevator : IElevatorState
    {
        public void MoveDown(Elevator eleavator)
        {
            Console.WriteLine("Лифт продолжает двигаться вниз");
        }

        public void Rest(Elevator elevator)
        {
            Console.WriteLine("Лифт остановился");
            elevator.State = new RestElevator();
        }

        public void MoveUp(Elevator elevator)
        {
            Console.WriteLine("Лифт продолжает двигаться вверх");
        }

        public void Put(Elevator elevator)
        {
            Console.WriteLine("В лифт невозможно ничего загрузить, т.к. он находится в движении");
        }

        public void TakeOut(Elevator elevator)
        {
            Console.WriteLine("Лифт невозможно разгрузить, т.к. он находится в движении");
        }

        public void PowerSupply(Elevator elevator)
        {
            Random rand = new Random();
            int checkPower = rand.Next(0, 4);

            if (checkPower == 0)
            {
                Console.WriteLine("Необходимо восстановить подачу питания");
                elevator.State = new NoPowerSupplyElevator();
            }
            else
            {
                Console.WriteLine("Лифт исправен");
            }
        }
    }
    class LoadedElevator : IElevatorState
    {
        public void MoveDown(Elevator elevator)
        {
            Console.WriteLine("Лифт движется вниз вместе с грузом");
            elevator.State = new MoveElevator();
        }

        public void Rest(Elevator elevator)
        {
            Console.WriteLine("Лифт ожидает разгрузки");
        }

        public void MoveUp(Elevator elevator)
        {
            Console.WriteLine("Лифт движется наверх вместе с грузом");
            elevator.State = new MoveElevator();
        }

        public void Put(Elevator elevator)
        {
            Console.WriteLine("Лифт уже загружен, в него невозможно ничего поместить");
        }

        public void TakeOut(Elevator elevator)
        {
            Console.WriteLine("Лифт разгружен");
            elevator.State = new RestElevator();
        }

        public void PowerSupply(Elevator elevator)
        {
            Random rand = new Random();
            int checkPower = rand.Next(0, 4);

            if (checkPower == 0)
            {
                Console.WriteLine("Необходимо восстановить подачу питания");
                elevator.State = new NoPowerSupplyElevator();
            }
            else
            {
                Console.WriteLine("Лифт исправен");
            }
        }
    }
    class NoPowerSupplyElevator : IElevatorState
    {
        public void MoveDown(Elevator elevator)
        {
            Console.WriteLine("Лифт не может двигаться вниз, т.к. нет питания");
        }

        public void Rest(Elevator elevator)
        {
            Console.WriteLine("Лифт ожидает подачу питания");
        }

        public void MoveUp(Elevator elevator)
        {
            Console.WriteLine("Лифт не может двигаться наверх, т.к. нет питания");
        }

        public void Put(Elevator elevator)
        {
            Console.WriteLine("Невозможно загрузить лифт, сначала необходимо восстановить подачу питания");
        }

        public void TakeOut(Elevator elevator)
        {
            Console.WriteLine("Невозможно загрузить лифт, сначала необходимо восстановить подачу питания");
        }

        public void PowerSupply(Elevator elevator)
        {
            Console.WriteLine("Подача энергии восстановлена, лифт находится в состоянии покоя и готов к движению");
            elevator.State = new RestElevator();
        }
    }
}
