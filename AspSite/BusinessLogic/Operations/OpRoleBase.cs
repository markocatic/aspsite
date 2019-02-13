using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.DataLayer;
using AspSite.BusinessLogic.Dto;
using Microsoft.Ajax.Utilities;

namespace AspSite.BusinessLogic.Operations
{
    public class RoleCriteria : SelectCriteria
    {
        public string Name { get; set; }
    }
    public class OpRoleBase : Operation
    {
        
        public RoleDto Role = new RoleDto();
        public RoleCriteria Criteria = new RoleCriteria();
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {


            IEnumerable<RoleDto> ieRoles =
                from r in entities.AspNetRoles
                select new RoleDto
                {
                    Name = r.Name,
                    UUID = r.Id
                };
            if (!Criteria.Uuid.IsNullOrWhiteSpace())
            {
                ieRoles = ieRoles.Where(r => r.UUID == Criteria.Uuid);
            }
            if (!Criteria.Name.IsNullOrWhiteSpace())
            {
                ieRoles = ieRoles.Where(r => r.Name == Criteria.Name);
            }
            OperationResult result = new OperationResult();
            result.Items = ieRoles.ToArray();
            result.Status = true;
            return result;
        }
    }

    public class OpRoleInsert : OpRoleBase
    {
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            AspNetRole role = new AspNetRole();
            role.Name = this.Role.Name;
            role.Id = Guid.NewGuid().ToString();
            entities.AspNetRoles.Add(role);

            entities.SaveChanges();

            return base.Execute(entities);

        }
    }

    public class OpRoleDelete : OpRoleBase
    {
        public string Uuid { get; set; }
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            
            AspNetRole role = entities.AspNetRoles.Where(r => r.Id == Uuid && r.AspNetUsers.Count() == 0).FirstOrDefault();
            if (role != null)
            {
                entities.AspNetRoles.Remove(role);
                entities.SaveChanges();
                return base.Execute(entities);
            }
            else
            {
                OperationResult result = new OperationResult();
                result.Status = false;
                result.Message = "The role doesn't exist or has some users";
                return result;
            }
            
        }

        
    }

    public class OpRoleUpdate : OpRoleBase
    {
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            AspNetRole role = entities.AspNetRoles.Where(r => r.Id == Role.UUID).FirstOrDefault();
            if (role != null)
            {
                role.Name = Role.Name;
                entities.SaveChanges();
                return base.Execute(entities);
            }
            else
            {
                OperationResult result = new OperationResult();
                result.Status = false;
                result.Message = "The role doesn't exist or has some users";
                return result;
            }


        }
    }

}