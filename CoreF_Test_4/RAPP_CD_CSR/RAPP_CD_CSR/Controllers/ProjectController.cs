using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RAPP_CD_CSR.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RAPP_CD_CSR.Controllers
{
    public class ProjectController : Controller
    {

        private readonly Project _project;

        public ProjectController(Project project/*, Location location*/)
        {
            _project = project;
            //_location = location;
        }

        private void InitForm()
        {
            //Category - Project
            List<Select_Category> lst_Category = _project.Select_Category.FromSql ("[dbo].[Select_Category]").ToList ( );
            lst_Category.Insert (0, new Select_Category { ID_Proyek = 0, Proyek = "- Pilih Categori -" });

            //Estate
            List<Select_Estate> lst_Estate = _project.Select_Estate.FromSql ("[dbo].[Select_Estate]").ToList ( );
            lst_Estate.Insert (0, new Select_Estate { Id_Estate = 0, Estate_Name = "- Pilih Estate -" });

            //Kabupaten
            List<Select_Kabupaten> lst_Kabupaten = _project.Select_Kabupaten.FromSql ("[dbo].[Select_Kabupaten]").ToList ( );
            lst_Kabupaten.Insert (0, new Select_Kabupaten { ID_Kabupaten = 0, Kabupaten = "- Pilih Kabupaten -" });

            //CDO_CSRO
            List<Select_CDO_CSRO> lst_CDO_CSRO = _project.Select_CDO_CSRO.FromSql ("[dbo].[Select_CDO_CSRO]").ToList ( );
            lst_CDO_CSRO.Insert (0, new Select_CDO_CSRO { ID_CDO_CSRO = 0, CDO_CSRO_Nama = "- Pilih CDO/CSRO -" });

            //Distance
            List<Select_Distance> lst_Distance = _project.Select_Distance.FromSql ("[dbo].[Select_Distance]").ToList ( );
            lst_Distance.Insert (0, new Select_Distance { ID_Distance = 0, Distance = "- Pilih Jarak -" });


            ViewBag.Category = lst_Category;
            ViewBag.Estate = lst_Estate;
            ViewBag.Kabupaten = lst_Kabupaten;
            ViewBag.CDO_CSRO = lst_CDO_CSRO;
            ViewBag.Distance = lst_Distance;
            ViewBag.No_Project_CD_CSR = "Project Code";

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData ["Messsage"] = "Project";
            InitForm ( );
            return View();
        }

        public JsonResult GetSubCategory(int ID_Proyek)
        {
            var Id_Category = new SqlParameter ("@Id_Category", ID_Proyek);

            List<Select_Category_Sub> lst_Sub_Category = new List<Select_Category_Sub> ( );
            lst_Sub_Category = _project.Select_Category_Sub.FromSql
                                ("EXECUTE [dbo].[Select_Category_Sub] @Id_Category", Id_Category).ToList ( );

            lst_Sub_Category.Insert (0, new Select_Category_Sub { ID_Proyek_Sub = 0, Proyek_Sub = "- Pilih Sub Categori -" });
            return Json (new SelectList (lst_Sub_Category, "ID_Proyek_Sub", "Proyek_Sub"));
        }

        public JsonResult Get_Kecamatan(short ID_Kabupaten)
        {
            var Id_Kabupaten = new SqlParameter ("@Id_Kabupaten", ID_Kabupaten);
            List<Select_Kecamatan> lst_Kecamatan = new List<Select_Kecamatan> ( );
            lst_Kecamatan = _project.Select_Kecamatan.FromSql
                                ("EXECUTE [dbo].[Select_Kecamatan] @Id_Kabupaten", Id_Kabupaten).ToList ( );

            lst_Kecamatan.Insert (0, new Select_Kecamatan { ID_Kecamatan = 0, Kecamatan = "- Pilih Kecamatan -" });
            return Json (new SelectList (lst_Kecamatan, "ID_Kecamatan", "Kecamatan"));
        }

        public JsonResult Get_Desa(int ID_Kecamatan)
        {
            var Id_Kecamatan = new SqlParameter ("@Id_Kecamatan", ID_Kecamatan);
            List<Select_Desa> lst_Desa = new List<Select_Desa> ( );
            lst_Desa = _project.Select_Desa.FromSql ("EXECUTE [dbo].[Select_Desa] @Id_Kecamatan", Id_Kecamatan).ToList ( );

            lst_Desa.Insert (0, new Select_Desa { ID_Desa = 0, Nama_Desa = "- Pilih Desa -" });
            return Json (new SelectList (lst_Desa, "ID_Desa", "Nama_Desa"));
        }

        [HttpPost]
        public IActionResult Index(Prj_Insert insert_Project)
        {
            if (insert_Project.ID_Proyek == 0) {
                ModelState.AddModelError ("", "Select Category");
            }

            if (insert_Project.ID_Proyek_Sub == 0) {
                ModelState.AddModelError ("", "Select Sub Project");
            }

            if (insert_Project.ID_Kecamatan == 0) {
                ModelState.AddModelError ("", "Select Kecamatan");
            }

            if (insert_Project.ID_Kabupaten == 0) {
                ModelState.AddModelError ("", "Select Kabupaten");
            }

            if (insert_Project.ID_Estate == 0) {
                ModelState.AddModelError ("", "Select Estate");
            }

            if (insert_Project.ID_Distance == 0) {
                ModelState.AddModelError ("", "Select Distance");
            }

            if (insert_Project.ID_Desa == 0) {
                ModelState.AddModelError ("", "Select Desa");
            }

            if (insert_Project.ID_CDO_CSRO == 0) {
                ModelState.AddModelError ("", "Select Persin incharge, CDO/CSRO");
            }

            if (ModelState.IsValid) {

                var Output_Param = new SqlParameter ( ) {
                    ParameterName = "@No_Project_CD_CSR"
                                                        , SqlDbType = System.Data.SqlDbType.NVarChar
                                                        , Size = 32
                                                        , Direction = System.Data.ParameterDirection.Output
                };

                var No_Project = new SqlParameter ("@No_Project", insert_Project.No_Project);

                var ID_Project_Type = new SqlParameter ("@ID_Project_Type", insert_Project.ID_Proyek);
                var ID_Project_Sub = new SqlParameter ("@ID_Project_Sub", insert_Project.ID_Proyek_Sub);

                var Project_Name = new SqlParameter ("@Project_Name", insert_Project.Project_Name);

                var ID_Estate = new SqlParameter ("@ID_Estate", insert_Project.ID_Estate);
                var ID_City = new SqlParameter ("@ID_City", insert_Project.ID_Kabupaten);
                var ID_District = new SqlParameter ("@ID_District", insert_Project.ID_Kecamatan);
                var ID_Village = new SqlParameter ("@ID_Village", insert_Project.ID_Desa);
                var ID_Distance_Km = new SqlParameter ("@ID_Distance_Km", insert_Project.ID_Distance);
                var ID_CDO_CSRO = new SqlParameter ("@ID_CDO_CSRO", insert_Project.ID_CDO_CSRO);

                var Date_start = new SqlParameter ("@Date_start", insert_Project.Date_Start);
                var Date_End = new SqlParameter ("@Date_End", insert_Project.Date_End);

                var a_Permasalahan = new SqlParameter ("@a_Permasalahan", insert_Project.a_Permasalahan);
                var b_Tujuan_Proyek = new SqlParameter ("@b_Tujuan_Proyek", insert_Project.b_Tujuan_Proyek);
                var c_Keluaran_Output = new SqlParameter ("@c_Keluaran_Output", insert_Project.c_Keluaran_Output);
                var c_Keluaran_Output_Satuan = new SqlParameter ("@c_Keluaran_Output_Satuan", insert_Project.c_Keluaran_Output_Satuan);
                var d_Outcome = new SqlParameter ("@d_Outcome", insert_Project.d_Outcome);
                var e_Beneficiaries = new SqlParameter ("@e_Beneficiaries", insert_Project.e_Beneficiaries);
                var f_Waktu_Durasi = new SqlParameter ("@f_Waktu_Durasi", insert_Project.f_Waktu_Durasi);
                var g_Cara_Pelaksanaan = new SqlParameter ("@g_Cara_Pelaksanaan", insert_Project.g_Cara_Pelaksanaan);
                var h_Benefit_For_Beneficiaries = new SqlParameter ("@h_Benefit_For_Beneficiaries", insert_Project.h_Benefit_For_Beneficiaries);
                var i_Benefit_For_Company = new SqlParameter ("@i_Benefit_For_Company", insert_Project.i_Benefit_For_Company);
                var j_Sustainable_Strategy = new SqlParameter ("@j_Sustainable_Strategy", insert_Project.j_Sustainable_Strategy);
                var k_Kontribusi_Proverty_Elevated = new SqlParameter ("@k_Kontribusi_Proverty_Elevated", insert_Project.k_Kontribusi_Proverty_Elevated);

                var _Insert = _project.Database.ExecuteSqlCommand ("EXECUTE [Project].[Prj_CD_CSR_Insert] @No_Project, @ID_Project_Type, @ID_Project_Sub, @Project_Name, @ID_Estate, @ID_City, @ID_District, @ID_Village, @ID_Distance_Km, @ID_CDO_CSRO, @Date_start, @Date_End,  @No_Project_CD_CSR OUT, " +
                                                                                                            "@a_Permasalahan, @b_Tujuan_Proyek, @c_Keluaran_Output, @c_Keluaran_Output_Satuan, @d_Outcome, @e_Beneficiaries, @f_Waktu_Durasi, @g_Cara_Pelaksanaan, @h_Benefit_For_Beneficiaries, @i_Benefit_For_Company, @j_Sustainable_Strategy, @k_Kontribusi_Proverty_Elevated",
                                                                    No_Project
                                                                    , ID_Project_Type
                                                                    , ID_Project_Sub
                                                                    , Project_Name
                                                                    , ID_Estate
                                                                    , ID_City
                                                                    , ID_District
                                                                    , ID_Village
                                                                    , ID_Distance_Km
                                                                    , ID_CDO_CSRO
                                                                    , Date_start
                                                                    , Date_End

                                                                    , a_Permasalahan
                                                                    , b_Tujuan_Proyek
                                                                    , c_Keluaran_Output
                                                                    , c_Keluaran_Output_Satuan
                                                                    , d_Outcome
                                                                    , e_Beneficiaries
                                                                    , f_Waktu_Durasi
                                                                    , g_Cara_Pelaksanaan
                                                                    , h_Benefit_For_Beneficiaries
                                                                    , i_Benefit_For_Company
                                                                    , j_Sustainable_Strategy
                                                                    , k_Kontribusi_Proverty_Elevated

                                                                    , Output_Param);

                InitForm ( );
                ViewBag.No_Project_CD_CSR = Output_Param.SqlValue;

                var Project_Code_CD_CSR = new SqlParameter ("@No_Project_CD_CSR", Output_Param.SqlValue);
                List<Select_CD_CSR_Select_Header> lst_CD_CSR_Header = new List<Select_CD_CSR_Select_Header> ( );
                lst_CD_CSR_Header = _project.Select_Project_Header.FromSql ("EXECUTE [Project].[Prj_CD_CSR_Select_Header] @No_Project_CD_CSR", Project_Code_CD_CSR).ToList ( );

                ViewBag.No_Project_CD_CSR = lst_CD_CSR_Header [0].No_Project_CD_CSR;
                ViewBag.Header_No_Project = lst_CD_CSR_Header [0].No_Project;
                ViewBag.Header_Project_Name = lst_CD_CSR_Header [0].Project_Name;
                ViewBag.Header_Main_Project = lst_CD_CSR_Header [0].Proyek;
                ViewBag.Header_Sub_Peoject = lst_CD_CSR_Header [0].Proyek_Sub;
                ViewBag.Header_BG_BU = lst_CD_CSR_Header [0].BG_BU;
                ViewBag.Header_Estate = lst_CD_CSR_Header [0].Estate_Name;
                ViewBag.Header_Province = lst_CD_CSR_Header [0].Provinsi;
                ViewBag.Header_Kabupaten = lst_CD_CSR_Header [0].Kabupaten;
                ViewBag.Header_Kecamatan = lst_CD_CSR_Header [0].Kecamatan;
                ViewBag.Header_Desa = lst_CD_CSR_Header [0].Nama_Desa;
                ViewBag.Header_Distance = lst_CD_CSR_Header [0].Distance;
                ViewBag.Header_CDO_CSRO = lst_CD_CSR_Header [0].CDO_CSRO_Nama;
                ViewBag.Header_Date_Start = lst_CD_CSR_Header [0].Date_start;
                ViewBag.Header_Date_End = lst_CD_CSR_Header [0].Date_End;

                return View (insert_Project);

            }

            return View ( );

        }

    }
}
