using AutoMapper;
using QLTS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application.Mapper
{
    public class FixedAssetProfile:Profile
    {
        public FixedAssetProfile()
        {
            CreateMap<FixedAsset, FixedAssetDto>();
            CreateMap<FixedAssetCreateDto, FixedAsset>();
            CreateMap<FixedAssetUpdateDto, FixedAsset>();
        }
    }
}
