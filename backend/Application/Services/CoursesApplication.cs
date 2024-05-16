using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Application.Validators.Course;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Interfaces;
using Utilities.Static;

namespace Application.Services
{
    public class CoursesApplication : ICoursesApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CourseValidator _validationRules;
        private readonly IFileStorageLocalApplication _fileStorage;

        public CoursesApplication(IUnitOfWork unitOfWork, IMapper mapper, CourseValidator validationRules, IFileStorageLocalApplication fileStorage)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
            _fileStorage = fileStorage;
        }

        public async Task<BaseResponse<int>> CreateCourse(CourseRequestDto requestDto)
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

            var course = _mapper.Map<Recurso>(requestDto);
            course.Estado = Convert.ToBoolean(StateTypes.Active);

            if (requestDto.ImagenRecurso is not null)
            {
                //course.ImagenPortada = await _unitOfWork.AzureStorage.SaveFile(AzureContainers.COURSES, requestDto.ImagenRecurso);
                course.ImagenPortada = await _fileStorage.SaveFile(AzureContainers.COURSES, requestDto.ImagenRecurso);
            }

            response.Data = await _unitOfWork.Courses.CreateAsync(course);

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

        public async Task<BaseResponse<bool>> DeleteCourse(int idCourse)
        {
            var response = new BaseResponse<bool>();
            var courseUpdate = await GetCourseById(idCourse);

            if (courseUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            response.Data = await _unitOfWork.Courses.DeleteAsync(idCourse);

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

        public async Task<BaseResponse<CourseResponseDto>> GetCourseById(int courseId)
        {
            var response = new BaseResponse<CourseResponseDto>();
            var course = await _unitOfWork.Courses.GetByIdAsync(courseId);

            if (course is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<CourseResponseDto>(course);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<CourseResponseDto>>> ListCourses(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<CourseResponseDto>>();
            var courses = await _unitOfWork.Courses.ListCoursers(filters);

            if (courses is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<CourseResponseDto>>(courses);
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

        public async Task<BaseResponse<IEnumerable<CourseSelectResponseDto>>> ListSelectByProfesorId(int profesorId)
        {
            var response = new BaseResponse<IEnumerable<CourseSelectResponseDto>>();
            var courses = await _unitOfWork.Courses.GetAllAsync();

            var coursesByProfesor = courses.Where(x => x.IdProfesor == profesorId);

            if (coursesByProfesor is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<CourseSelectResponseDto>>(coursesByProfesor);
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

        public async Task<BaseResponse<IEnumerable<CourseSelectResponseDto>>> ListSelectCourses()
        {
            var response = new BaseResponse<IEnumerable<CourseSelectResponseDto>>();
            var courses = await _unitOfWork.Courses.GetAllAsync();

            if (courses is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<CourseSelectResponseDto>>(courses);
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

        public async Task<BaseResponse<bool>> UpdateCourse(int idCourse, CourseRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var courseUpdate = await GetCourseById(idCourse);

            if (courseUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            var course = _mapper.Map<Recurso>(requestDto);
            course.Id = idCourse;

            if (requestDto.ImagenRecurso is not null)
            {
                //course.ImagenPortada = await _unitOfWork.AzureStorage.SaveFile(AzureContainers.COURSES, requestDto.ImagenRecurso);
                course.ImagenPortada = await _fileStorage.SaveFile(AzureContainers.COURSES, requestDto.ImagenRecurso);
            }


            response.Data = await _unitOfWork.Courses.UpdateAsync(course);

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
