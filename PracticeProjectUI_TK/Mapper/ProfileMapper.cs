using AutoMapper;
using Entities_TK;
using PracticeProjectUI_TK.Models.ViewModels;

namespace PracticeProjectUI_TK.Mapper
{
    public class ProfileMapper:Profile
    {
        public ProfileMapper()
        {
            CreateMap<TaxpayerViewModel, Taxpayer>().ReverseMap();
        }
    }
}
