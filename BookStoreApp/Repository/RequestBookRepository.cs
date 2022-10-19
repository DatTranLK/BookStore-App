using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RequestBookRepository : IRequestBookRepository
    {
        public int AddNewImportBook(RequestBook request) => RequestBookDAO.Instance.AddNewImportBook(request);

        public void DeleteImportById(int id) => RequestBookDAO.Instance.DeleteImportById(id);

        public List<RequestBook> GetRequestBooks() => RequestBookDAO.Instance.GetRequestBooks();

        public RequestBook GetRequestById(int id) => RequestBookDAO.Instance.GetRequestById(id);

        public void UpdateImport(RequestBook requestBook) => RequestBookDAO.Instance.UpdateImport(requestBook);
    }
}
