using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.BusinessLogic.Dto;
using AspSite.DataLayer;
using Microsoft.Ajax.Utilities;

namespace AspSite.BusinessLogic.Operations
{
    public class UserCriteria : SelectCriteria
    {
        public string Name { get; set; }
    }
    public class OpUserBase : Operation
    {
        public UserDetailsDto User = new UserDetailsDto();
        public UserCriteria Criteria = new UserCriteria();
        //public int id;
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {

            IEnumerable<UserDetailsDto> ieUsers =
                from i in entities.AspNetUsers
                select new UserDetailsDto
                {
                    UUID = i.Id,
                    UserName = i.UserName,
                    Email = i.Email,
                    PasswordHash = i.PasswordHash 

                };

            if (!Criteria.Uuid.IsNullOrWhiteSpace())
            {
                ieUsers = ieUsers.Where(r => r.UUID == Criteria.Uuid);
            }

            //if (!Criteria.Name.IsNullOrWhiteSpace())
            //{
            //    ieUsers = ieUsers.Where(r => r.UserName == Criteria.Name);
            //}

            UserDetailsDto[] user = ieUsers.ToArray();
            OperationResult result = new OperationResult();
            result.Status = true;
            result.Items = user;
            return result;

        }




    }

    public class OpUserInsert : OpUserBase
    {
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
             AspNetUser user = new AspNetUser();
            user.UserName = this.User.UserName;
            user.Id = Guid.NewGuid().ToString();
            user.Email = this.User.Email;
            user.PasswordHash = this.User.PasswordHash;

            entities.AspNetUsers.Add(user);
            entities.SaveChanges();
            return base.Execute(entities);
        }
    }

    public class OpUserUpdate : OpUserBase
    {
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            AspNetUser user = entities.AspNetUsers.Where(r => r.Id == User.UUID).FirstOrDefault();
            if (user != null)
            {
                user.UserName = User.UserName;
                user.Email = User.Email;
                user.PasswordHash = User.PasswordHash;
                entities.SaveChanges();
                return base.Execute(entities);
            }
            else
            {
                OperationResult result = new OperationResult();
                result.Status = false;
                result.Message = "The user doesn't exist.";
                return result;
            }
        }
    }

    public class OpUserDelete : OpUserBase
    {
        public string Uuid { get; set; }

        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            AspNetUser user = entities.AspNetUsers.Where(r => r.Id == Uuid).FirstOrDefault();
            if (user != null)
            {
                entities.AspNetUsers.Remove(user);
                entities.SaveChanges();
                return base.Execute(entities);
            }
            else
            {
                OperationResult result = new OperationResult();
                result.Status = false;
                result.Message = "The user doesn't exist.";
                return result;
            }
        }
    }
}