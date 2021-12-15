using Atos.DevSkills.Domain.Config;
using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Infra.Data.Repository.Factories;
using Atos.DevSkills.Infra.Data.Repository.Mocks;
using Atos.DevSkills.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atos.DevSkills.Test
{
    [TestClass]
    public class DesenvolvedorServiceTest
    {
        protected IDesenvolvedorService _service;

        public DesenvolvedorServiceTest(IDesenvolvedorService service) 
        { 
            Config.Flag = true;
            _service = service;
        }

        [TestMethod]
        public void SholdAddDeveloper()
        {
            List<string> skills = new List<string>();
            skills.Add("C#");
            skills.Add("String");

            DesenvolvedorInputModel dev = new DesenvolvedorInputModel();
            dev.NomeCompleto = "José Maria";
            dev.Cpf = "125478965412";
            dev.DtNascimento = DateTime.Now;
            dev.Telefone = "+5586998745632";
            dev.Skills = skills;

            var response = _service.AddAsync(dev).Result;

            Assert.AreEqual(0, response.CodError);
        }

        public void True() 
        {
            Assert.AreEqual(true, true);
        }
    }
}