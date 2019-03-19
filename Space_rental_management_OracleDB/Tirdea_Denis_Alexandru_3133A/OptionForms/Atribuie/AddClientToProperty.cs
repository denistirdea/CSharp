using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tirdea_Denis_Alexandru_3133A
{
    class AddClientToProperty
    {
        private string lastName;
        private string CNP;
        private string propertyID;
        private DateTime contractSigned;
        private DateTime contractExpire;

        public AddClientToProperty(string lastName, string CNP, string propertyID, DateTime contractSigned, DateTime contractExpire)
        {
            this.lastName = lastName;
            this.CNP = CNP;
            this.propertyID = propertyID;
            this.contractSigned = contractSigned;
            this.contractExpire = contractExpire;
        }

        public String PropertyOwner()
        {
            return $"update property_info set prop_owner= '{CNP}' where prop_id = '{propertyID}'"; 
        }

        public String PropertyStatus()
        {
            return $"update p_status set rented_by_client = '{lastName}', cntr_signed = to_date('{contractSigned}', 'MM/DD/YYYY HH:MI:SS AM'), cntr_expire = to_date('{contractExpire}', 'MM/DD/YYYY HH:MI:SS AM'), status_rent = 'BUSY' where status_id = {propertyID}";
        }


    }
}
