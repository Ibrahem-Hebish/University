﻿namespace SchoolProject.Core.Mapping.RoleMapping;

public partial class RoleMappings
{
    public void GetRoleMapping()
    {
        CreateMap<Role, GetRoleDto>();
    }
}