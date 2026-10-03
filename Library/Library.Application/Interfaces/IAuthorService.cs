using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.DTOs;

using Library.Domain.Entities; 

namespace Library.Application.Interfaces
{
    public interface IAuthorService
    {
        // حتماً باید <Task<IEnumerable<Author>>> باشد، نه فقط Task
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
    }
}
