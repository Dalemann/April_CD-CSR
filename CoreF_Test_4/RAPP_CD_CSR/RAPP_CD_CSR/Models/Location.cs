using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RAPP_CD_CSR.Models
{
    //public class Location
    //{
    //}

    #region Estate
    public class Select_Estate
    {
        [Key]
        public byte Id_Estate {
            get; set;
        }

        public string Estate_Name {
            get; set;
        }
    }
    #endregion


    #region Kabupaten
    public class Select_Kabupaten
    {
        [Key]
        public byte ID_Kabupaten {
            get; set;
        }

        public string Kabupaten {
            get; set;
        }
    }
    #endregion


    #region Kecamatan
    public class Select_Kecamatan
    {
        [Key]
        public short ID_Kecamatan {
            get; set;
        }

        public string Kecamatan {
            get; set;
        }
    }
    #endregion


    #region Desa
    public class Select_Desa
    {
        [Key]
        public short ID_Desa {
            get; set;
        }

        public string Nama_Desa {
            get; set;
        }
    }
    #endregion
}
