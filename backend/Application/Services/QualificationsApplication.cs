using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Application.Validators.Qualification;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Interfaces;
using Utilities.Static;

namespace Application.Services
{
    public class QualificationsApplication : IQualificationsApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly QualificationValidator _validationRules;

        public QualificationsApplication(IUnitOfWork unitOfWork, IMapper mapper, QualificationValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<bool>> CreateQualification(QualificationRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(requestDto);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            var qualification = _mapper.Map<Calificacione>(requestDto);
            qualification.Estado = Convert.ToBoolean(StateTypes.Active);
            response.Data = await _unitOfWork.Qualifications.CreateAsync(qualification);

            if (response.Data)
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

        public async Task<BaseResponse<bool>> DeleteQualification(int idQualification)
        {
            var response = new BaseResponse<bool>();
            var qualificationDelete = await GetQualificationById(idQualification);

            if (qualificationDelete.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            response.Data = await _unitOfWork.Qualifications.DeleteAsync(idQualification);

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

        public async Task<BaseResponse<QualificationResponseDto>> GetQualificationById(int idQualification)
        {
            var response = new BaseResponse<QualificationResponseDto>();
            var qualification = await _unitOfWork.Qualifications.GetByIdAsync(idQualification);

            if (qualification is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<QualificationResponseDto>(qualification);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<QualificationResponseDto>>> ListQualifications(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<QualificationResponseDto>>();
            var qualification = await _unitOfWork.Qualifications.ListQualifications(filters);

            if (qualification is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<QualificationResponseDto>>(qualification);
                response.Message = ReplyMessage.MESSAGE_QUERY;

                return response;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<QualificationSelectResponseDto>>> ListSelectQualifications()
        {
            var response = new BaseResponse<IEnumerable<QualificationSelectResponseDto>>();
            var qualifications = await _unitOfWork.Roles.GetAllAsync();

            if (qualifications is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<QualificationSelectResponseDto>>(qualifications);
                response.Message = ReplyMessage.MESSAGE_QUERY;

                return response;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> UpdateQualification(int idQualification, QualificationRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var roleUpdate = await GetQualificationById(idQualification);

            if (roleUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            var qualification = _mapper.Map<Calificacione>(requestDto);
            qualification.Id = idQualification;
            qualification.Estado = Convert.ToBoolean(StateTypes.Active);
            response.Data = await _unitOfWork.Qualifications.UpdateAsync(qualification);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
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
