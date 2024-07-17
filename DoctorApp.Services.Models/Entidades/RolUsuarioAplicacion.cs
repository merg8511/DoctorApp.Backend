﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Models.Entidades
{
    public class RolUsuarioAplicacion : IdentityUserRole<int>
    {
        public UsuarioAplicacion UsuarioAplicacion { get; set; }
        public RolAplicacion RoleAplicacion { get; set; }
    }
}
