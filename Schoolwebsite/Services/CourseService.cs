using Schoolwebsite.Models;
using Schoolwebsite.Repository;
using Schoolwebsite.ViewModels.Admin;

namespace Schoolwebsite.Services
{

    public interface ICourseService
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);

        Task<CourseViewModel> GetForCreateAsync();
        Task<CourseViewModel?> GetForEditAsync(int id);
        Task CreateAsync(CourseViewModel model);
        Task<bool> UpdateAsync(CourseViewModel model);
        Task<bool> DeleteAsync(int id);
    }
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _course;

        private readonly IFileUploadService _fileUpload;
        private readonly ITeacherRepository _teacher;

        public CourseService(ICourseRepository course, ITeacherRepository teacher, IFileUploadService fileUpload)
        {
            _course = course;
            _fileUpload = fileUpload;   
            _teacher = teacher;
        }



        public async Task CreateAsync(CourseViewModel model)
        {
           if(model.Image == null)
            {
                throw new ArgumentException("Please choose an image for the programme.");
            }
            var imagePath = await _fileUpload.SaveImageAsync(model.Image, "course");


            var course = new Course
            {
                Title = model.Title,
               // Category = model.Category,
                Duration = model.Duration,
                Overview = model.Overview,
                CoreSubjects = model.CoreSubjects,
                ElectiveSubjects = model.ElectiveSubjects,
                EntryRequirements = model.EntryRequirements,
                ImagePath = imagePath,
            };

            await _course.AddAsync(course);
            await _course.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var course = await _course.GetByIdAsync(id);
            if(course == null)
            {
                return false;
            }
            _fileUpload.DeleteImage(course.ImagePath);
            _course.Remove(course);
            await _course.SaveChangesAsync();
            return true;
        }

        public Task<List<Course>> GetAllAsync()=> _course.GetAllAsync();
        

        public Task<Course?> GetByIdAsync(int id)=> _course.GetByIdAsync(id);
       

        public async Task<CourseViewModel> GetForCreateAsync()
        {
            return new CourseViewModel
            {
                AvailableTeachers = await _teacher.GetAllAsync(),
            };
        }

        public async Task<CourseViewModel?> GetForEditAsync(int id)
        {
            var course = await _course.GetByIdAsync(id);
            if (course == null)
            {
                return null;
            }
            return new CourseViewModel
            {
                Id = course.CourseId,
                Title = course.Title,
               // Category = course.Category,
                Duration = course.Duration,
                Overview = course.Overview,
                CoreSubjects = course.CoreSubjects,
                ElectiveSubjects = course.ElectiveSubjects,
                EntryRequirements = course.EntryRequirements,
                ExistingImagePath = course.ImagePath,
                AvailableTeachers= await _teacher.GetAllAsync(),
            };
        }
        
        public async Task<bool> UpdateAsync(CourseViewModel model)
        {
            var course = await _course.GetByIdAsync(model.Id);
            if(course == null)
            {
                return false;
            }

            course.Title = model.Title;
          //  course.Category = model.Category;
            course.Duration = model.Duration;
            course.Overview = model.Overview;
            course.CoreSubjects = model.CoreSubjects;
            course.EntryRequirements = model.EntryRequirements;
            course.ElectiveSubjects = model.ElectiveSubjects;


            if(model.Image != null)
            {
                var newPath = await _fileUpload.SaveImageAsync(model.Image, "course");
                _fileUpload.DeleteImage(course.ImagePath);
                course.ImagePath = newPath;
            }

            _course.Update(course);
            await _course.SaveChangesAsync();
            return true;
        }
    }
}
