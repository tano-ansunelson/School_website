using Schoolwebsite.Models;
using Schoolwebsite.Repository;
using Schoolwebsite.ViewModels.Admin;

namespace Schoolwebsite.Services
{

    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);

        Task<TeacherViewModel?> GetForEditAsync(int id);
        Task CreateAsync(TeacherViewModel model);
        Task<bool> UpdateAsync(TeacherViewModel model);
        Task<bool> DeleteAsync(int id);
    }


    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacher;
        private readonly IFileUploadService _fileUpload;

        public TeacherService(ITeacherRepository teacher, IFileUploadService fileUpload)
        {
            _teacher = teacher;
            _fileUpload = fileUpload;
        }

        public async Task CreateAsync(TeacherViewModel model)
        {
            if(model.Image == null)
            {
                throw new ArgumentException("Please choose a photo for the teacher.");
            }

            var imagePath = await _fileUpload.SaveImageAsync(model.Image, "teacher");
            var teacher = new Teacher
            {
                Name = model.Name,
                Role = model.Role,
                Subject = model.Subject,
                About = model.About,
                Achievements = model.Achievements,
                Objective = model.Objective,
                IsAdministration = model.IsAdministration,
                IsHod = model.IsHod,
                IsHouseMaster = model.IsHouseMaster,
                IsTeacher = model.IsTeacher,
                AdministrationTitle = model.IsAdministration ? model.AdministrationTitle:null,
                HodTitle = model.IsHod ? model.HodTitle:null,
                HouseMasterTitle = model.IsHouseMaster ? model.HouseMasterTitle:null,
                FacebookUrl = string.IsNullOrWhiteSpace(model.FacebookUrl) ? "#" : model.FacebookUrl,
                TwitterUrl = string.IsNullOrWhiteSpace(model.TwitterUrl) ? "#" : model.TwitterUrl,
                LinkedInUrl = string.IsNullOrWhiteSpace(model.LinkedInUrl) ? "#" : model.LinkedInUrl,
                ImagePath = imagePath
            };
            await _teacher.AddAsync(teacher);
            await _teacher.SaveChangesAsync ();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var teacher = await _teacher.GetByIdAsync(id);
            if (teacher == null)
            {
                return false;
            }

            try
            {
                _fileUpload.DeleteImage(teacher.ImagePath);
                _teacher.Remove(teacher);
                await _teacher.SaveChangesAsync();
                return true;
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                // Most likely cause: this teacher still coordinates one or more
                // courses (see the Restrict delete behaviour on Course.Coordinator).
                throw new InvalidOperationException(
                    "This teacher can't be deleted while they are still assigned as a coordinator on one or more programmes. " +
                    "Reassign or delete those programmes first.", ex);
            }
        }

        public Task<List<Teacher>> GetAllAsync() => _teacher.GetAllAsync();
       

        public Task<Teacher?> GetByIdAsync(int id)=> _teacher.GetByIdAsync(id);
     

        public async Task<TeacherViewModel?> GetForEditAsync(int id)
        {
          var teacher = await _teacher.GetByIdAsync(id);
            if(teacher == null)
            {
                return null;
            }

            return new TeacherViewModel
            {
                Id = teacher.TeacherId,
                Name = teacher.Name,
                Role = teacher.Role,
                Subject = teacher.Subject,
                About = teacher.About,
                Achievements = teacher.Achievements,
                Objective = teacher.Objective,
                FacebookUrl = teacher.FacebookUrl,
                TwitterUrl = teacher.TwitterUrl,
                LinkedInUrl = teacher.LinkedInUrl,
                IsAdministration = teacher.IsAdministration,
                IsHouseMaster = teacher.IsHouseMaster,
                IsHod = teacher.IsHod,
                IsTeacher = teacher.IsTeacher,
                ExistingImagePath = teacher.ImagePath,
                HouseMasterTitle = teacher.HouseMasterTitle,
                HodTitle = teacher.HodTitle,
                AdministrationTitle = teacher.AdministrationTitle,
            };
        }

        public async Task<bool> UpdateAsync(TeacherViewModel model)
        {
           var teacher = await _teacher.GetByIdAsync(model.Id);

            if(teacher == null)
            {
                return false;
            }

            teacher.Name = model.Name;
            teacher.Role = model.Role;
            teacher.Subject = model.Subject;
            teacher.About = model.About;
            teacher.Achievements = model.Achievements;
            teacher.Objective = model.Objective;
            teacher.IsTeacher = model.IsTeacher;
            teacher.IsHouseMaster = model.IsHouseMaster;
            teacher.IsHod = model.IsHod;
            teacher.IsAdministration = model.IsAdministration;
            teacher.AdministrationTitle = model.IsAdministration ? model.AdministrationTitle:null;
            teacher.HodTitle = model.IsHod ? model.HodTitle:null;
            teacher.HouseMasterTitle = model.IsHouseMaster? model.HouseMasterTitle:null;
            teacher.FacebookUrl = string.IsNullOrWhiteSpace(model.FacebookUrl) ? "#": model.FacebookUrl;
            teacher.TwitterUrl = string.IsNullOrWhiteSpace(model.TwitterUrl) ? "#": model.TwitterUrl;
            teacher.LinkedInUrl = string.IsNullOrWhiteSpace(model.LinkedInUrl) ? "#" : model.LinkedInUrl;

            if(model.Image != null)
            {
                var newPath = await _fileUpload.SaveImageAsync(model.Image, "teachers");
                _fileUpload.DeleteImage(teacher.ImagePath);
                teacher.ImagePath = newPath;
            }

            _teacher.Update(teacher);
            await _teacher.SaveChangesAsync();
            return  true;

        }
    }
}
