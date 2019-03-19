using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tirdea_Denis_Alexandru_3133A
{
    class Client
    {
        private string firstName;
        private string lastName;
        private string CNP;
        private DateTime birthDay;
        private string gender;
        SQLMenuOracle form = new SQLMenuOracle();

        public Client(string firstName, string lastName, string CNP, DateTime birthDay, string gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.CNP = CNP;
            this.birthDay = birthDay;
            this.gender = gender;

            AddClient();
        }

        public String AddClient()
        {
            return $"INSERT INTO client (client_id, first_name, last_name, cnp, birth_day, gender) VALUES('{form.ClientRows()-1}','{firstName}' ,'{lastName}','{CNP}',to_date('{birthDay}', 'MM/DD/YYYY HH:MI:SS AM'),'{gender}')";
        }

        public String UpdateClient()
        {
            return $"UPDATE client SET first_name ='{firstName}', last_name = '{lastName}', CNP ='{CNP}',birth_day = to_date('{birthDay}', 'MM/DD/YYYY HH:MI:SS AM'), gender ='{gender}' where cnp = '{CNP}'";
        }

        public String DeleteClient()
        {
            return $"DELETE FROM client where cnp = '{CNP}'";
        }

        public string DeleteClientProperty()
        {
            return $"UPDATE property_info SET prop_owner ='' where prop_owner = '{CNP}'";
        }

        public string DeletePropertyStatus(string Property)
        {
            return $"UPDATE p_status SET rented_by_client ='', cntr_signed='', cntr_expire='',status_rent='Avaible' where status_id = '{Property}'";
        }
    }
}
