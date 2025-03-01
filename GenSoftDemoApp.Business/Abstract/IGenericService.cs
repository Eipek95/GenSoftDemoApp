using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Entity;
using System.Linq.Expressions;

namespace GemSoftDemoApp.Business.Abstract
{
    public interface IGenericService<T, TResultDto, TCreateDto, TUpdateDto> where T : EntityBase where TResultDto : class where TCreateDto : class where TUpdateDto : class
    {
        Task<MyResponse<List<TResultDto>>> TGetList();

        Task<MyResponse<TResultDto>> TGetByFilter(Expression<Func<TResultDto, bool>> predicate);

        Task<MyResponse<TResultDto>> TGetById(int id);

        Task<MyResponse<NoDataDto>> TCreate(TCreateDto entity);

        Task<MyResponse<NoDataDto>> TUpdate(TUpdateDto entity);

        Task<MyResponse<NoDataDto>> TDelete(int id);
        Task<int> TCount();
        Task<int> TFilteredCount(Expression<Func<TResultDto, bool>> predicate);
        Task<MyResponse<List<TResultDto>>> TGetFilteredList(Expression<Func<TResultDto, bool>> predicate);
    }
}
