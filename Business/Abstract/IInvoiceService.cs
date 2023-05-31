using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInvoiceService
    {
        IDataResult<List<Invoice>> GetAll();
        IDataResult<Invoice> GetById(int id);

        IResult Add(Invoice invoice);
        IResult Delete(Invoice invoice);
        IResult Update(Invoice invoice);
        IResult SendInvoice(InvoiceDto invoiceDto);
    }
}
