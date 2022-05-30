using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.InsuranceProcess();
            Console.Read();
        }
    }

class Client
{
    public void InsuranceProcess()
    {
        Handler insuranceAppeal = new InsuranceAppeal();
        Handler insuranceDocuments = new InsuranceDocuments();
        Handler insuranceRisk = new InsuranceRisk();
        Handler insuranceContract = new InsuranceContract();

        insuranceAppeal.SetSuccessor(insuranceDocuments);
        insuranceDocuments.SetSuccessor(insuranceRisk);
        insuranceRisk.SetSuccessor(insuranceContract);

            string[] requests = { "Регистрация обращения",
                "Формирование пакета документов",
                "Оценка рисков",
                "Создание договора страхования", "Увольнение"
        };

        foreach (string request in requests)
        {
            insuranceAppeal.HandleRequest(request);
        }
    }
}

abstract class Handler
{
    protected Handler successor;

    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(string request);
}

    class InsuranceAppeal : Handler
    {
        public override void HandleRequest(string request)
        { 
            if (request == "Регистрация обращения")
            {   
                Console.WriteLine("{0} обрабатывает {1}", GetType().Name, request);
            }
            
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("Запрос не может быть обработан {0}", GetType().Name);
            }
        }
    }

    class InsuranceDocuments : Handler
    {
    public override void HandleRequest(string request)
    {
        if (request == "Формирование пакета документов")
        {
                Console.WriteLine("{0} обрабатывает {1}", GetType().Name, request);
            }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
            else
            {
                Console.WriteLine("Запрос не может быть обработан {0}", GetType().Name);
            }
        }
    }

    class InsuranceRisk : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "Оценка рисков")
            {
                Console.WriteLine("{0} обрабатывает {1}", GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("Запрос не может быть обработан {0}", GetType().Name );
            }
        }
    }

    class InsuranceContract : Handler
    {
    public override void HandleRequest(string request)
    {
        if (request == "Создание договора страхования")
        {
                Console.WriteLine("{0} обрабатывает {1}", GetType().Name, request);
            }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
            else
            {
                Console.WriteLine("Запрос не может быть обработан {0}", GetType().Name);
            }
        }
    }

}

