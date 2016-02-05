using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WAFF.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void ResgisterBundles(BundleCollection bundle)
        {
            var waffBundle = new ScriptBundle("~/scripts/react");

            waffBundle.Include("~/Scripts/react-with-addons.js");
            waffBundle.Include("~/Scripts/Voting/VotingContainer-compiled.js");

            bundle.Add(waffBundle);
        }
    }
}