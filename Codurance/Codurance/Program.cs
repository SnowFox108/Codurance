using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Codurance.Data.Infrastructure;
using Codurance.Data.Model;
using Codurance.Data.Repository;
using Codurance.Infrastructure;
using Codurance.Services;
using Codurance.Services.Shared;

namespace Codurance
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
        }
    }
}
