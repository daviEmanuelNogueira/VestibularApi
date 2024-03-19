using AutoMapper;
using Core;
using VestibularApi.ViewModel;

namespace VestibularApi.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        
        public AutoMapperSetup()
        {
            #region ViewModelToDomain
            //Cliente
            CreateMap<RespostasViewModel, Resposta>();
            CreateMap<CadernoViewModel, Caderno>();
            CreateMap<QuestaoViewModel, Questao>(); 
            #endregion

            #region DomainToViewModel
            CreateMap<Resposta, RespostasViewModel>();
            CreateMap<Caderno, CadernoViewModel>();
            CreateMap<Questao, QuestaoViewModel>(); 
            #endregion
        }
    }
}
