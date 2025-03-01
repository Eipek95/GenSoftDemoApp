using AutoMapper;
using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Entity;
using System.Linq.Expressions;
using System.Net;

namespace GenSoftDemoApp.Business.Concrete
{

    public class GenericManager<T, TResultDto, TCreateDto, TUpdateDto>(IRepository<T> _repository, IMapper mapper) : IGenericService<T, TResultDto, TCreateDto, TUpdateDto> where T : EntityBase where TResultDto : class where TCreateDto : class where TUpdateDto : class
    {

        public async Task<int> TCount() => await _repository.Count();



        public async Task<MyResponse<NoDataDto>> TCreate(TCreateDto entity)
        {
            var map = mapper.Map<T>(entity);
            var result = await _repository.Create(map);

            if (result == HttpStatusCode.Conflict)
                return MyResponse<NoDataDto>.Fail(new ErrorDto("Ad Zaten Mevcut", false), 409);

            return MyResponse<NoDataDto>.Success(201);
        }

        public async Task<MyResponse<NoDataDto>> TDelete(int id)
        {
            var result = await _repository.Delete(id);
            if (result == HttpStatusCode.NotFound)
                return MyResponse<NoDataDto>.Fail(new ErrorDto("Kayıt Bulunamadı", false), 404);

            return MyResponse<NoDataDto>.Success(200);
        }



        public async Task<int> TFilteredCount(Expression<Func<TResultDto, bool>> predicate)
        {
            var map = mapper.Map<Expression<Func<T, bool>>>(predicate);
            return await _repository.FilteredCount(map);
        }



        public async Task<MyResponse<TResultDto>> TGetByFilter(Expression<Func<TResultDto, bool>> predicate)
        {
            var map = mapper.Map<Expression<Func<T, bool>>>(predicate);
            var result = await _repository.GetByFilter(map);
            if (result is null)
                return MyResponse<TResultDto>.Fail(new ErrorDto("Kayıt Bulunamadı", false), 404);

            return MyResponse<TResultDto>.Success(mapper.Map<TResultDto>(result), 200);
        }

        public async Task<MyResponse<TResultDto>> TGetById(int id)
        {
            var result = await _repository.GetById(id);
            if (result is null)
                return MyResponse<TResultDto>.Fail(new ErrorDto("Kayıt Bulunamadı", false), 404);

            return MyResponse<TResultDto>.Success(mapper.Map<TResultDto>(result), 200);
        }



        public async Task<MyResponse<List<TResultDto>>> TGetFilteredList(Expression<Func<TResultDto, bool>> predicate)
        {
            var map = mapper.Map<Expression<Func<T, bool>>>(predicate);
            var result = await _repository.GetFilteredList(map);
            if (!result.Any())
                return MyResponse<List<TResultDto>>.Fail(new ErrorDto("Kayıt Bulunamadı", false), 404);

            return MyResponse<List<TResultDto>>.Success(mapper.Map<List<TResultDto>>(result), 200);
        }

        public async Task<MyResponse<List<TResultDto>>> TGetList()
        {
            var result = await _repository.GetList();
            if (!result.Any())
                return MyResponse<List<TResultDto>>.Fail(new ErrorDto("Kayıt Bulunamadı", false), 404);
            return MyResponse<List<TResultDto>>.Success(mapper.Map<List<TResultDto>>(result), 200);
        }

        public async Task<MyResponse<NoDataDto>> TUpdate(TUpdateDto entity)
        {
            var map = mapper.Map<T>(entity);
            var result = await _repository.Update(map);
            if (result == HttpStatusCode.Conflict)
                return MyResponse<NoDataDto>.Fail(new ErrorDto("Başlık Zaten Mevcut", false), 409);

            if (result == HttpStatusCode.NotFound)
                return MyResponse<NoDataDto>.Fail(new ErrorDto("Güncellenecek Veri Bulunamadı", false), 404);

            return MyResponse<NoDataDto>.Success(200);
        }
    }
}
