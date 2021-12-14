﻿using Atos.DevSkills.Domain.Extension;
using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Domain.ViewModel;
using Atos.DevSkills.Service.Validators;

namespace Atos.DevSkills.Service.Service
{
    public class DesenvolvedorService : IDesenvolvedorService
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;
        //private readonly DesenvolvedorValidador _validator;

        public DesenvolvedorService(IDesenvolvedorRepository desenvolvedorRepository)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
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

        public async Task<List<DesenvolvedorViewModel>> ListAllByskill(string skill)
        {
            var listaDevs = new List<DesenvolvedorViewModel>();

            var desenvolvedorList = await _desenvolvedorRepository.ListAllBySkill(skill);
            foreach (var dev in desenvolvedorList)
            {
                listaDevs.Add(dev.ToDesenvolvedorViewModel());
            }
            return listaDevs;
        }

        public async Task<DesenvolvedorViewModel> FindById(int id)
        {
            var desenvolvedor = await _desenvolvedorRepository.FindByIdWithSkills(id);
            return desenvolvedor.ToDesenvolvedorViewModel();
        }

        public async Task<DesenvolvedorViewModel> AddAsync(DesenvolvedorInputModel model)
        {
            var listaSkills = new List<Skill>();

            foreach (var skill in model.Skills)
                listaSkills.Add(new Skill { Habilidade = skill });

            var desenvolvedor = await _desenvolvedorRepository.Add(model.ToDesenvolvedor(listaSkills));

            return desenvolvedor.ToDesenvolvedorViewModel();
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
