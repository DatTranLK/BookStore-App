using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRequestBookDetailRepository
    {
        void AddNewRequestBookDetail(int quantity, int requestBookId, int bookId);
        List<RequestBookDetail> GetRequestBookDetailByRequestId(int requestBookId);
        void DeleteRequestDetails(int requestBookId);
    }
}
