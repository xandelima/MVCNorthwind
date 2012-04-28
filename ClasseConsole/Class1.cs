using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Base;
using NHibernate;
using MvcNorthwind.Models;
using NHibernate.Criterion;
using NHIbernateRepository.Infra;
using System.Diagnostics;

namespace ClasseConsole
{
    public static class Class1
    {

        public static void Main(string[] args) 
        {
            try
            {
                Stopwatch theTime = new Stopwatch();
                theTime.Start();
                ISession s = CreateSession.CriarSessao();
                theTime.Stop();
                Console.WriteLine("Tempo Total Session : {0} : {1} : {2} "
                    , theTime.Elapsed.Minutes
                    , theTime.Elapsed.Seconds
                    , theTime.Elapsed.Milliseconds);

                theTime.Reset();
                theTime.Start();

                List<MvcNorthwind.Models.Order> list = s.CreateCriteria<MvcNorthwind.Models.Order>()
                        .List<MvcNorthwind.Models.Order>()
                        .ToList<MvcNorthwind.Models.Order>();

                theTime.Stop();
                Console.WriteLine();
                TimeSpan time = theTime.Elapsed;
                
                Console.WriteLine("Tempo Total Consulta: {0} : {1} : {2} ", time.Minutes, time.Seconds, time.Milliseconds);
                Console.WriteLine();
                Console.WriteLine("Total de {0} {1}", list.Count, typeof(MvcNorthwind.Models.Order).Name);
                
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                Console.Read();
            }
        }
    }
}
