﻿using Atos.DevSkills.Domain.Extension;
using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Domain.ViewModel;
using Atos.DevSkills.Infra.Data.Repository.Factories;
using Atos.DevSkills.Service.Validators;

namespace Atos.DevSkills.Service.Service
{
    public class DesenvolvedorService : IDesenvolvedorService
    {
        private readonly DesenvolvedorRepositoryFactory _desenvolvedorFactory;
        private readonly SkillRepositoryFactory _skillFactory;        
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;        
        private readonly ISkillRepository _skillRepository;        

        public DesenvolvedorService(DesenvolvedorRepositoryFactory desenvolvedorFactory, SkillRepositoryFactory skillFactory)
        {            
            _desenvolvedorFactory = desenvolvedorFactory;
            _desenvolvedorRepository = _desenvolvedorFactory.CreateFactory();

            _skillFactory = skillFactory;
            _skillRepository = _skillFactory.CreateFactory();
        }

        public async Task<List<DesenvolvedorViewModel>> ListAll()
        {
            var listaDevs = new List<DesenvolvedorViewModel>();

            var desenvolvedorList = await _desenvolvedorRepository.ListAllWithSkill();

            foreach (var dev in desenvolvedorList)
            {
                listaDevs.Add(dev.ToDesenvolvedorViewModel());
            }
            return listaDevs;
        }

        public async Task<List<DesenvolvedorViewModel>> ListAllBySkill(string skill)
        {
            var desenvolvedorList = await _desenvolvedorRepository.ListAllBySkill(skill);   
            
            return desenvolvedorList.Select(x => x.ToDesenvolvedorViewModel()).ToList();
        }

        public async Task<DesenvolvedorViewModel> FindById(int id)
        {
            var desenvolvedor = await _desenvolvedorRepository.FindByIdWithSkills(id);
            return desenvolvedor.ToDesenvolvedorViewModel();
        }

        public async Task<DefaultViewModel<DesenvolvedorViewModel>> AddAsync(DesenvolvedorInputModel model)
        {
            if (await _desenvolvedorRepository.ExistByEmail(model.Email))
                throw new Exception($"E-mail já existente.");

            var skills = await SkillValidator.CreateSkillNotExists(model.Skills, _skillRepository);

            var desenvolvedor = await _desenvolvedorRepository.Add(model.ToDesenvolvedor(skills));

            return new DefaultViewModel<DesenvolvedorViewModel>(desenvolvedor.ToDesenvolvedorViewModel());

        }             

        public async Task<DesenvolvedorViewModel> UpdateById(int id, DesenvolvedorUpdateInputModel model)
        {
            var desenvolvedor = await _desenvolvedorRepository.FindById(id);

            DesenvolvedorValidador.Validate(desenvolvedor);

            var dev = await DesenvolvedorValidador.Validate(model, desenvolvedor, _desenvolvedorRepository);

            var desenvolvedorUpdate = await _desenvolvedorRepository.Update(dev);

            return desenvolvedorUpdate.ToDesenvolvedorViewModel();
        }

        public async Task Delete(int id)
        {
            var buscaDesenvolvedor = await _desenvolvedorRepository.FindById(id);

            if (buscaDesenvolvedor != null)
                await _desenvolvedorRepository.Delete(buscaDesenvolvedor);
        }
    }
}
