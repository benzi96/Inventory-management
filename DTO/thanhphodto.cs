using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    
        public class thanhphodto
        {
            private string table = "THANHPHO";
            private string mathanhpho;
            private string tenthanhpho;
           

            public string Table
            {
                get { return table; }
                set { table = value; }
            }


            public string Tenthanhpho
            {
                get { return tenthanhpho; }
                set { tenthanhpho = value; }
            }

            public string Mathanhpho
            {
                get { return mathanhpho; }
                set { mathanhpho = value; }
            }

           
        }
    
}
