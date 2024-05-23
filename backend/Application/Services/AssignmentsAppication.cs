﻿using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Application.Validators.Assignments;
using AutoMapper;
using Domain.Entities;
using Domain.EntitiesDto;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Utilities.Static;

namespace Application.Services
{
    public class AssignmentsAppication : IAssignmentsApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AssignmentValidator _validationRules;

        public AssignmentsAppication(AssignmentValidator validationRules, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _validationRules = validationRules;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<AssignmentResponseDto>> AssignmentsByStudent(int studentId)
        {
            var response = new BaseResponse<AssignmentResponseDto>();
            var assignments = await _unitOfWork.Assignments.AssignmentsByStudent(studentId);

            if (assignments is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<AssignmentResponseDto>(assignments);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<int>> CreateAssignment(AssignmentRequestDto requestDto)
        {
            var response = new BaseResponse<int>();
            var validationResult = await _validationRules.ValidateAsync(requestDto);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            var assignment = _mapper.Map<Asignacion>(requestDto);
            assignment.Estado = Convert.ToBoolean(StateTypes.Active);
            response.Data = await _unitOfWork.Assignments.CreateAsync(assignment);

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

        public async Task<BaseResponse<bool>> DeleteAssignment(int idAssignment)
        {
            var response = new BaseResponse<bool>();
            var assignmentDelete = await GetAssignmentById(idAssignment);

            if (assignmentDelete.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            response.Data = await _unitOfWork.Assignments.DeleteAsync(idAssignment);

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

        public async Task<BaseResponse<AssignmentResponseDto>> GetAssignmentById(int assignmentId)
        {
            var response = new BaseResponse<AssignmentResponseDto>();
            var assignment = await _unitOfWork.Assignments.GetByIdAsync(assignmentId);

            if (assignment is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<AssignmentResponseDto>(assignment);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<AssignmentResponseDto>>> ListAssignments(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<AssignmentResponseDto>>();
            var assignment = await _unitOfWork.Assignments.ListAssignments(filters);

            if (assignment is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<AssignmentResponseDto>>(assignment);
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

        public async Task<BaseResponse<IEnumerable<AssignmentSelectResponseDto>>> ListSelectAssignments(int studentId)
        {
            var response = new BaseResponse<IEnumerable<AssignmentSelectResponseDto>>();

            var assignments = await _unitOfWork.Assignments.GetAllAsync();
            var courses = await _unitOfWork.Courses.GetAllAsync();

            var assignmentsByStudent = (from a in assignments
                                        join r in courses on a.IdRecurso equals r.Id
                                        where a.IdEstudiante == studentId
                                        select new AssignmentSelectResponseDto
                                        {
                                            IdAsignacion = a.Id,
                                            IdRecurso = a.IdRecurso,
                                            ImagenPortada = r.ImagenPortada,
                                            NombreRecurso = r.NombreRecurso,
                                            Descripcion = r.Descripcion,
                                            Duracion = r.Duracion,
                                            FechaAsignacion = a.FechaAsignacion
                                        }).ToList();


            if (assignments is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<AssignmentSelectResponseDto>>(assignmentsByStudent);
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

        public async Task<BaseResponse<bool>> UpdateAssignment(int idAssignment, AssignmentRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var assignmentUpdate = await GetAssignmentById(idAssignment);

            if (assignmentUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            var assignment = _mapper.Map<Asignacion>(requestDto);
            assignment.Id = idAssignment;
            assignment.Estado = Convert.ToBoolean(StateTypes.Active);
            response.Data = await _unitOfWork.Assignments.UpdateAsync(assignment);

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
