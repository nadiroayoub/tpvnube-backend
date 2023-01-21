using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using System;
using System.Configuration;
using TPVNUBEGenEmpleadoRESTAzure.DTO;
using TPVNUBEGenNHibernate.CAD.Rest;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Cfg;

using TPVNUBEGenNHibernate.EN.Rest;
namespace TPVNUBETests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin()
        {
            ////Configuration configuration = new Configuration();
            //var configuration = new NHibernate.Cfg.Configuration();
            //configuration.Configure();
            //configuration.AddAssembly(typeof(NegocioEN).Assembly);
            //ISessionFactory _sessionFactory = configuration.BuildSessionFactory();
            var session = NHibernateHelper.OpenSession();
            TPVNUBEGenEmpleadoRESTAzure.Controllers.EmpleadoAnomController empleadoAnomController= new TPVNUBEGenEmpleadoRESTAzure.Controllers.EmpleadoAnomController();
            EmpleadoDTO empleadoDTO = new EmpleadoDTO()
            {
                Email = "",
                Pass = ""
            };
            empleadoAnomController.Login(empleadoDTO);
        }
    }
}
