using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel;

namespace UserInterface
{
    public class CompositionRoot
    {
        private readonly IControllerFactory controllerFactory;

        public CompositionRoot()
        {
            this.controllerFactory = CreateControllerFactory();
        }

        public IControllerFactory ControllerFactory
        {
            get { return controllerFactory; }
        }

        private static IControllerFactory CreateControllerFactory()
        {
            string connectionString = ConfigurationManager.AppSettings["SQLDataAccessConnectionString"];
            string productRepositryTypeName = ConfigurationManager.AppSettings["ProductRepositoryType"];

            var productRepositryType = Type.GetType(productRepositryTypeName, true);
            var repository = (ProductRepository) Activator.CreateInstance(productRepositryType, connectionString);
            var controllerFactory = new CommerceControllerFactory(repository);
            
            return controllerFactory;
        }
    }
}