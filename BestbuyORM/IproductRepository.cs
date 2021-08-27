using System;
using System.Collections.Generic;
using System.Text;

namespace BestbuyORM
{
    public interface IproductRepository
    {


        IEnumerable<Products> GetAllProducts();

    }
}
