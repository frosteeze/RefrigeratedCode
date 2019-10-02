using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefrigeratedCode.Data
{
    class RefrigeratedCodeContext : IRefrigeratedCodeRepository
    {
        private IConfigurationRoot _config;

        public RefrigeratedCodeContext(IConfigurationRoot config, DbContextOptions options) : base()
        {
            _config = config;
        }


        
    }
}
