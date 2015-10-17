using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ImpactWorks.FBGraph.Connector;
using ImpactWorks.FBGraph.Core;

namespace AERHiPets.Controllers.FBPost
{
    public class Authentication
    {
        public ImpactWorks.FBGraph.Connector.Facebook FacebookAuth()
        {
            //Setting up the facebook object
            ImpactWorks.FBGraph.Connector.Facebook facebook = new ImpactWorks.FBGraph.Connector.Facebook();
            facebook.AppID = "953134378063457";
            facebook.CallBackURL = "https://localhost:44300/PostStatusFace/Success/";
            facebook.Secret = "6862a3f5500556544ed3957ade1ef567";

            //Setting up the permissions
            List<FBPermissions> permissions = new List<FBPermissions>() {
                FBPermissions.user_about_me, // to read about me               
                
                   };

            //Pass the permissions object to facebook instance
            facebook.Permissions = permissions;
            return facebook;
        }

        

    }
}