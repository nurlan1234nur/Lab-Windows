using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class PaymentService
    {
        public PaymentService() { }

        /// <summary>
        /// Төлбөр төлөгдсөн эсэхийг шалгах
        /// </summary>
        public bool checkIsPaid(double paid, double Total)
        {
            return paid >= Total;
        }

        /// <summary>
        /// Үлдэгдэл мөнгийг тооцоолох
        /// </summary>
        public double calculateChange(double paid, double Total)
        {
            return paid - Total;
        }   
    }
}
