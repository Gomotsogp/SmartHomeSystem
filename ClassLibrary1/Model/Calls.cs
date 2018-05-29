using SmartHomeSystem.DAL.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Calls
    {
        private int id;
        private Client client;
        private string description;
        private string duration;
        public int Id { get => id; set => id = value; }
        public Client Client { get => client; set => client = value; }
        public string Description { get => description; set => description = value; }
        public string Duration { get => duration; set => duration = value; }

        private bool IsSuccess = false;
        public Calls()
        {

        }

        public Calls(int id, string duration, string reason, Client client)
        {
            this.id = id;
            this.duration = duration;
            this.description = reason;
            this.client = client;

        }

        public List<Calls> GetCalls()
        {
            DataHandler dataHandler = new DataHandler();
            return dataHandler.GetCalls();
        }
        public bool Insert(int client,string duration, string reason)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.CreateNewCall(client,duration, reason);

            return IsSuccess;
        }

        public bool Update(string reason, int id)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.UpdateCall(id,reason);

            return IsSuccess;
        }

        public bool Delete(int id)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.DeleteCall(id);

            return IsSuccess;
        }
    }
}
