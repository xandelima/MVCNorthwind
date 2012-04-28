using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Repositorios;
using MvcNorthwind.Models;
using Repositorio.Base;


namespace WCFService
{
   public class GetOrder : IGetOrder
    {
       public List<MvcNorthwind.Models.Order> GetAll(int value)
       {
           try
           {
               IRepositorio<Order> _repositorio = new NhRepo<Order>();
               return _repositorio.PesquisarLista().ToList<Order>();
           }
           catch (Exception e)
           {
               throw e;
           }
       }
    }
}
