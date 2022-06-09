using AdvertisementApp.Common;
using AdvertisementApp.Dtos.Interfaces;
using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IService<CreateDto,UpdateDto,ListDto,T> //Generic Service
        where CreateDto : class, IDto,new()
        where UpdateDto : class, IDto,new()
        where ListDto : class, IDto,new()
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<IDto>> GetByIdAsync(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();


    }
}
