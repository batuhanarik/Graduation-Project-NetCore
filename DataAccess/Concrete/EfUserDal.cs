﻿using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, MarryUsContext>, IUserDal
    {
        public void AddClaim(UserOperationClaim operationClaim)
        {
            using (var context = new MarryUsContext())
            {
                var addedClaim = context.Entry(operationClaim);
                addedClaim.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void DeleteClaim(UserOperationClaim operationClaim)
        {
            using (var context = new MarryUsContext())
            {
                var claim = context.UserOperationClaims.SingleOrDefault(userClaim =>
                    userClaim.UserId == operationClaim.UserId &&
                    userClaim.OperationClaimId == operationClaim.OperationClaimId
                    );

                var deletedClaim = context.Entry(claim);
                deletedClaim.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<OperationClaim> GetOperationClaims()
        {
            using (var context = new MarryUsContext())
            {
                var result = from claims in context.OperationClaims
                             select claims;
                return result.ToList();
            }
        }

        public List<OperationClaim> GetUserClaims(int userId)
        {
            using (var context = new MarryUsContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == userId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public List<UserDto> GetUsers()
        {
            using (var context = new MarryUsContext())
            {
                var result = from user in context.Users
                             select new UserDto { Id = user.UserId, Email = user.Mail, FirstName = user.Name, LastName = user.LastName };
                return result.ToList();
            }
        }
    }
}
