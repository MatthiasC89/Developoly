using Developoly.Server.Services.Entities;
using System.Linq;


namespace Developoly.Server.Services
{
    public partial class Service
    {
        public School CreateNewSchool(string name)//is not used anymore
        {

            if (Schools == null)
            {
                School newSchool = new School(1, name);
                return newSchool;


            }
            else
            {
                School newSchool = new School(Schools.Count + 1, name);
                return newSchool;


            }





        }


        


    }
}
