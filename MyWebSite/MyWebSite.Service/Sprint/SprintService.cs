using MyWebSite.Models;
using MyWebSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _sprintRepository.GetAllSprints();
        }
    }
}
