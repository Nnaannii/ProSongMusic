using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebAppEnitity.Models;

namespace WebAppEnitity.Controllers.System
{
    public class LoginController : Controller
    {
        ///AndroidApkEntities dbContext = new AndroidApkEntities();
        SongsDbEntities1 songDb = new SongsDbEntities1();
        List<Gene> geneslist = new List<Gene>();    

        // GET: Login
        public ActionResult Index()
        {
            try
            {


                geneslist.Clear();
                geneslist = songDb.Gene.OrderBy(a => a.Description).ToList();

            } catch {

            }
            ViewBag.Gene = geneslist;
            return View();
        }
        public JsonResult userList()
        {
            List<Song> songs = new List<Song>();

            songs = (from p in songDb.Song  select p ).ToList(); 
            return Json(new { data = songs }, JsonRequestBehavior.AllowGet);  



        }
        [HttpGet]
        public JsonResult getSonbyId(int songId)
        {
            //Use Stored Procedure is more ease change only in the DatabaSe 
            List<sp_song_select_Result> songs = new List<sp_song_select_Result>();
            
            
            //Use linq 

            /*List<Song> songslinq = new List<Song>();
            songslinq = (from p in songDb.Song select p).ToList();
            */
            songs = songDb.sp_song_select("ONE", songId, "", "","","").ToList();
            return Json(new { data = songs }, JsonRequestBehavior.AllowGet);



        }
        [HttpGet]
        public JsonResult DeleteSonbyId(int songId)
        {
            //Use Stored Procedure is more ease change only in the DatabaSe 
            

            //Use linq 

            /*List<Song> songslinq = new List<Song>();
            songslinq = (from p in songDb.Song select p).ToList();
            */
            var songs = songDb.sp_song_save("DELETE", songId, "", "", "", "");
            return Json(new { data = songs }, JsonRequestBehavior.AllowGet);



        }
        


        [HttpPost]
        public ActionResult UpdateUser(string name, string group, int? id, string year,string gene)
        {
            if(id !=null)
            {
                //0 Means add new Song
                
                    if (name != null && name != string.Empty)
                    {
                        try {
                            // process could be received from FontEnd, in this case i will put into backEnd
                            string process = "EDIT";
                            if (id < 1)
                            {
                                process = "SAVE";
                            }
                            
                                //Save as Stored Procedure
                                var dataReturn= songDb.sp_song_save(process, id,name,group,year,gene);

                                //Or Change it to Linq
                            
                            geneslist.Clear();
                            geneslist = songDb.Gene.OrderBy(a => a.Description).ToList();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    
                    }
            }

            ViewBag.Gene = geneslist;
            return View("Index");


        }


	}
}