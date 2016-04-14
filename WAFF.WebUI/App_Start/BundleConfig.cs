using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WAFF.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterVotingBundles(bundles);

            RegisterAdminBundles(bundles);
        }

        public static void RegisterVotingBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/voting").Include(
                "~/Scripts/react-with-addons.js",
                "~/Scripts/Voting/VotingContainer-compiled.js"
                ));
        }

        public static void RegisterAdminBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/admin").Include(
                "~/Scripts/react-with-addons.js",
                "~/Scripts/adminTools/AdminToolsContainer-compiled.js"
                ));
        }
    }
}