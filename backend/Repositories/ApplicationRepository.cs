using Glossary.Models.Glossary;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;

namespace Glossary.Repositories
{
    public class ApplicationRepository
    {
        protected IConfiguration config;

        protected GlossaryContext dbGlossary;

        public ApplicationRepository()
        {
            dbGlossary = new GlossaryContext();

            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
    }
}