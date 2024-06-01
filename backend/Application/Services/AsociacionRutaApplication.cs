using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Application.Validators.Course;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;
using Utilities.Static;

namespace Application.Services
{
    public class AsociacionRutaApplication : IAsociacionRutaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CourseValidator _validationRules;

        public AsociacionRutaApplication(IUnitOfWork unitOfWork, IMapper mapper, CourseValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<int>> CreateAsociacionRuta(AsociacionRutaRequestDto requestDto)
        {
            var response = new BaseResponse<int>();
            var asociacionRuta = _mapper.Map<AsociacionRuta>(requestDto);
            asociacionRuta.Estado = Convert.ToBoolean(StateTypes.Active);

            response.Data = await _unitOfWork.AsociacionRuta.CreateAsync(asociacionRuta);

            if (response.Data > 0)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<AsociacionRutaResponseDto>> GetAsociacionRutaById(int courseId)
        {
            var response = new BaseResponse<AsociacionRutaResponseDto>();
            var asociacionRuta = await _unitOfWork.AsociacionRuta.GetByIdAsync(courseId);

            if (asociacionRuta is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<AsociacionRutaResponseDto>(asociacionRuta);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsociacionRuta(int idAsociacionRuta)
        {
            var response = new BaseResponse<bool>();
            var asociacionUpdate = await GetAsociacionRutaById(idAsociacionRuta);

            if (asociacionUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            response.Data = await _unitOfWork.AsociacionRuta.DeleteAsync(idAsociacionRuta);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }
    }
}
