using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace RAPP_CD_CSR.Models
{
    public class Project: DbContext
    {
        public Project(DbContextOptions<Project> options) : base (options)
        {
        }

        //public DbSet<Insert_Project> Insert_Project {
        //    get; set;
        //}

        public DbSet<Select_Category_Sub> Select_Category_Sub {
            get; set;
        }

        public DbSet<Select_Category> Select_Category {
            get; set;
        }

        public DbSet<Select_Estate> Select_Estate {
            get; set;
        }

        public DbSet<Select_Kabupaten> Select_Kabupaten {
            get; set;
        }

        public DbSet<Select_Kecamatan> Select_Kecamatan {
            get; set;
        }

        public DbSet<Select_Desa> Select_Desa {
            get; set;
        }

        public DbSet<Select_CDO_CSRO> Select_CDO_CSRO {
            get; set;
        }

        public DbSet<Select_Distance> Select_Distance {
            get; set;
        }

        public DbSet<Select_CD_CSR_Select_Header> Select_Project_Header {
            get; set;
        }
    }



    public class Select_CD_CSR_Select_Header
    {
        [Key]
        public string No_Project_CD_CSR {
            get; set;
        }
        public string No_Project {
            get; set;
        }
        public string Proyek {
            get; set;
        }
        public string Proyek_Sub {
            get; set;
        }
        public string Project_Name {
            get; set;
        }
        public string BG_BU {
            get; set;
        }
        public string Estate_Name {
            get; set;
        }
        public string Provinsi {
            get; set;
        }
        public string Kabupaten {
            get; set;
        }
        public string Kecamatan {
            get; set;
        }
        public string Nama_Desa {
            get; set;
        }
        public string Distance {
            get; set;
        }
        public string CDO_CSRO_Nama {
            get; set;
        }
        public DateTime Date_start {
            get; set;
        }
        public DateTime Date_End {
            get; set;
        }
        public DateTime Date_Insert {
            get; set;
        }
    }


    /**/
    public class Prj_Insert
    {
        public string No_Project {
            get; set;
        }
        public short ID_Proyek {
            get; set;
        }
        public short ID_Proyek_Sub {
            get; set;
        }
        public string Project_Name {
            get; set;
        }
        public byte ID_Estate {
            get; set;
        }
        public byte ID_Kabupaten {
            get; set;
        }
        public int ID_Kecamatan {
            get; set;
        }
        public int ID_Desa {
            get; set;
        }
        public short ID_CDO_CSRO {
            get; set;
        }
        public short ID_Distance {
            get; set;
        }
        public DateTime Date_Start {
            get; set;
        }
        public DateTime Date_End {
            get; set;
        }

        /* Lembar Persetujuan Proyek, LPP */
        public string a_Permasalahan {
            get; set;
        }                   //nvarchar](1024) NOT NULL,
        public string b_Tujuan_Proyek {
            get; set;
        }                   //nvarchar](1024) NOT NULL,
        public string c_Keluaran_Output {
            get; set;
        }                 //nvarchar](1024) NOT NULL,
        public string c_Keluaran_Output_Satuan {
            get; set;
        }          //nvarchar](32) NOT NULL,
        public string d_Outcome {
            get; set;
        }                         //nvarchar](4000) NOT NULL,
        public string e_Beneficiaries {
            get; set;
        }                   //nvarchar](1024) NOT NULL,
        public string f_Waktu_Durasi {
            get; set;
        }                    //nvarchar](1024) NOT NULL,
        public string g_Cara_Pelaksanaan {
            get; set;
        }                //nvarchar](1024) NOT NULL,
        public string h_Benefit_For_Beneficiaries {
            get; set;
        }       //nvarchar](1024) NOT NULL,
        public string i_Benefit_For_Company {
            get; set;
        }             //nvarchar](1024) NOT NULL,
        public string j_Sustainable_Strategy {
            get; set;
        }            //nvarchar](1024) NOT NULL,
        public string k_Kontribusi_Proverty_Elevated {
            get; set;
        }    //nvarchar](1024) NOT NULL, 


    }




    #region Category
    public class Select_Category
    {
        [Key]
        public short ID_Proyek {
            get; set;
        }

        public string Proyek {
            get; set;
        }
    }

    #endregion


    #region Category_Sub
    public class Select_Category_Sub
    {
        [Key]
        public short ID_Proyek_Sub {
            get; set;
        }

        public string Proyek_Sub {
            get; set;
        }
    }

    #endregion


    public class Select_CDO_CSRO
    {
        [Key]
        public short ID_CDO_CSRO {
            get; set;
        }

        public string CDO_CSRO_Nama {
            get; set;
        }
    }


    public class Select_Distance
    {
        [Key]
        public short ID_Distance {
            get; set;
        }

        public string Distance {
            get; set;
        }
    }


    #region Estate
    public class Estate
    {
        public short ID_Estate {
            get; set;
        }

        public string Estate_Name {
            get; set;
        }
    }
    #endregion Estate


    #region Insert_Project
    /*
    public class Insert_Project
    {
        //[ID_Project {get; set;}int] IDENTITY(1,1) NOT NULL,

        //[No_Project_CD_CSR {get; set;}nvarchar] (32) NULL,
        //[No_Project {get; set;}nvarchar] (32) NOT NULL,

        //[ID_Project_Type {get; set;}smallint] NOT NULL,
        //[ID_Project_Sub {get; set;}smallint] NOT NULL,

        //[Project_Name {get; set;}nvarchar] (512) NOT NULL,

        //[ID_BG_BU {get; set;}smallint] NOT NULL,
        //[ID_Estate {get; set;}tinyint] NOT NULL,
        //[ID_Province {get; set;}tinyint] NOT NULL,
        //[ID_City {get; set;}tinyint] NOT NULL,
        //[ID_District {get; set;}smallint] NOT NULL,
        //[ID_Village {get; set;}smallint] NOT NULL,
        //[ID_Distance_Km {get; set;}smallint] NOT NULL,
        //[ID_CDO_CSRO {get; set;}smallint] NOT NULL,

        //[Date_start {get; set;}smalldatetime] NOT NULL,
        //[Date_End {get; set;}smalldatetime] NOT NULL,
        //[Date_Insert {get; set;}smalldatetime] NOT NULL,
        //[Year_ {get; set;}int] NOT NULL,

        [Key]
        public int ID_Project {
            get;set;
        }

        public string No_Project_CD_CSR {
            get;set;
        }

        public string No_Project {
            get; set;
        }

        //[ForeignKey]
        public short ID_Project_Type {
            get;set;
        }

        //[ForeignKey]
        public short ID_Project_Sub {
            get; set;
        }

        public string Project_Name {
            get; set;
        }

        //[ForeignKey]
        [NotMapped]
        public short ID_BG_BU {
            get; set;
        }

        //[ForeignKey]
        public byte ID_Estate {
            get; set;
        }
        //[ForeignKey]
        public byte ID_Province {
            get; set;
        }
        //[ForeignKey]
        public byte ID_City {
            get; set;
        }
        //[ForeignKey]
        public short ID_District {
            get; set;
        }

        //[ForeignKey]
        public short ID_Village {
            get; set;
        }

        //[ForeignKey]
        public short ID_Distance_Km {
            get; set;
        }

        //[ForeignKey]
        public short ID_CDO_CSRO {
            get; set;
        }

        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_start {
            get; set;
        }

        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_End {
            get; set;
        }

        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [NotMapped]
        public DateTime Date_Insert {
            get; set;
        }

        [NotMapped]
        public int Year_ {
            get; set;
        }

    }
    */

    public class Insert_Project
    {
        public string No_Project {
            get; set;
        }

        public short ID_Proyek {
            get; set;
        }

        public short ID_Proyek_Sub {
            get; set;
        }

        public string Project_Name {
            get; set;
        }

        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_Start {
            get; set;
        }

        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_End {
            get; set;
        }

        public byte ID_Estate {
            get; set;
        }

        public byte ID_Kabupaten {
            get; set;
        }

        public short ID_Kecamatan {
            get; set;
        }

        public short ID_Desa {
            get; set;
        }

        public short ID_CDO_CSRO {
            get; set;
        }

        public short ID_Distance {
            get; set;
        }

    }
    #endregion 
}
