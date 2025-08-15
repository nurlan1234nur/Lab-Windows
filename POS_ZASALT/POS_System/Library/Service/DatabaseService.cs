using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Repository;

namespace Library.Service
{
    public class DatabaseService
    {
        private readonly DatabaseRepository _dataRepository;

        public DatabaseService()
        {
            _dataRepository = new DatabaseRepository();
            
        }

        public void InitializeDatabase()
        {
            _dataRepository.CreateDatabase();
        }
    }
}
