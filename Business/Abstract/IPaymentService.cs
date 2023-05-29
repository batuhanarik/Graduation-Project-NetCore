﻿using Core.Utilities.Results;
using Entities.Concrete;


namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Pay(CreditCard card, int amount);
    }
}
