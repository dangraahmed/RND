using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain = CommerceDomain;

namespace CommerceSqlDataAccess
{

    public partial class Product
    {
        public Domain.Product ToDomainProduct()
        {
            Domain.Product p = new Domain.Product();
            p.Name = this.Name;
            p.UnitPrice = this.UnitPrice;
            return p;
        }
    }

    public class SqlProductRepository : Domain.ProductRepository
    {
        private readonly CommerceSqlDataAccessDataContext context;        

        public SqlProductRepository(string connString)
        {
            this.context = new CommerceSqlDataAccessDataContext(connString);    
        }

        public override IEnumerable<Domain.Product> GetFeaturedProducts()
        {
            var products = (from p in context.Products
                            where p.Feature
                            select p).AsEnumerable();
            
            return from p in products
                   select p.ToDomainProduct();
        }
    }
}
