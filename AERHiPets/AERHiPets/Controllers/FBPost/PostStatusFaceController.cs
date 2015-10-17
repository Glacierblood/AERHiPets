using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImpactWorks.FBGraph.Connector;

using ImpactWorks.FBGraph.Core;
using ImpactWorks.FBGraph.Interfaces;

namespace AERHiPets.Controllers.FBPost
{
    public class PostStatusFaceController : Controller
    {
        // GET: PostStatusFace
        public ActionResult Index()
        {
            return View();
        }

        Authentication auth = new Authentication();
        public ActionResult Success()
        {
            if (Request.QueryString["code"] != null)
            {
                string Code = Request.QueryString["code"];
                Session["facebookQueryStringValue"] = Code;
            }
            if (Session["facebookQueryStringValue"] != null)
            {
                ImpactWorks.FBGraph.Connector.Facebook facebook = auth.FacebookAuth();
                facebook.GetAccessToken(Session["facebookQueryStringValue"].ToString());
                FBUser currentUser = facebook.GetLoggedInUserInfo();
                IFeedPost FBpost = new FeedPost();
                if (Session["postStatusFace"].ToString() != "")
                {
                    FBpost.Message = Session["postStatusFace"].ToString();
                    facebook.PostToWall(currentUser.id.GetValueOrDefault(), FBpost);
                }

            }
            return View();
        }

        public JsonResult PostStatus(string msg)
        {
            Session["postStatusFace"] = msg;


            ImpactWorks.FBGraph.Connector.Facebook facebook = auth.FacebookAuth();
            if (Session["facebookQueryStringValue"] == null)
            {
                string authLink = facebook.GetAuthorizationLink();
                return Json(authLink);
            }

            if (Session["facebookQueryStringValue"] != null)
            {
                facebook.GetAccessToken(Session["facebookQueryStringValue"].ToString());
                FBUser currentUser = facebook.GetLoggedInUserInfo();
                IFeedPost FBpost = new FeedPost();
                if (Session["postStatusFace"].ToString() != "")
                {
                    FBpost.Message = Session["postStatusFace"].ToString();
                    facebook.PostToWall(currentUser.id.GetValueOrDefault(), FBpost);
                }
            }
            return Json("No");
        }

    }
}