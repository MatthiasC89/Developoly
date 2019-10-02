using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Developoly.Client.Entities
{
    public class DevToProject
    {
        private List<Dev> _devs;
        private Project _project;

        public Project Project { get => _project; set => _project = value; }
        public List<Dev> Devs { get => _devs; set => _devs = value; }

        public DevToProject(Project project, List<Dev> devs)
        {
            Project = project;
            Devs = devs;
        }
    }
}
