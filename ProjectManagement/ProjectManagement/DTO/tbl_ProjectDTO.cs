using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DTO
{
    class tbl_ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PartnerId { get; set; }
        public string Status { get; set; }
        public float AdvancePayment { get; set; }
        public float Cost { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? EndTime { get; set; }

        public tbl_ProjectDTO()
        {
        }

        public tbl_ProjectDTO(int id, string name, string description, int partnerId, string status, float advangePayment, float cost, DateTime beginTime, DateTime deadline, DateTime endTime)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.PartnerId = partnerId;
            this.Status = status;
            this.AdvancePayment = advangePayment;
            this.Cost = cost;
            this.BeginTime = beginTime;
            this.Deadline = deadline;
            this.EndTime = endTime;
        }
    }
}
