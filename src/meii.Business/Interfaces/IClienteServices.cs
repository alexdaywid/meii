﻿using meii.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meii.Business.Interfaces
{
    public interface IClienteServices : IDisposable
    {
        Task Add(Cliente cliente);
        Task<Cliente> GetId(int id);
        Task Update(Cliente cliente);
        Task Remove(Cliente cliente);
       
    }
}
