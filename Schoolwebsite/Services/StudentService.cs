using Schoolwebsite.Models;
using Schoolwebsite.Repository;
using Schoolwebsite.ViewModels.Admin;

namespace Schoolwebsite.Services
{

    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);

        Task<StudentViewModel?> GetForEditAsync(int id);
        Task CreateAsync(StudentViewModel model);
        Task<bool> UpdateAsync(StudentViewModel model);
        Task<bool> DeleteAsync(int id);
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositoty _student;
        private readonly IFileUploadService _fileUpload;

        public StudentService(IStudentRepositoty student, IFileUploadService fileUpload)
        {
            _student = student;
            _fileUpload = fileUpload;
        }

      

        public async Task CreateAsync(StudentViewModel model)
        {
            if (model.Image == null)
            {
                throw new ArgumentException("Please choose a photo for the student.");
            }

            var imagePath =await _fileUpload.SaveImageAsync(model.Image, "student");


            var student = new Student
            {
                    Name = model.Name,
                    Role = model.Role,
                    ImagePath = imagePath,
            };
            await _student.AddAsync(student);
            await _student.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _student.GetByIdAsync(id);
            if (student == null)
            {
                return false;
            }

            try
            {
                _fileUpload.DeleteImage(student.ImagePath);
                _student.Remove(student);
                await _student.SaveChangesAsync();
                return true;
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                // Most likely cause: this teacher still coordinates one or more
                // courses (see the Restrict delete behaviour on Course.Coordinator).
                throw new InvalidOperationException(
                    "This student can't be deleted while they are still assigned as a coordinator on one or more programmes. " +
                    "Reassign or delete those programmes first.", ex);
            }
        }

        public async Task<bool> UpdateAsync(StudentViewModel model)
        {
            var st = await _student.GetByIdAsync(model.Id);

            if (st == null)
            {
                return false;
            }
            st.Name = model.Name;
            st.Role = model.Role;

            if (model.Image != null)
            {
                var newPath = await _fileUpload.SaveImageAsync(model.Image, "students");
                _fileUpload.DeleteImage(st.ImagePath);
                st.ImagePath = newPath;
            }

            _student.Update(st);
            await _student.SaveChangesAsync();
            return true;
        }

        async Task<List<Student>> IStudentService.GetAllAsync() => await _student.GetAllAsync();
       

        Task<Student?> IStudentService.GetByIdAsync(int id)=> _student.GetByIdAsync(id);
      

        async Task<StudentViewModel?> IStudentService.GetForEditAsync(int id)
        {
            var student = await _student.GetByIdAsync(id);
            if (student == null)
            {
                return null;
            }

            return new StudentViewModel
            {
                Name = student.Name,
                Role = student.Role,
                ExistingImagePath = student.ImagePath,
            };

        }
    }
}
