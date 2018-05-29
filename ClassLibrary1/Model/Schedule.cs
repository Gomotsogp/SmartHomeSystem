using SmartHomeSystem.DAL.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Schedule
    {
        private int id;
        private DateTime startDate;
        private string time;
        private TechnicalSupport technical;
        private Calls calls;

        public Calls Calls { get => calls; set => calls = value; }
        public TechnicalSupport Technical { get => technical; set => technical = value; }
        public string Time { get => time; set => time = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public int Id { get => id; set => id = value; }

        private bool IsSuccess = false;
        public Schedule()
        {
                
        }

        public Schedule(int id, DateTime date, string time, Calls call,TechnicalSupport tech)
        {
            this.id = id;
            this.startDate = date;
            this.time = time;
            this.calls = call;
            this.technical = tech;
        }

        public List<Schedule> GetSchedules()
        {
            DataHandler dataHandler = new DataHandler();
            return dataHandler.GetSchedules();
        }
        public bool Insert(DateTime date, string time, int callId, int techId)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.CreateNewSchedule(date,time, callId, techId);

            return IsSuccess;
        }

        public bool Update(int id, DateTime date, string time, int techId)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.UpdateSchedule(id, date,time,techId);

            return IsSuccess;
        }

        public bool Delete(int id)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.DeleteSchedule(id);

            return IsSuccess;
        }
    }
}
