using Schoolwebsite.Models;
using Schoolwebsite.Repository;
using Schoolwebsite.ViewModels.Admin;

namespace Schoolwebsite.Services
{


    public interface IEventService
    {
        Task<List<SchoolEvent>> GetAllAsync();
        Task<SchoolEvent?> GetByIdAsync(int id);
        Task<EventViewModel?> GetForEditAsync(int id);
        Task CreateAsync(EventViewModel model);

        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(EventViewModel model);
    }
    public class EventService : IEventService
    {

        private readonly IEventRepository _events;
        private readonly IFileUploadService _fileUpload;


        public EventService(IEventRepository events, IFileUploadService fileUpload)
        {
            _events = events;
            _fileUpload = fileUpload;
        }

        public async Task CreateAsync(EventViewModel model)
        {
           if(model.Image == null)
            {
                throw new ArgumentException("Please choose an image for the event.");
            }
            var imagePath = await _fileUpload.SaveImageAsync(model.Image, "event");
            var ev = new SchoolEvent
            {
                Title = model.Title,
                Date = model.Date,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Location = model.Location,
                Summary = model.Summary,
                Body = model.Body,
                ImagePath = imagePath,
            };

            await _events.AddAsync(ev);
            await _events.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var ev = await _events.GetByIdAsync(id);

            if(ev == null)
            {
                return false;
            }
            _fileUpload.DeleteImage(ev.ImagePath);
            _events.Remove(ev);
            await _events.SaveChangesAsync();
            return true;

           
        }

        public Task<List<SchoolEvent>> GetAllAsync()=> _events.GetAllAsync();
     

        public Task<SchoolEvent?> GetByIdAsync(int id)=> _events.GetByIdAsync(id);
     

        public async Task<EventViewModel?> GetForEditAsync(int id)
        {

            var ev = await _events.GetByIdAsync(id);
            if(ev == null)
            {
                return null;
            }
            return new EventViewModel
            {
                Id = ev.SchoolEventId,
                Title = ev.Title,
                Date = ev.Date,
                StartTime = ev.StartTime,
                EndTime = ev.EndTime,
                Location = ev.Location,
                Summary = ev.Summary,
                Body = ev.Body,
                ExistingImagePath = ev.ImagePath

            };
           
        }

        public async Task<bool> UpdateAsync(EventViewModel model)
        {
          var ev= await _events.GetByIdAsync(model.Id);

            if(ev == null)
            {
                return false;
            }
            ev.Title = model.Title;
            ev.Date = model.Date;
            ev.StartTime = model.StartTime;
            ev.EndTime = model.EndTime;
            ev.Location = model.Location;
            ev.Summary = model.Summary;
            ev.Body = model.Body;

            if(model.Image != null)
            {
                var newPath = await _fileUpload.SaveImageAsync(model.Image, "event");
                _fileUpload.DeleteImage(ev.ImagePath);
                ev.ImagePath = newPath;
            }
            _events.Update(ev);
            await _events.SaveChangesAsync();
            return true;


        }
    }
}
