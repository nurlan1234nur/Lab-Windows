using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public  interface IUser
    {
        public void DeleteProduct(Product product);

        public void UpdateProduct(Product product);

        public void InsertProduct(Product product);



    }
}
