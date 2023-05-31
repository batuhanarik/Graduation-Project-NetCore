using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private IInvoiceDal _invoiceDal;
        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }
        public IResult Add(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Invoice>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Invoice> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult SendInvoice(InvoiceDto invoiceDto)
        {
            _invoiceDal.SendInvoice(invoiceDto);
            return new SuccessResult();
        }

        public IResult Update(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
