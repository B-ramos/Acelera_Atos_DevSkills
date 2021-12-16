using Atos.DevSkills.Domain.Config;
using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Infra.Data.Repository.Factories;
using Atos.DevSkills.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Atos.DevSkills.Test
{
    [TestClass]
    public class DesenvolvedorServiceTest
    {
        private readonly Mock<DesenvolvedorRepositoryFactory> _repositoryFactory;
        private readonly Mock<SkillRepositoryFactory> _skillFactory;

        public DesenvolvedorServiceTest()
        {
            Config.Flag = true;

            _repositoryFactory = new Mock<DesenvolvedorRepositoryFactory>(null);
            _skillFactory = new Mock<SkillRepositoryFactory>(null);
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
            dev.Email = "jose@email.com";
            dev.Skills = skills;            

            var service = new DesenvolvedorService(_repositoryFactory.Object, _skillFactory.Object);

            var response = service.AddAsync(dev).Result;

            Assert.AreEqual(0, response.CodError);
        }

        [TestMethod]
        public void AddExistingDeveloperEmailShouldThrowAnException()
        {
            List<string> skills = new List<string>();
            skills.Add("C#");
            skills.Add("String");

            DesenvolvedorInputModel dev = new DesenvolvedorInputModel();
            dev.NomeCompleto = "José Maria";
            dev.Cpf = "125478965412";
            dev.DtNascimento = DateTime.Now;
            dev.Telefone = "+5586998745632";
            dev.Email = "teste@email.com";
            dev.Skills = skills;            

            var service = new DesenvolvedorService(_repositoryFactory.Object, _skillFactory.Object);

            var exe = Assert.ThrowsExceptionAsync<Exception>(
                async () => await service.AddAsync(dev));            

            Assert.AreEqual("E-mail já existente.", exe.Result.Message);
        }

    }
}
  