using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Platform.Core.Models;

namespace Platform.Core.Abstractions
{
    public interface ICourseRepository
    {
        Task<List<Course>> Get();
        Task<Guid> Create(Course course);

        Task<Guid> Update(Guid id, string title, string description);
        Task<Guid> Delete(Guid id);
    }
}     