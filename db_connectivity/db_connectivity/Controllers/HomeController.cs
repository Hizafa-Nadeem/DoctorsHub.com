using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db_connectivity.Models;
namespace db_connectivity.Controllers
{
    //doctor patient redirections//redirected without logout//reminders//medicine reminder on front end
     //medicine reminder//jobs//2 procedures boked availaible//repeat password//messages is doc
    //PATIENT SIDE MSGS

    //see more//mails//inbox//styling//return from inbox
     public class HomeController : Controller
    {
        //
        // GET: /Home/

        //public ActionResult Index()
        //{
        //    return View("Index");
        //}
        public ActionResult Index()
        {
            if (Session["uid"] == null)
            {
                return View();
            }
            else
            {
                //String doc = TempData["mydoc3"] as String;
                String doc = Session["mydoc"].ToString();
                if (doc == "doctor")
                {
                    return RedirectToAction("Index3");
                }
                else
                {
                    return RedirectToAction("Index4");
                }
            }
        }
        public ActionResult Edit()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }
        public ActionResult Editp()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Editp");
            }
        }
        public ActionResult Switch()
        {
                return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Session.Remove("uid");
                Session.Remove("mydoc");
                return RedirectToAction("Index");
            }
        }
        public ActionResult searchchat(String id)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                String doc = Session["mydoc"].ToString();
                int result;
                if(doc=="doctor"){
                    result=CRUD.searchchat2(id,Session["uid"].ToString(), doc);
                }else{
                    result = CRUD.searchchat2(Session["uid"].ToString(),id, doc);
                }
                 

                //List<PHistory> users = CRUD.CheckHistory(pid);

                if (result == 0)
                {
                    String data = "Patient not found!!";
                    TempData["myerror"] = data;
                    // return View("Index3", (object)data);
                    /*return RedirectToAction("Index4", new { uid });*/
                    return RedirectToAction("Inbox");
                }
                if (result == 1)
                {
                    String data = "Doctor not found!!";
                    TempData["myerror"] = data;
                    // return View("Index3", (object)data);
                    /*return RedirectToAction("Index4", new { uid });*/
                    return RedirectToAction("Inbox");
                }
                
                
                List<message> users ;
                if (doc == "doctor")
                {
                    users = CRUD.searchchat(id, Session["uid"].ToString(), doc);
                }
                else
                {
                    users = CRUD.searchchat(Session["uid"].ToString(), id, doc);
                }
                TempData["listmsg"] = users.ToList();
                //ViewData["search"] = users;
                return RedirectToAction("inbox");
            }
        }
        public ActionResult mychat(String id4,String name4)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                String doc = Session["mydoc"].ToString();


                //List<PHistory> users = CRUD.CheckHistory(pid);

                

               
                List<chat> users;
                if (doc == "doctor")
                {
                    users = CRUD. mychat(id4, Session["uid"].ToString(), doc);
               
                }
                else
                {
                    users = CRUD.mychat(Session["uid"].ToString(), id4, doc);
                  
                }
                TempData["listchat"] = users.ToList();
                //TempData["chatid"] = id4;
                //TempData["chatname"] = name4;

                Session["cids"] = id4;
                Session["cnames"] = name4;
                //ViewData["search"] = users;
                return RedirectToAction("inbox");
            }
        }
        public ActionResult sendchat(String id5,String comment)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (id5 == null)
                {
                    return RedirectToAction("inbox");
                }
               
                String doc = Session["mydoc"].ToString();


                //List<PHistory> users = CRUD.CheckHistory(pid);
                int result;
                if (doc == "doctor")
                { 
                    result = CRUD.sendchat(id5, Session["uid"].ToString(), doc,comment);

                }
                else
                {
                    result = CRUD.sendchat( Session["uid"].ToString(),id5, doc, comment);

                }
                
                    List<chat> users7;
                    if (doc == "doctor")
                    {
                        users7 = CRUD.mychat(id5, Session["uid"].ToString(), doc);

                    }
                    else
                    {
                        users7 = CRUD.mychat(Session["uid"].ToString(), id5, doc);

                    }
                    TempData["listchat"] = users7;
                
                return RedirectToAction("inbox");
            }
        }
        public ActionResult Inbox()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                String doc = Session["mydoc"].ToString();
                List<message> users = CRUD.recentmessages(Session["uid"].ToString(),doc);
                ViewData["message"] = users;
                var users5 = TempData["listmsg"] as List<message>;
                ViewData["search"] = users5;
                var users6 = TempData["listchat"] as List<chat>;
                ViewData["chat"] = users6;

                //String id = TempData["chatid"] as String;
                //String name = TempData["chatname"] as String;

                ViewData["cid"] = Session["cids"].ToString();
                ViewData["cname"] = Session["cnames"].ToString();

                var x = Session["cids"].ToString();
                var y = Session["cnames"].ToString();
                /*if (x!="-1")
                {
                    String id1 = Session["cid1"].ToString();
                    if (id1 != null)
                    {
                        List<chat> users7;
                        if (doc == "doctor")
                        {
                            users7 = CRUD.mychat(id1, Session["uid"].ToString(), doc);

                        }
                        else
                        {
                            users7 = CRUD.mychat(Session["uid"].ToString(), id1, doc);

                        }
                        ViewData["chat1"] = users7;
                    }
                }*/
                return View("inbox");
            }
        }
        public ActionResult Return()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                /*String uid = TempData["myid"] as String;*/
                String uid = Session["uid"].ToString();
                //String doc = TempData["mydoc"] as String;
                String doc = Session["mydoc"].ToString();
           
                // Session["userId"] = userId;
                if (doc == "doctor")
                {
                    //List<doctor> users = CRUD.docProfile(uid);
                    //Console.Write(users);
                    //return View(users);

                    return RedirectToAction("Index3");
                }
                else
                {
                    return RedirectToAction("Index4");
                }
            }

        }
        public ActionResult ECon( String contact)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                /*String uid = TempData["myid"] as String;*/
                String uid = Session["uid"].ToString();
                //String doc = TempData["mydoc"] as String;
                String doc = Session["mydoc"].ToString();
                int result = CRUD.ECon(uid, contact, doc);

                if (result == 0)
                {
                    String data = "Please enter contact to update";
                    return View("Edit", (object)data);
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    return View("Edit", (object)data);
                }


                // Session["userId"] = userId;
                if (doc == "doctor")
                {
                    //List<doctor> users = CRUD.docProfile(uid);
                    //Console.Write(users);
                    //return View(users);

                    return RedirectToAction("Index3");
                }
                else
                {
                    return RedirectToAction("Index4");
                }
            }

        }
        public ActionResult EPass(String pass, String pass2,String rpass)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                /*String uid = TempData["myid"] as String;*/
                String uid = Session["uid"].ToString();
                //String doc = TempData["mydoc"] as String;
                String doc = Session["mydoc"].ToString();
                int result = CRUD.EPass(uid,doc, pass,pass2,rpass);

                if (result == 0)
                {
                    String data = "Please enter Password to update";
                    return View("Editp", (object)data);
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    return View("Editp", (object)data);
                }
                if (result == 2)
                {
                    String data = "Password does not match..Please try again!!";
                    return View("Editp", (object)data);
                }
                if (result == 3)
                {
                    String data = "You entered incorrect password..Please try again";
                    return View("Editp", (object)data);
                }

                // Session["userId"] = userId;
                if (doc == "doctor")
                {
                    //List<doctor> users = CRUD.docProfile(uid);
                    //Console.Write(users);
                    //return View(users);

                    return RedirectToAction("Index3");
                }
                else
                {
                    return RedirectToAction("Index4");
                }
            }

        }
        public ActionResult EEmail(String email)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                /* String uid = TempData["myid2"] as String;*/
                String uid = Session["uid"].ToString();
                //String doc = TempData["mydoc2"] as String;
                String doc = Session["mydoc"].ToString();
                int result = CRUD.EEmail(uid, email, doc);

                if (result == 0)
                {
                    String data = "Incorrect Email!!!! please try again!!!!";
                    return View("Edit", (object)data);
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    return View("Edit", (object)data);
                }


                // Session["userId"] = userId;
                if (doc == "doctor")
                {
                    //List<doctor> users = CRUD.docProfile(uid);
                    //Console.Write(users);
                    //return View(users);

                    return RedirectToAction("Index3");
                }
                else
                {
                    return RedirectToAction("Index4");
                }
            }
        }
        public ActionResult ERes(String res)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                /*String uid = TempData["myid3"] as String;*/
                String uid = Session["uid"].ToString();
                //String doc = TempData["mydoc3"] as String;
                String doc = Session["mydoc"].ToString();
                int result = CRUD.ERes(uid, res, doc);

                if (result == 0)
                {
                    String data = "Please enter address to update";
                    return View("Edit", (object)data);
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    return View("Edit", (object)data);
                }


                // Session["userId"] = userId;
                if (doc == "doctor")
                {
                    //List<doctor> users = CRUD.docProfile(uid);
                    //Console.Write(users);
                    //return View(users);

                    /* return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }
                else
                {
                    return RedirectToAction("Index4");
                }
            }
        }
        public ActionResult Login(String uid, String password,String doc)
        {
            if (Session["uid"] == null)
            {
                int result = CRUD.Login(uid, password, doc);

                if (result == 0)
                {
                    String data = "Incorrect ID!! Please try again...";
                    return View("Index", (object)data);
                }
                else if (result == 1)
                {

                    String data = "Incorrect Password!! Please try again...";
                    return View("Index", (object)data);
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    return View("Index", (object)data);
                }
                else if (result == 3)
                {

                    String data = "please enter whether you are doctor or patient";
                    return View("Index", (object)data);
                }
                /* TempData["myid"] = uid;*/

               // TempData["mydoc"] = doc;
                /* TempData["myid2"] = uid;*/

                //TempData["mydoc2"] = doc;
                /* TempData["myid3"] = uid;*/

                //TempData["mydoc3"] = doc;
                Session["mydoc"]=doc;
                Session["uid"] = uid;
                if (doc == "doctor")
                {
                    //List<doctor> users = CRUD.docProfile(uid);
                    //Console.Write(users);
                    //return View(users);
                    /* return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }
                else
                {
                    /* return RedirectToAction("Index4", new { uid });*/
                    return RedirectToAction("Index4");
                }
            }
            else
            {
                //String doc1 = TempData["mydoc3"] as String;
                String doc1 = Session["mydoc"].ToString();
                if (doc1 == "doctor")
                {
                    return RedirectToAction("Index3");
                }
                else
                {
                    return RedirectToAction("Index4");
                }
            }
        }
       /* public ActionResult AddAvailibility(int uid, String date, String time)*/
        public ActionResult AddAvailibility( String date, String time)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null )
            {
                return RedirectToAction("Index");
            }
            else if (doc == "patient")
            {
                return RedirectToAction("Index4");
            }
            else
            {
                int result = CRUD.AddAvailibility(Session["uid"].ToString(), date, time);

                if (result == 2)
                {
                    String data = "Date and Time cannot be Null!! Please try again...";
                    TempData["myerror"] = data;
                    /*List<doctor> users1 = CRUD.docProfile(uid);
                    ViewData["dProfile"] = users1; 
                    return View("Index3", (object)data);*/
                    /* return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }
                else if (result == 3)
                {

                    String data = "You have already entered this availibility!! Please try again...";
                    TempData["myerror"] = data;
                    /*List<doctor> users1 = CRUD.docProfile(uid);
                    ViewData["dProfile"] = users1; 
                    return View("Index3", (object)data);*/
                    /*return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    /*List<doctor> users1 = CRUD.docProfile(uid);
                    ViewData["dProfile"] = users1; 
                    return View("Index3", (object)data);*/

                    /*return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }

                /*List<doctor> users2 = CRUD.docProfile(uid);
                ViewData["dProfile"] = users2;*/
                // Session["userId"] = userId;
                //String data1 = "Availibility successfully added!!";
                //ViewData["availerror"] = data1;

                /* return RedirectToAction("Index3", new { uid });*/
                return RedirectToAction("Index3");
            }
        }
        public ActionResult DropAvailibility(String id)
        {
           // String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "patient")
            {
                return RedirectToAction("Index4");
            }
            else
            {
                int result = CRUD.DropAvailibility(Session["uid"].ToString(), id);

                if (result == 0)
                {
                    String data = "Incorrect Availibility id!! Please try again...";
                    TempData["myerror"] = data;
                    /*List<doctor> users1 = CRUD.docProfile(uid);
                    ViewData["dProfile"] = users1; 
                    return View("Index3", (object)data);*/
                    /* return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    /*List<doctor> users1 = CRUD.docProfile(uid);
                    ViewData["dProfile"] = users1; 
                    return View("Index3", (object)data);*/

                    /*return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }
                return RedirectToAction("Index3");
            }
        }
       /* public ActionResult AddSpeciality(String uid, String speciality)*/
        public ActionResult AddSpeciality( String speciality)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "patient")
            {
                return RedirectToAction("Index4");
            }
            else
            {
                int result = CRUD.AddSpeciality(Session["uid"].ToString(), speciality);

                if (result == 2)
                {

                    String data = "This Speciality already exists!! Please try again...";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    /* return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }
                else if (result == 3)
                {

                    String data = "You have not entered any speciality!! Please try again...";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    /*return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    /* return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }


                // Session["userId"] = userId;
                /* return RedirectToAction("Index3", new { uid });*/
                return RedirectToAction("Index3");
            }
        }
       /* public ActionResult CheckHistory(int uid, int pid)*/
        public ActionResult CheckHistory( String pid)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "patient")
            {
                return RedirectToAction("Index4");
            }
            else
            {
                int result = CRUD.CheckHistory1(pid);

                // List<PHistory> users=CRUD.CheckHistory(pid);

                if (result == 0)
                {
                    String data = "Patient Does not exists!! Please try again...";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    /* return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");

                }
                else if (result == 2)
                {

                    String data = "Patient has no history";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    /*return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    /* return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }

                List<PHistory> users = CRUD.CheckHistory(pid);
                /*List<doctor> users1 = CRUD.docProfile(uid);
                ViewData["dProfile"] = users1;*/
                // ViewData["PHistory"]=users;
                TempData["list"] = users.ToList();
                /*return RedirectToAction("Index3", new { uid });*/
                return RedirectToAction("Index3");
                //return View();
            }
        }
        public ActionResult CheckDoc(String pid)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.CheckDoc1(pid);

                // List<PHistory> users=CRUD.CheckHistory(pid);

                if (result == 0)
                {
                    String data = "Doctor Does not exists!! Please try again...";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }

                List<doctor> users = CRUD.CheckDoc(pid);
                //List<patient> users1 = CRUD.patProfile(uid);
                //ViewData["pProfile"] = users1;
                // ViewData["PHistory"]=users;
                TempData["list"] = users.ToList();
                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult Feedback( String aid, String rating, String desc)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.Feedback(Session["uid"].ToString(), aid, rating, desc);

                // List<PHistory> users=CRUD.CheckHistory(pid);

                if (result == 0)
                {
                    String data = "Please enter a rating from 0 to 10.Thank you!!";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                } if (result == 1)
                {

                    String data = "Sorry!!The appointment id you entered could be found";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                if (result == 2)
                {

                    String data = "You have already entered your feedback";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }


                //List<patient> users1 = CRUD.patProfile(uid);
                //ViewData["pProfile"] = users1;
                // ViewData["PHistory"]=users;

                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult MedRemin(String date, String time, String desc)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.MedRemin(Session["uid"].ToString(),date, time, desc);

                // List<PHistory> users=CRUD.CheckHistory(pid);

                if (result == 3)
                {
                    String data = "You have already entered this reminder";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }


                //List<patient> users1 = CRUD.patProfile(uid);
                //ViewData["pProfile"] = users1;
                // ViewData["PHistory"]=users;

                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult History( String aid, String desc)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.History(Session["uid"].ToString(), aid, desc);

                // List<PHistory> users=CRUD.CheckHistory(pid);

                if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                } if (result == 0)
                {

                    String data = "Sorry!!The appointment id you entered could be found";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                if (result == 4)
                {

                    String data = "You have already entered your history";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }


                //List<patient> users1 = CRUD.patProfile(uid);
                //ViewData["pProfile"] = users1;
                // ViewData["PHistory"]=users;

                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult BookApp( String aid)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.BookApp(Session["uid"].ToString(), aid);

                // List<PHistory> users=CRUD.CheckHistory(pid);

                if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                if (result == 4)
                {

                    String data = "Availibility ID not found.Please try again!!!";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                if (result == 7)
                {

                    String data = "Availibility ID already reserved!!You may add yourself in waiting list";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                if (result == 5)
                {

                    String data = "Date of availibility is passed..Try another one";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                if (result == 6)
                {

                    String data = "Time of availibility is passed..Try another one";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }

                //List<patient> users1 = CRUD.patProfile(uid);
                //ViewData["pProfile"] = users1;
                // ViewData["PHistory"]=users;

                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult ReBookApp( String aid)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.ReBookApp(Session["uid"].ToString(), aid);

                // List<PHistory> users=CRUD.CheckHistory(pid);

                if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                } if (result == 2)
                {

                    String data = "Sorry!!The appointment id you entered could not be found";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }

                if (result == 5 || result == 6)
                {

                    String data = "Sorry!!The appointment id you entered has been passed.You cannot cancel it now";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                /* List<patient> users1 = CRUD.patProfile(uid);
                 ViewData["pProfile"] = users1;*/
                // ViewData["PHistory"]=users;

                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult WList( String aid)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.WList(Session["uid"].ToString(), aid);

                // List<PHistory> users=CRUD.CheckHistory(pid);

                if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                } if (result == 2)
                {

                    String data = "Sorry!!The Availibility id you entered could be found";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                } if (result == 5)
                {

                    String data = "The Availibility id you entered is not reserved as an appointment!!You may reserve it";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                } if (result == 8)
                {

                    String data = "Your request for this Availibility id is already present in the waiting list ";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                } if (result == 7)
                {

                    String data = "You have already taken this availibility id as an appointment ";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                if (result == 5 || result == 6)
                {

                    String data = "Sorry! this appointmet has passed. Try another appointment ";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }


                //List<patient> users1 = CRUD.patProfile(uid);
                //ViewData["pProfile"] = users1;
                // ViewData["PHistory"]=users;

                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult CheckDocSpec(String pid)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.CheckDocSpec1(pid);

                // List<PHistory> users=CRUD.CheckHistory(pid);

                if (result == 0)
                {
                    String data = "No such Doctor with given Speciality exists!! Please try again...";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }

                List<doctor> users = CRUD.CheckDocSpec(pid);
                //List<patient> users1 = CRUD.patProfile(uid);
                //ViewData["pProfile"] = users1;
                // ViewData["PHistory"]=users;
                TempData["list"] = users.ToList();
                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult CheckDocHigh( String pid)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.CheckDocHigh1(pid);

                // List<PHistory> users=CRUD.CheckHistory(pid);

                if (result == 0)
                {
                    String data = "No such Doctor with given Speciality exists!! Please try again...";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    return RedirectToAction("Index4");
                }

                List<doctor> users = CRUD.CheckDocHigh(pid);
                //List<patient> users1 = CRUD.patProfile(uid);
                //ViewData["pProfile"] = users1;
                // ViewData["PHistory"]=users;
                TempData["list"] = users.ToList();
                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult DelRemin(String rid)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.DelRemin(Session["uid"].ToString(),rid);

                //List<PHistory> users = CRUD.CheckHistory(pid);

                if (result == 3)
                {
                    String data = "No such Reminder with given ID exists!! Please try again...";
                    TempData["myerror"] = data;
                    // return View("Index3", (object)data);
                    /*return RedirectToAction("Index4", new { uid });*/
                    return RedirectToAction("Index4");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    /*return RedirectToAction("Index4", new { uid });*/
                    return RedirectToAction("Index4");
                }
                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult DocAvail( String pid)
        {
            //String doc = TempData["mydoc"] as String;
            String doc = Session["mydoc"].ToString();
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
            else if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                int result = CRUD.DocAvail2(pid);

                //List<PHistory> users = CRUD.CheckHistory(pid);

                if (result == 0)
                {
                    String data = "No such Doctor with given ID exists!! Please try again...";
                    TempData["myerror"] = data;
                    // return View("Index3", (object)data);
                    /*return RedirectToAction("Index4", new { uid });*/
                    return RedirectToAction("Index4");
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    TempData["myerror"] = data;
                    //return View("Index3", (object)data);
                    /*return RedirectToAction("Index4", new { uid });*/
                    return RedirectToAction("Index4");
                }

                List<docavail> users = CRUD.DocAvail3(pid);
                //List<patient> users1 = CRUD.patProfile(uid);
                //ViewData["pProfile"] = users1;
                //ViewData["PHistory"] = users;
                TempData["list2"] = users.ToList();
                return RedirectToAction("Index4");
                //return View();
            }
        }
        public ActionResult Signup(String uname, String password, String repeatpassword, String email, String dob, String contact, String address, String gender, String doc)
        {
            if (Session["uid"] == null)
            {
                int result = CRUD.Signup(uname, password, repeatpassword, email, dob, contact, address, gender, doc);

                if (result == 0)
                {
                    String data = "Incorrect Credetials!! Please try again...";
                    return View("Index2", (object)data);
                }
                else if (result == -1)
                {

                    String data = "Sorry!!Something went wrong while connecting with database";
                    return View("Index2", (object)data);
                }


                // Session["userId"] = userId;
                /*if (doc == "doctor")
                {

                    return RedirectToAction("Index3", new { uid=result });
                }
                else
                {
                    return RedirectToAction("Index4");
                }*/
                /* TempData["myid"] = uid;*/

                //TempData["mydoc"] = doc;
                /* TempData["myid2"] = uid;*/

                //TempData["mydoc2"] = doc;
                /* TempData["myid3"] = uid;*/

                //TempData["mydoc3"] = doc;
                Session["mydoc"]=doc;
                Session["uid"] = result;
                if (doc == "doctor")
                {
                    int uid = result;
                    String data2 = "Your id is " + uid;
                    TempData["myerror"] = data2;
                    /*List<doctor> users1 = CRUD.docProfile(uid);
                    ViewData["dProfile"] = users1;*/
                    // ViewData["PHistory"]=users;
                    /*return RedirectToAction("Index3", new { uid });*/
                    return RedirectToAction("Index3");
                }
                else
                {
                    int uid = result;
                    String data2 = "Your id is " + uid;
                    TempData["myerror"] = data2;
                    /*List<patient> users1 = CRUD.patProfile(uid);
                    ViewData["pProfile"] = users1;
                    return RedirectToAction("Index4", new { uid });*/
                    return RedirectToAction("Index4");
                }

                // return RedirectToAction("Login");
            }
            else
            {
                //String doc1 = TempData["mydoc3"] as String;
                String doc1 = Session["mydoc"].ToString();
                if (doc1 == "doctor")
                {
                    return RedirectToAction("Index3");
                }
                else
                {
                    return RedirectToAction("Index4");
                }
            }
        }
       /* public ActionResult homePage(String userId)
        {
            //if (Session["userId"]==null)
            //  {
            //      return RedirectToAction("Login");
            //  }

            List<User> users = CRUD.getAllUsers();
            if (users == null)
            {
                RedirectToAction("SignUp");
            }
            Console.Write(users);
            return View(users);
        }*/
        public ActionResult Index2()
        {
            if (Session["uid"] == null)
            {
                return View();
            }
            else
            {
                //String doc = TempData["mydoc3"] as String;
                String doc = Session["mydoc"].ToString();
                if (doc == "doctor")
                {
                    return RedirectToAction("Index3");
                }
                else
                {
                    return RedirectToAction("Index4");
                }
            }
        }
       /*public ActionResult Index3(int uid)*/
        public ActionResult Index3()
        {
            //String doc = TempData["mydoc"] as String;
            if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }

            
            String doc = Session["mydoc"].ToString();
            
             if (doc == "patient")
            {
                return RedirectToAction("Index4");
            }
            else
            {
                var users = TempData["list"] as List<PHistory>;

                /*List<doctor> users2 = CRUD.docProfile(uid);
                List<string> users3 = CRUD.Speciality(uid);
                List<docappoin> users4 = CRUD.DocAppoin(uid);
                List<docavail> users5 = CRUD.DocAvail(uid);*/
                List<doctor> users2 = CRUD.docProfile(Session["uid"].ToString());
                List<string> users3 = CRUD.Speciality(Session["uid"].ToString());
                List<docappoin> users4 = CRUD.DocAppoin(Session["uid"].ToString());
                List<docavail> users5 = CRUD.DocAvail(Session["uid"].ToString());
                //Console.Write(users);
                // List<PHistory> users = CRUD.CheckHistory(pid);
                ViewData["PHistory"] = users;
                ViewData["dProfile"] = users2;
                ViewData["spec"] = users3;
                ViewData["appoin"] = users4;
                ViewData["avail"] = users5;

                String myerror = TempData["myerror"] as String;
                ViewData["myerror2"] = myerror;
                // return View(users);

                Session["cids"] = "-1";
                Session["cnames"] = "-1";
                return View("Index3");
            }
        }
        /*public ActionResult Index4(int uid)*/
         public ActionResult Index4()
        {
            //String doc = TempData["mydoc"] as String;
             if (Session["uid"] == null)
            {
                return RedirectToAction("Index");
            }
             
            String doc = Session["mydoc"].ToString();
            
             if (doc == "doctor")
            {
                return RedirectToAction("Index3");
            }
            else
            {
                /*List<patient> users2 = CRUD.patProfile(uid);*/
                List<patient> users2 = CRUD.patProfile(Session["uid"].ToString());
                ViewData["pProfile"] = users2;
                String myerror = TempData["myerror"] as String;
                ViewData["myerror2"] = myerror;
                /*List<patappoin> users3 = CRUD.patAppoin(uid);*/
                List<patappoin> users3 = CRUD.patAppoin(Session["uid"].ToString());
                ViewData["pAppoin"] = users3;
                var users = TempData["list"] as List<doctor>;
                ViewData["dHistory"] = users;
                /*List<PHistory> users4 = CRUD.CheckHistory(uid);*/
                List<PHistory> users4 = CRUD.CheckHistory(Session["uid"].ToString());
                ViewData["PHistory"] = users4;
                List<reminder> users6 = CRUD.MyRemin(Session["uid"].ToString());
                ViewData["PRem"] = users6;
                var users5 = TempData["list2"] as List<docavail>;
                ViewData["avail"] = users5;

                Session["cids"] = "-1";
                Session["cnames"] = "-1";
                return View("Index4");
            }
        }


    }
}
