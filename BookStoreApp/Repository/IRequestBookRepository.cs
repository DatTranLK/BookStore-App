using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRequestBookRepository
    {
        int AddNewImportBook(RequestBook request);
        List<RequestBook> GetRequestBooks();
        RequestBook GetRequestById(int id);
        void DeleteImportById(int id);
        void UpdateImport(RequestBook requestBook);
    }
}
