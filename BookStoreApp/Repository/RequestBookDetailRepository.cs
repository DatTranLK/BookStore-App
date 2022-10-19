using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RequestBookDetailRepository : IRequestBookDetailRepository
    {
        public void AddNewRequestBookDetail(int quantity, int requestBookId, int bookId) 
            => RequetBookDetailDAO.Instance.AddNewRequestBookDetail(quantity, requestBookId, bookId);

        public void DeleteRequestDetails(int requestBookId) => RequetBookDetailDAO.Instance.DeleteRequestDetails(requestBookId);

        public List<RequestBookDetail> GetRequestBookDetailByRequestId(int requestBookId) 
            => RequetBookDetailDAO.Instance.GetRequestBookDetailByRequestId(requestBookId);
    }
}
