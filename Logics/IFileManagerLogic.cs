using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ligtasUnaAPI.Models;
namespace ligtasUnaAPI.Logics
{
    public interface IFileManagerLogic
    {
        Task Upload(File model);
        Task<byte[]> Get(string imageName);
    }

}
