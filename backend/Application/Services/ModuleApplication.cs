﻿using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Application.Validators.Module;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Interfaces;
using Utilities.Static;

namespace Application.Services
{
    internal class ModuleApplication : IModuleApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ModuleValidator _validationRules;

        public ModuleApplication(IUnitOfWork unitOfWork, IMapper mapper, ModuleValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<int>> CreateModule(List<ModuleRequestDto> requestDto)
        {
            var response = new BaseResponse<int>();

            foreach (var request in requestDto)
            {
                var modulo = _mapper.Map<Modulo>(request);
                modulo.Estado = Convert.ToBoolean(StateTypes.Active);
                response.Data = await _unitOfWork.Modulos.CreateAsync(modulo);
            }

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

        public async Task<BaseResponse<bool>> DeleteModule(int idModulo)
        {
            var response = new BaseResponse<bool>();
            var categoryUpdate = await GetModuleById(idModulo);

            if (categoryUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            response.Data = await _unitOfWork.Modulos.DeleteAsync(idModulo);

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

        public async Task<BaseResponse<ModuleResponseDto>> GetModuleById(int idModulo)
        {
            var response = new BaseResponse<ModuleResponseDto>();
            var courses = await _unitOfWork.Modulos.GetAllAsync();

            var course = courses.Where(x => x.Id == idModulo).ToList();

            if (course is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<ModuleResponseDto>(course[0]);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<ModuleResponseDto>>> ListModules(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<ModuleResponseDto>>();
            var courses = await _unitOfWork.Modulos.ListModules(filters);

            if (courses is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<ModuleResponseDto>>(courses);
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

        public async Task<BaseResponse<IEnumerable<ModuleSelectResponseDto>>> ListSelectModules(int moduleId)
        {
            var response = new BaseResponse<IEnumerable<ModuleSelectResponseDto>>();
            var courses = await _unitOfWork.Modulos.GetAllAsync();

            var modulos = courses.Where(x => x.IdRecurso == moduleId).ToList();

            if (modulos is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<ModuleSelectResponseDto>>(modulos);
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

        public async Task<BaseResponse<bool>> UpdateModule(int idModulo, List<ModuleRequestDto> requestDto)
        {
            var response = new BaseResponse<bool>();

            foreach (var item in requestDto)
            {
                var courseUpdate = await GetModuleById(item.IdModulo);

                if (courseUpdate.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                    return response;
                }

                var modulo = _mapper.Map<Modulo>(item);
                modulo.Id = item.IdModulo;
                modulo.Estado = Convert.ToBoolean(StateTypes.Active);
                response.Data = await _unitOfWork.Modulos.UpdateAsync(modulo);

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

                
            }

            return response;

        }
    }
}
