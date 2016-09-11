using MyWebSite.Models;
using MyWebSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace MyWebSite.Service
{
    public class SprintService
    {
        private SprintRepository _sprintRepository = new SprintRepository();

        /// <summary>
        /// Get All Sprints
        /// </summary>
        /// <returns></returns>
        public IList<Sprint> GetAllSprints()
        {
            int pageNumber = 1;
            int pageSize = 3;
            var query= _sprintRepository.GetAllSprints();
            return query.OrderBy(it => it.SprintIDNum).ToPagedList(pageNumber, pageSize).ToList();
               
        }

        public void CreateSprint()
        {
            Sprint sprint = new Sprint();
            sprint.Id = Guid.NewGuid().ToString();
            sprint.SprintIDNum = "666";
            sprint.StartTime = DateTime.Now;
            _sprintRepository.CreateSprint(sprint);
        }

        public void UpdateSprint()
        {
            var sprint = _sprintRepository.GetSprintBySprintId("c26e4434-a10f-4111-bee1-9e07b6a52ddb");
            sprint.ModifyTime = DateTime.Now;
            _sprintRepository.UpdateSprint(sprint);
        }

        public void DeleteSprint(string sprintId)
        {

            //_sprintRepository.DeleteSprint("a");
        }
    }
}
