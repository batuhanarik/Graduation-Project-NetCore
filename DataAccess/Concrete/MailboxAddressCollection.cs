using MimeKit;
using System.Collections;
using System.Collections.Generic;

namespace DataAccess.Concrete
{
    internal class MailboxAddressCollection : IEnumerable<InternetAddress>
    {
        public IEnumerator<InternetAddress> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}