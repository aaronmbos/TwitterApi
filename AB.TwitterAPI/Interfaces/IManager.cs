using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AB.TwitterAPI.Interfaces
{
    public interface IManager
    {
        bool TryParse<T, T2>(ref T model, out T2 outModel);
    }
}